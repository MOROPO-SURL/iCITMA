using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Extensions;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Models.View.CustomSelect;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models.View;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Controllers;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Auxiliares")]
    public class ProgramsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Persistence.Entities.Program, System.Guid, ProgramInputViewModel, ProgramDisplayViewModel>
    {
        public readonly IEntityRepository<Institution, System.Guid> institutionRepository;
        public readonly IEntityRepository<Person, System.Guid> personRepository;
        public readonly IEntityRepository<ProgramCategory, System.Guid> programCategoryRepository;
        public readonly IEntityRepository<FundingSource, System.Guid> fundingSourceRepository;
        public readonly IEntityRepository<KeyWord, System.Guid> keyWordRepository;
        public readonly IEntityRepository<Document, System.Guid> documentRepository;


        public ProgramsController(IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<KeyWord, System.Guid> keyWordRepository, IEntityRepository<FundingSource, System.Guid> fundingSourceRepository, IEntityRepository<ProgramCategory, System.Guid> programCategoryRepository, IEntityRepository<Person, System.Guid> personRepository, IEntityRepository<Institution, System.Guid> institutionRepository, IEntityRepository<Persistence.Entities.Program, Guid> repository, IStringLocalizer<ProgramsController> localizer, ILogger<ProgramsController> logger) : base(repository, localizer, logger)
        {
            this.institutionRepository = institutionRepository;
            this.personRepository = personRepository;
            this.programCategoryRepository = programCategoryRepository;
            this.fundingSourceRepository = fundingSourceRepository;
            this.keyWordRepository = keyWordRepository;
            this.documentRepository = documentRepository;

        }
        public IActionResult Index() => View();

        [RequirePermissions(Permission.ProgramCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ProgramCreator)]
        public override IActionResult Create(ProgramInputViewModel modelInput)
        {
            return base.Create(modelInput);
        }

        [RequirePermissions(Permission.ProgramEditor)]
        public override IActionResult Edit(Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ProgramEditor)]        
        public override IActionResult Edit(ProgramInputViewModel modelInput)
        {
            return base.Edit(modelInput);
        }

        [RequirePermissions(Permission.ProgramRemover)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ProgramRemover)]
        public override IActionResult Delete(ProgramDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        private void PopulateLists(ProgramInputViewModel modelInput)
        {
            modelInput.InstitutionSelected = institutionRepository.GetAll().Select(inst => new SelectListItem { Value = inst.Id.ToString(), Text = inst.Identity.Name}).ToArray();
            modelInput.CategorySelected = programCategoryRepository.GetAll().Select(prog => new SelectListItem { Value = prog.Id.ToString(), Text = prog.Name }).ToArray();
            modelInput.LeaderSelected = personRepository.GetAll().Select(pers => new SelectListItem { Value = pers.Id.ToString(), Text = pers.Identity.Name+" "+pers.Identity.LastName }).ToArray();
            modelInput.FundingSourceSelected = fundingSourceRepository.GetAll().Select(fun => new SelectListItem { Value = fun.Id.ToString(), Text = fun.Name }).ToArray();
        }

        protected override void ConfigureCreate(ProgramInputViewModel modelInput)
        {
            base.ConfigureCreate(modelInput);
            PopulateLists(modelInput);
        }

        protected override void ConfigurePostFailCreateValidation(ProgramInputViewModel modelInput)
        {
            base.ConfigurePostFailCreateValidation(modelInput);
            PopulateLists(modelInput);
        }

        protected override void ConfigureEdit(Persistence.Entities.Program entity, ProgramInputViewModel modelInput)
        {
            base.ConfigureEdit(entity, modelInput);
            PopulateLists(modelInput);
        }

        #region Exprerts
        [HttpGet]
        [Route("edit/{key}/programExprerts")]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult EditProgramExprerts(Guid key)
        {
            var entity = Repository.Get(key);

            var model = new ProgramInputViewModel();

            if (entity != null)
            {

                PopulatePersons(entity, model.ExpertsToSelect);

                model.Import(entity);

                return View(model);
            }
            return View(model);
        }

        private void PopulatePersons(Persistence.Entities.Program entity, List<SelectionDescriptedImageItemInputViewModel<System.Guid>> expertsForSelecting)
        {
            var persons = personRepository.GetAll();

            if (persons.Count() > 0)
            {
                expertsForSelecting.AddRange(persons.ToList().Select(item => new SelectionDescriptedImageItemInputViewModel<Guid>
                {
                    Id = item.Id,
                    LabelDisplay = item.Identity.Name+" "+item.Identity.LastName,
                    Label= entity.PersonExpertBridges.Any(a => a.SternId == item.Id)?"Seleccionado":"No Seleccionado",
                    Selected = entity.PersonExpertBridges.Any(a => a.SternId == item.Id),
                    DescriptionDisplay = String.IsNullOrWhiteSpace(item.Identity.About) ? "Sin Descripción" : item.Identity.About,
                    Description = " ",
                    ImageId = item.Identity.ImageId,
                    ImageExtension = item.Identity.Image?.ContentType.ContentTypeToExtension() ?? null

                }));
            }            
        }

        [HttpPost]
        [Route("edit/{key}/programExprerts")]
        [RequirePermissions(Permission.ProgramEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditProgramExprerts(Guid key, ProgramInputViewModel modelInput)
        {
            Persistence.Entities.Program entity = null;

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

            entity.PersonExpertBridges.Clear();            

            foreach (var item in modelInput.ExpertsToSelect)
            {
                if (!item.Selected) continue;

                entity.PersonExpertBridges.Add(new ProgramPersonExpertBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("EditProgramExprerts", new { key = entity.Id });
        }
        #endregion

        #region ProgramKeyWorld
        [HttpGet]
        [Route("edit/{key}/programKeyWorlds")]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult EditProgramKeyWorlds(Guid key)
        {
            var entity = Repository.Get(key);

            var model = new ProgramInputViewModel();

            if (entity != null)
            {

                PopulateKeyWords(entity, model.KeyWordsToSelect);

                model.Import(entity);

                return View(model);
            }
            return View(model);
        }

        private void PopulateKeyWords(Persistence.Entities.Program entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> expertsForSelecting)
        {
            var keyWords = keyWordRepository.GetAll();

            if (keyWords.Count() > 0)
            {
                expertsForSelecting.AddRange(keyWords.ToList().Select(item => new SelectionDescriptedItemInputViewModel<Guid>
                {
                    Id = item.Id,                   
                    Label = item.Name,
                    Selected = entity.KeyWordBridges.Any(a => a.SternId == item.Id),                    
                    Description = item.Description
                }));
            }
        }

        [HttpPost]
        [Route("edit/{key}/programKeyWorlds")]
        [RequirePermissions(Permission.ProgramEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditProgramKeyWorlds(Guid key, ProgramInputViewModel modelInput)
        {
            Persistence.Entities.Program entity = null;

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

            entity.KeyWordBridges.Clear();

            foreach (var item in modelInput.KeyWordsToSelect)
            {
                if (!item.Selected) continue;

                entity.KeyWordBridges.Add(new ProgramKeyWordBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("EditProgramKeyWorlds", new { key = entity.Id });
        }
        #endregion

        #region Documents
        [HttpGet]
        [Route("edit/{key}/programDocuments")]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult EditProgramDocuments(Guid key)
        {
            var entity = Repository.Get(key);

            var model = new ProgramInputViewModel();

            if (entity != null)
            {

                PopulateDocuments(entity, model.DocumentsToSelect);

                model.Import(entity);

                return View(model);
            }
            return View(model);
        }

        private void PopulateDocuments(Persistence.Entities.Program entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> expertsForSelecting)
        {
            var documents = documentRepository.GetAll();

            if (documents.Count() > 0)
            {
                expertsForSelecting.AddRange(documents.ToList().Select(item => new SelectionDescriptedItemInputViewModel<Guid>
                {
                    Id = item.Id,
                    Label = item.Name,
                    Selected = entity.DocumentBridges.Any(a => a.SternId == item.Id),
                    Description = item.Description
                }));
            }
        }

        [HttpPost]
        [Route("edit/{key}/programDocuments")]
        [RequirePermissions(Permission.ProgramEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditProgramDocuments(Guid key, ProgramInputViewModel modelInput)
        {
            Persistence.Entities.Program entity = null;

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

            entity.DocumentBridges.Clear();

            foreach (var item in modelInput.DocumentsToSelect)
            {
                if (!item.Selected) continue;

                entity.DocumentBridges.Add(new ProgramDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = item.Id
                });
            }

            Repository.Update(entity, User.Identity.Name);

            SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

            return RedirectToAction("EditProgramDocuments", new { key = entity.Id });
        }
        #endregion
    }
}
