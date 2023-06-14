using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Auxiliares")]
    public class PersonsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Person, System.Guid, PersonInputViewModel, PersonDisplayViewModel>
    {
        private readonly IEntityRepository<ResearcherCategory, System.Guid> ResearcherCategoryRepository;
        private readonly IEntityRepository<TeachingCategory, System.Guid> TeachingCategoryRepository;
        private readonly IImageFileManagerFacade imageFileManagerFacade;
        private readonly IEntityRepository<Image, Guid> imageRepository;
        private readonly IEntityRepository<PersonIdentity, Guid> identityRepository;
        public PersonsController(IEntityRepository<PersonIdentity, Guid> identityRepository, IEntityRepository<Image, Guid> imageRepository, IImageFileManagerFacade imageFileManagerFacade, IEntityRepository<TeachingCategory, System.Guid> TeachingCategoryRepository, IEntityRepository<ResearcherCategory, System.Guid> ResearcherCategoryRepository, IEntityRepository<Person, Guid> repository, IStringLocalizer<PersonsController> localizer, ILogger<PersonsController> logger) : base(repository, localizer, logger)
        {
            this.ResearcherCategoryRepository = ResearcherCategoryRepository;
            this.TeachingCategoryRepository = TeachingCategoryRepository;
            this.imageFileManagerFacade = imageFileManagerFacade;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
        }

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

        private void PopulateLists(PersonInputViewModel inputModel)
        {
            inputModel.ResearcherCategorys = ResearcherCategoryRepository.GetAll().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToArray();
            inputModel.TeachingCategorys = TeachingCategoryRepository.GetAll().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToArray();
        }

        protected override void ConfigureCreate(PersonInputViewModel modelInput)
        {
            PopulateLists(modelInput);
        }

        protected override void ConfigurePostFailCreateValidation(PersonInputViewModel modelInput)
        {
            PopulateLists(modelInput);
        }

        protected override void ConfigureEdit(Person entity, PersonInputViewModel modelInput)
        {
            PopulateLists(modelInput);
        }

        protected override void ConfigurePostFailEditValidation(Person entity, PersonInputViewModel modelInput)
        {
            PopulateLists(modelInput);
        }

        protected override void PreCreate(Person entity, PersonInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            entity.ResearcherCategory = ResearcherCategoryRepository.Get((Guid)modelInput.ResearcherCategoryId);
            entity.TeachingCategory = TeachingCategoryRepository.Get((Guid)modelInput.TeachingCategoryId);

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

            if (entity.ResearcherCategory.Id != modelInput.ResearcherCategoryId)
            {
                entity.ResearcherCategory = ResearcherCategoryRepository.Get((Guid)modelInput.ResearcherCategoryId);
            }

            if (entity.TeachingCategory.Id != modelInput.TeachingCategoryId)
            {
                entity.TeachingCategory = TeachingCategoryRepository.Get((Guid)modelInput.TeachingCategoryId);
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

    }
}
