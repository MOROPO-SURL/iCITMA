using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models.View;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("ecosystem")]
    public class PersonsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Person, System.Guid, PersonInputViewModel, PersonDisplayViewModel>
    {
        private readonly IEntityRepository<ResearcherCategory, System.Guid> ResearcherCategoryRepository;
        private readonly IEntityRepository<TeachingCategory, System.Guid> TeachingCategoryRepository;
        private readonly IImageFileManagerFacade imageFileManagerFacade;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<PersonIdentity, System.Guid> identityRepository;
        private readonly IEntityRepository<Institution, System.Guid> institutionsRepository;
        private readonly IEntityRepository<ResearchArea, System.Guid> researchAreaRepository;

        public PersonsController(IEntityRepository<ResearchArea, System.Guid> researchAreaRepository, IEntityRepository<Institution, System.Guid> institutionsRepository, IEntityRepository<PersonIdentity, System.Guid> identityRepository, IEntityRepository<Image, System.Guid> imageRepository, IImageFileManagerFacade imageFileManagerFacade, IEntityRepository<TeachingCategory, System.Guid> TeachingCategoryRepository, IEntityRepository<ResearcherCategory, System.Guid> ResearcherCategoryRepository, IEntityRepository<Person, System.Guid> repository, IStringLocalizer<PersonsController> localizer, ILogger<PersonsController> logger) : base(repository, localizer, logger)
        {
            this.ResearcherCategoryRepository = ResearcherCategoryRepository;
            this.TeachingCategoryRepository = TeachingCategoryRepository;
            this.imageFileManagerFacade = imageFileManagerFacade;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
            this.institutionsRepository = institutionsRepository;
            this.researchAreaRepository = researchAreaRepository;
        }

        [RequirePermissions(Permission.PersonViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.PersonCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.PersonCreator)]

        public override IActionResult Create(PersonInputViewModel inputViewModel)
        {
            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    ModelState.ClearValidationState("ImageFile");

                    inputViewModel.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(inputViewModel);

                    updateModelTask.Wait();
                }
            }
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.PersonEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.PersonEditor)]
        public override IActionResult Edit(PersonInputViewModel inputModel)
        {
            ModelState.ClearValidationState("ImageFile");
            ModelState.MarkFieldValid("ImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    inputModel.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(inputModel);

                    updateModelTask.Wait();
                }
            }


            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.PersonRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.PersonRemover)]
        public override IActionResult Delete(PersonDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        private void Populate(PersonInputViewModel inputModel)
        {
            inputModel.ResearcherCategorys = ResearcherCategoryRepository.GetAll().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToArray();
            inputModel.TeachingCategorys = TeachingCategoryRepository.GetAll().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToArray();
        }

        protected override void ConfigureCreate(PersonInputViewModel modelInput)
        {
            Populate(modelInput);
        }

        protected override void ConfigurePostFailCreateValidation(PersonInputViewModel modelInput)
        {
            Populate(modelInput);
        }

        protected override void ConfigureEdit(Person entity, PersonInputViewModel modelInput)
        {
            Populate(modelInput);
        }

        protected override void ConfigurePostFailEditValidation(Person entity, PersonInputViewModel modelInput)
        {
            Populate(modelInput);
        }

        protected override void PreCreate(Person entity, PersonInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            if (modelInput.ResearcherCategoryId != null)
            {
                entity.ResearcherCategoryId = modelInput.ResearcherCategoryId;
                entity.ResearcherCategory = ResearcherCategoryRepository.Get(modelInput.ResearcherCategoryId.Value);
            }

            if (modelInput.TeachingCategoryId != null)
            {
                entity.TeachingCategoryId = modelInput.TeachingCategoryId;
                entity.TeachingCategory = TeachingCategoryRepository.Get(modelInput.TeachingCategoryId.Value);
            }

            if (modelInput.ImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.ImageFile.CopyTo(memoryStream);

                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "person " + entity.Id };

                imageFileManagerFacade.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                entity.Identity.Image = image;
            }
        }

        protected override void PreEdit(Person entity, PersonInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            if (entity.ResearcherCategoryId != modelInput.ResearcherCategoryId)
            {
                if (modelInput.ResearcherCategoryId == null)
                {
                    entity.ResearcherCategoryId = null;
                    entity.ResearcherCategory = null;
                }
                else
                {
                    entity.ResearcherCategoryId = modelInput.ResearcherCategoryId;
                    entity.ResearcherCategory = ResearcherCategoryRepository.Get(modelInput.ResearcherCategoryId.Value);
                }
            }

            if (entity.TeachingCategoryId != modelInput.TeachingCategoryId)
            {
                if (modelInput.TeachingCategoryId == null)
                {
                    entity.TeachingCategoryId = null;
                    entity.TeachingCategory = null;
                }
                else
                {
                    entity.TeachingCategoryId = modelInput.TeachingCategoryId;
                    entity.TeachingCategory = TeachingCategoryRepository.Get(modelInput.TeachingCategoryId.Value);
                }
            }

            if (modelInput.ImageFile == null)
            {
                if (modelInput.ResetImage && entity.Identity.Image != null)
                {
                    imageFileManagerFacade.DeleteImageFile(entity.Identity.Image);

                    imageRepository.Delete(entity.Identity.Image, User.Identity.Name);
                }

                return;
            }

            if (entity.Identity.Image != null)
            {
                imageFileManagerFacade.DeleteImageFile(entity.Identity.Image);

                imageRepository.Delete(entity.Identity.Image, User.Identity.Name);
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.ImageFile.CopyTo(memoryStream);

                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Person " + entity.Id };

                imageFileManagerFacade.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                entity.Identity.Image = image;
                imageRepository.Add(image, User.Identity.Name);
            }
        }

        protected override void PostDelete(Person entity)
        {
            base.PostDelete(entity);

            identityRepository.Delete(entity.Identity, User.Identity.Name);

            if (entity.Identity.Image == null) return;

            imageRepository.Delete(entity.Identity.Image, User.Identity.Name);
            imageFileManagerFacade.DeleteImageFile(entity.Identity.Image);
        }

        [HttpGet]
        [Route("edit/{key}/personInstitutions")]
        [RequirePermissions(Permission.PersonEditor)]
        public ActionResult EditPersonInstitutions(System.Guid key)
        {
            var entity = Repository.Get(key);

            var model = new PersonInputViewModel();

            PopulateInstitutions(entity, model.InstitutionsToSelect);

            model.Import(entity);

            return View(model);
        }

        private void PopulateInstitutions(Person entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> institutionsForSelecting)
        {
            var institutions = institutionsRepository.GetAll();

            if (institutions.Count() > 0)
            {
                institutionsForSelecting.AddRange(institutions.ToList().Select(item => new SelectionDescriptedItemInputViewModel<System.Guid>
                {
                    Id = item.Id,
                    Label = item.Identity.Name,
                    Selected = entity.InstitutionBridges.Any(a => a.SternId == item.Id),
                    Description = string.IsNullOrWhiteSpace(item.Identity.About) ? "Sin Descripción" : item.Identity.About
                }));
            }

        }

        [HttpPost]
        [Route("edit/{key}/personInstitutions")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditPersonInstitutions(System.Guid key, PersonInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(key);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            entity.InstitutionBridges.Clear();

            foreach (var item in modelInput.InstitutionsToSelect)
            {
                if (!item.Selected) continue;

                entity.InstitutionBridges.Add(new PersonInstitutionBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("editpersoninstitutions", new { key = entity.Id });
        }

        [HttpGet]
        [Route("edit/{key}/personSpecializations")]
        [RequirePermissions(Permission.PersonEditor)]
        public ActionResult EditPersonSpecializations(System.Guid key)
        {
            var entity = Repository.Get(key);

            var model = new PersonInputViewModel();

            PopulateSpecializations(entity, model.SpecializationsToSelect);

            model.Import(entity);

            return View(model);
        }

        private void PopulateSpecializations(Person entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> SpecializationsForSelecting)
        {
            var Specializations = researchAreaRepository.GetAll();

            if (Specializations.Count() > 0)
            {
                SpecializationsForSelecting.AddRange(Specializations.ToList().Select(item => new SelectionDescriptedItemInputViewModel<System.Guid>
                {
                    Id = item.Id,
                    Label = item.Name,
                    Selected = entity.ResearchAreaSpecializationBridges.Any(a => a.SternId == item.Id),
                    Description = string.IsNullOrWhiteSpace(item.Description) ? "Sin Descripción" : item.Description
                }));
            }

        }

        [HttpPost]
        [Route("edit/{key}/personSpecializations")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditPersonSpecializations(System.Guid key, PersonInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(key);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            entity.ResearchAreaSpecializationBridges.Clear();

            foreach (var item in modelInput.SpecializationsToSelect)
            {
                if (!item.Selected) continue;

                entity.ResearchAreaSpecializationBridges.Add(new PersonResearchAreaSpecializationBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("editpersonspecializations", new { key = entity.Id });
        }

        [HttpGet]
        [Route("edit/{key}/personMasterys")]
        [RequirePermissions(Permission.PersonEditor)]
        public ActionResult EditPersonMasterys(System.Guid key)
        {
            var entity = Repository.Get(key);

            var model = new PersonInputViewModel();

            PopulateMasterys(entity, model.MasterysToSelect);

            model.Import(entity);

            return View(model);
        }

        private void PopulateMasterys(Person entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> MasterysForSelecting)
        {
            var Masterys = researchAreaRepository.GetAll();

            if (Masterys.Count() > 0)
            {
                MasterysForSelecting.AddRange(Masterys.ToList().Select(item => new SelectionDescriptedItemInputViewModel<System.Guid>
                {
                    Id = item.Id,
                    Label = item.Name,
                    Selected = entity.ResearchAreaMasteryBridges.Any(a => a.SternId == item.Id),
                    Description = string.IsNullOrWhiteSpace(item.Description) ? "Sin Descripción" : item.Description
                }));
            }

        }

        [HttpPost]
        [Route("edit/{key}/personMasterys")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditPersonMasterys(System.Guid key, PersonInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(key);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            entity.ResearchAreaMasteryBridges.Clear();

            foreach (var item in modelInput.MasterysToSelect)
            {
                if (!item.Selected) continue;

                entity.ResearchAreaMasteryBridges.Add(new PersonResearchAreaMasteryBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("editpersonmasterys", new { key = entity.Id });
        }

        [HttpGet]
        [Route("edit/{key}/personDoctorates")]
        [RequirePermissions(Permission.PersonEditor)]
        public ActionResult EditPersonDoctorates(System.Guid key)
        {
            var entity = Repository.Get(key);

            var model = new PersonInputViewModel();

            PopulateDoctorates(entity, model.DoctoratesToSelect);

            model.Import(entity);

            return View(model);
        }

        private void PopulateDoctorates(Person entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> DoctoratesForSelecting)
        {
            var Doctorates = researchAreaRepository.GetAll();

            if (Doctorates.Count() > 0)
            {
                DoctoratesForSelecting.AddRange(Doctorates.ToList().Select(item => new SelectionDescriptedItemInputViewModel<System.Guid>
                {
                    Id = item.Id,
                    Label = item.Name,
                    Selected = entity.ResearchAreaDoctorateBridges.Any(a => a.SternId == item.Id),
                    Description = string.IsNullOrWhiteSpace(item.Description) ? "Sin Descripción" : item.Description
                }));
            }

        }

        [HttpPost]
        [Route("edit/{key}/personDoctorates")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditPersonDoctorates(System.Guid key, PersonInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(key);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            entity.ResearchAreaDoctorateBridges.Clear();

            foreach (var item in modelInput.DoctoratesToSelect)
            {
                if (!item.Selected) continue;

                entity.ResearchAreaDoctorateBridges.Add(new PersonResearchAreaDoctorateBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("editpersondoctorates", new { key = entity.Id });
        }
    }
}
