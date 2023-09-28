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
using System.Collections.Generic;
using System.Linq;
using Document = MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Document;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("I_D_i")]
    public class ProgramsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Persistence.Entities.Program, System.Guid, ProgramInputViewModel, ProgramDisplayViewModel>
    {
        public readonly IEntityRepository<Institution, System.Guid> institutionRepository;
        public readonly IEntityRepository<Person, System.Guid> personRepository;
        public readonly IEntityRepository<ProgramCategory, System.Guid> programCategoryRepository;
        public readonly IEntityRepository<FundingSource, System.Guid> fundingSourceRepository;
        public readonly IEntityRepository<KeyWord, System.Guid> keyWordRepository;
        public readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly Managers.RelativeDocumentFileManager attachmentFileManager;        


        public ProgramsController(Managers.RelativeDocumentFileManager attachmentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<KeyWord, System.Guid> keyWordRepository, IEntityRepository<FundingSource, System.Guid> fundingSourceRepository, IEntityRepository<ProgramCategory, System.Guid> programCategoryRepository, IEntityRepository<Person, System.Guid> personRepository, IEntityRepository<Institution, System.Guid> institutionRepository, IEntityRepository<Persistence.Entities.Program, System.Guid> repository, IStringLocalizer<ProgramsController> localizer, ILogger<ProgramsController> logger) : base(repository, localizer, logger)
        {
            this.institutionRepository = institutionRepository;
            this.personRepository = personRepository;
            this.programCategoryRepository = programCategoryRepository;
            this.fundingSourceRepository = fundingSourceRepository;
            this.keyWordRepository = keyWordRepository;
            this.documentRepository = documentRepository;
            this.attachmentFileManager = attachmentFileManager;

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
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ProgramEditor)]
        public override IActionResult Edit(ProgramInputViewModel modelInput)
        {
            return base.Edit(modelInput);
        }

        [RequirePermissions(Permission.ProgramRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ProgramRemover)]
        public override IActionResult Delete(ProgramDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void ConfigureCreate(ProgramInputViewModel modelInput)
        {
            base.ConfigureCreate(modelInput);
            
            Populate(modelInput);
        }

        protected override void ConfigurePostFailCreateValidation(ProgramInputViewModel modelInput)
        {
            base.ConfigurePostFailCreateValidation(modelInput);
            
            Populate(modelInput);
        }

        protected override void ConfigureEdit(Persistence.Entities.Program entity, ProgramInputViewModel modelInput)
        {
            base.ConfigureEdit(entity, modelInput);
            
            Populate(modelInput);
        }

        protected override void ValidateCreate(ProgramInputViewModel modelInput)
        {
            base.ValidateCreate(modelInput);

            if (modelInput.EndAt != null && modelInput.EndAt.Value.Date < modelInput.StartDate.Date)
            {
                ModelState.AddModelError("EndAt", "La Fecha de Terminación no puede ser menor que la Fecha de Inicio");
            }
        }

        protected override void ValidateEdit(ProgramInputViewModel modelInput)
        {
            base.ValidateEdit(modelInput);

            if (modelInput.EndAt != null && modelInput.EndAt.Value.Date < modelInput.StartDate.Date)
            {
                ModelState.AddModelError("EndAt", "La Fecha de Terminación no puede ser menor que la Fecha de Inicio");
            }
        }

        protected override void ConfigurePostFailEditValidation(Persistence.Entities.Program entity, ProgramInputViewModel modelInput)
        {
            base.ConfigurePostFailEditValidation(entity, modelInput);

            Populate(modelInput);
        }

        protected override void PreCreate(Persistence.Entities.Program entity, ProgramInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            entity.CategoryId = modelInput.CategoryId.Value;
            entity.ManagerId = modelInput.ManagerId.Value;
            entity.LeaderId = modelInput.LeaderId.Value;
        }

        protected override void PreEdit(Persistence.Entities.Program entity, ProgramInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            if (entity.CategoryId != modelInput.CategoryId)
            {
                entity.CategoryId = modelInput.CategoryId.Value;
                entity.Category = programCategoryRepository.Get(modelInput.CategoryId.Value);
            }

            if (entity.ManagerId != modelInput.ManagerId)
            {
                entity.ManagerId = modelInput.ManagerId.Value;
                entity.Manager = institutionRepository.Get(modelInput.ManagerId.Value);
            }

            if (entity.LeaderId != modelInput.LeaderId)
            {
                entity.LeaderId = modelInput.LeaderId.Value;
                entity.Leader = personRepository.Get(modelInput.LeaderId.Value);
            }
        }

        private void Populate(ProgramInputViewModel modelInput)
        {
            modelInput.InstitutionSelectedListItems = institutionRepository.GetAll().Select(inst => new SelectListItem { Value = inst.Id.ToString(), Text = inst.Identity.Name }).ToArray();
            modelInput.CategorySelectedListItems = programCategoryRepository.GetAll().Select(prog => new SelectListItem { Value = prog.Id.ToString(), Text = prog.Name }).ToArray();
            modelInput.LeaderSelectedListItems = personRepository.GetAll().Select(pers => new SelectListItem { Value = pers.Id.ToString(), Text = pers.Identity.Name + " " + pers.Identity.LastName }).ToArray();
        }

        #region Experts
        [HttpGet]
        [Route("edit/{key}/experts")]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult ManageExperts(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var experts = entity.PersonExpertBridges.Select(p => p.Stern).ToArray();

                var notSelectedExperts = personRepository.GetAll().ToArray();

                if (experts.Length > 0)
                {
                    notSelectedExperts = notSelectedExperts.Except(experts).ToArray();
                }

                var resultModel = new ProgramExpertManagerViewModel
                {
                    Program = new ProgramDisplayViewModel()
                };

                resultModel.Program.Import(entity);

                resultModel.NotSelectedExperts = notSelectedExperts.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Identity.Name} {exp.Identity.LastName}"
                }).ToArray();

                resultModel.Experts = experts.Select(item =>
                {
                    var model = new PersonDisplayViewModel
                    {
                        ProgramExpert = new ProgramExpertDisplayViewModel
                        {
                            ProgramId = key,
                            PersonId = item.Id,
                            Name = $"{item.Identity.Name} {item.Identity.LastName}",
                            Alias = item.Identity.Alias
                        }
                    };

                    model.Import(item);

                    return model;
                }).ToArray();

                return View(resultModel);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/experts/add")]
        [RequirePermissions(Permission.ProgramEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpert(ProgramExpertInputViewModel modelInput)
        {
            Persistence.Entities.Program entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProgramId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.PersonExpertBridges.Add(new ProgramPersonExpertBridge
                {
                    ProwId = entity.Id,
                    SternId = modelInput.PersonId,
                    Prow = entity,
                    Stern = personRepository.Get(modelInput.PersonId)
                });

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());
            }
            else
            {
                var messages = new List<string>();

                foreach (var item in ModelState)
                {
                    if (ModelState.GetFieldValidationState(item.Key) != Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid) continue;

                    foreach (var error in item.Value.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }

                SetDefaultNotification(NotificationType.Danger, messages.ToArray());
            }

            return RedirectToAction("ManageExperts", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/experts/remove")]
        [RequirePermissions(Permission.ProgramEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveExpert(ProgramExpertDisplayViewModel modelInput)
        {
            Persistence.Entities.Program entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProgramId);
            }
            catch (System.Exception)
            {

                throw;
            }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            try
            {
                var brigde = entity.PersonExpertBridges.FirstOrDefault(exp => exp.ProwId == modelInput.ProgramId && exp.SternId == modelInput.PersonId);

                entity.PersonExpertBridges.Remove(brigde);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(NotificationType.Success, GetDeletionSuccessMessage());
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            return RedirectToAction("ManageExperts", new { key = entity.Id });
        }
        #endregion

        #region ProgramKeyWorld
        [HttpGet]
        [Route("edit/{key}/program/keyworlds")]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult EditProgramKeyWorlds(System.Guid key)
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
                expertsForSelecting.AddRange(keyWords.ToList().Select(item => new SelectionDescriptedItemInputViewModel<System.Guid>
                {
                    Id = item.Id,
                    Label = item.Name,
                    Selected = entity.KeyWordBridges.Any(a => a.SternId == item.Id),
                    Description = item.Description
                }));
            }
        }

        [HttpPost]
        //[Route("edit/{key}/program/keyworlds/{modelInput}")]
        [Route("edit/{key}/program/keyworlds")]
        [RequirePermissions(Permission.ProgramEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult EditProgramKeyWorlds(System.Guid key, ProgramInputViewModel modelInput)
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
        [Route("edit/{key}/program/documents")]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult EditProgramDocuments(System.Guid key)
        {
            var entity = Repository.Get(key);

            var model = new ProgramDocumentDisplayViewModel
            {
                Program = new ProgramDisplayViewModel(),
                Documents = entity.DocumentBridges.Select(item =>
                {
                    var result = new DocumentDisplayViewModel();

                    result.Import(item.Stern);

                    return result;
                    
                }).ToArray()
                
            };

            model.Program.Import(entity);

            return View(model);
        }

        [HttpPost]
        [Route("edit/{key}/program/documents/add")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult AddDocument(System.Guid key, DocumentInputViewModel model)
        {
            try
            {
                var entity = Repository.Get(key);

                ModelState.ClearValidationState("File");

                model.File = Request.Form.Files[0];

                var updateModelTask = TryUpdateModelAsync(model);

                updateModelTask.Wait();

                if (ModelState.IsValid)
                {
                    try
                    {
                        using (var memoryStream = new System.IO.MemoryStream())
                        {
                            model.File.CopyTo(memoryStream);

                            var document = new Document
                            {
                                Name = model.Name,
                                Description = model.Description,
                                ContentType = model.File.ContentType,
                                Length = model.File.Length
                            };

                            documentRepository.Add(document, User.Identity.Name);

                            var documentBridge = new ProgramDocumentBridge
                            {
                                ProwId = entity.Id,
                                Prow = entity,
                                Stern = document,
                                SternId = document.Id                                
                            };
                            
                            entity.DocumentBridges.Add(documentBridge);

                            Repository.Update(entity, User.Identity.Name);

                            attachmentFileManager.SaveImageFileContent(document.Id, memoryStream.ToArray(), document.ContentType);
                        }

                        SetDefaultNotification(NotificationType.Success, GetCreationSuccessMessage());

                        return RedirectToAction("EditProgramDocuments", new { key = entity.Id });
                    }
                    catch (MOROPO.Framework.Guama.Core.Presentation.Web.Frontend.InvalidModelException e)
                    {
                        ModelState.AddModelError(e.ModelKey, e.ErrorMessage);
                    }
                }

                SetDefaultNotification(NotificationType.Danger, GetInvalidMessage());

                return RedirectToAction("EditProgramDocuments", new { key = entity.Id });
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/program/documents/delete")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult DeleteDocument(System.Guid key, System.Guid documentId)
        {
            try
            {
                var entity = Repository.Get(key);

                var document = entity.DocumentBridges.First(e => e.SternId == documentId);

                attachmentFileManager.DeleteImageFile(document.Stern);

                documentRepository.Delete(document.Stern, User.Identity.Name);

                entity.DocumentBridges.Remove(document);

                SetDefaultNotification(NotificationType.Success, GetDeletionSuccessMessage());

                return RedirectToAction("EditProgramDocuments", new { key = entity.Id });
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());

                return RedirectToAction("EditProgramDocuments", new { key });
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetSuccessDeleteActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/program/documents/edit")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.ProgramEditor)]
        public IActionResult EditDocument(System.Guid key, DocumentInputViewModel modelInput)
        {
            try
            {
                ModelState.Remove("File");                

                if (ModelState.IsValid)
                {
                    Document val = documentRepository.Get(modelInput.Id);
                    try
                    {
                        modelInput.MergueForProgram(val);

                        documentRepository.Update(val, User.Identity.Name);

                        SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());
                        
                        return RedirectToAction("EditProgramDocuments", new { key });
                    }
                    catch (System.Exception ex2)
                    {
                        logger.LogError(ex2.InnerException, ex2.Message);
                        
                        SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());
                        
                        return RedirectToAction("EditProgramDocuments", new { key });
                    }
                }
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }
            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/program/documents/{documentId}/download")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.ProgramEditor)]
        public FileResult DownloadDocument(System.Guid key, System.Guid documentId)
        {

            var entity = Repository.Get(key);
            var document = entity.DocumentBridges.FirstOrDefault(att => att.Stern.Id == documentId);

            var fileBytes = attachmentFileManager.GetImageFileContent(document.Stern);
            var extension = document.Stern.ContentType.Split('/');
            var fileName = document.Stern.Name + "." + extension[1];

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }

        #endregion
    }
}
