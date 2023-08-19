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
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("I_D_i")]
    public class ProjectsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Project, Guid, ProjectInputViewModel, ProjectDisplayViewModel>
    {
        public readonly IEntityRepository<Person, Guid> leaderRepository;
        public readonly IEntityRepository<ProjectCategory, Guid> categoryRepository;
        public readonly IEntityRepository<Institution, Guid> managerRepository;
        public readonly IEntityRepository<Persistence.Entities.Program, Guid> programRepository;
        public readonly IEntityRepository<ProjectState, Guid> projectStateRepository;
        public readonly IEntityRepository<ProgramExpectResult, Guid> programExpectResultRepository;
        public readonly IEntityRepository<Institution, Guid> institutionRepository;
        public readonly IEntityRepository<KeyWord, Guid> keyWordRepository;
        public readonly IEntityRepository<ProjectImpact, Guid> projectImpactRepository;
        public readonly IEntityRepository<ImpactIndicator, Guid> impactIndicatorRepository;
        public readonly IEntityRepository<ODSIndicator, Guid> odsIndicatorRepository;
        public readonly IEntityRepository<Person, Guid> personRepository;
        public readonly IEntityRepository<ProjectOutput, Guid> projectOutputRepository;
        public readonly IEntityRepository<OutputKind, Guid> outputKindRepository;
        public ProjectsController(
            IEntityRepository<OutputKind, Guid> outputKindRepository,
            IEntityRepository<ProjectOutput, Guid> projectOutputRepository, 
            IEntityRepository<Person, Guid> personRepository, 
            IEntityRepository<ODSIndicator, Guid> odsIndicatorRepository,
            IEntityRepository<ImpactIndicator, Guid> impactIndicatorRepository, 
            IEntityRepository<ProjectImpact, Guid> projectImpactRepository,
            IEntityRepository<KeyWord, Guid> keyWordRepository, 
            IEntityRepository<Institution, Guid> institutionRepository,
            IEntityRepository<ProgramExpectResult, Guid> programExpectResultRepository, 
            IEntityRepository<ProjectState, Guid> projectStateRepository,
            IEntityRepository<Persistence.Entities.Program, Guid> programRepository, 
            IEntityRepository<Institution, Guid> managerRepository,
            IEntityRepository<ProjectCategory, Guid> categoryRepository, 
            IEntityRepository<Person, Guid> leaderRepository, 
            IEntityRepository<Project, Guid> repository,
            IStringLocalizer<ProjectsController> localizer, 
            ILogger<ProjectsController> logger) : base(repository, localizer, logger)
        {
            this.leaderRepository = leaderRepository;
            this.categoryRepository = categoryRepository;
            this.managerRepository = managerRepository;
            this.programRepository = programRepository;
            this.projectStateRepository = projectStateRepository;
            this.programExpectResultRepository = programExpectResultRepository;
            this.institutionRepository = institutionRepository;
            this.keyWordRepository = keyWordRepository;
            this.projectImpactRepository = projectImpactRepository;
            this.impactIndicatorRepository = impactIndicatorRepository;
            this.odsIndicatorRepository = odsIndicatorRepository;
            this.personRepository = personRepository;
            this.projectOutputRepository = projectOutputRepository;
            this.outputKindRepository = outputKindRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ProjectCreator)]
        public override IActionResult Create() => base.Create();

        [RequirePermissions(Permission.ProjectEditor)]
        public override IActionResult Create(ProjectInputViewModel modelInput) => base.Create(modelInput);

        [RequirePermissions(Permission.ProjectEditor)]
        public override IActionResult Edit(Guid key) => base.Edit(key);

        [RequirePermissions(Permission.ProjectEditor)]
        [HttpPost]
        public override IActionResult Edit(ProjectInputViewModel modelInput)
        {
            return base.Edit(modelInput);
        }

        [RequirePermissions(Permission.ProjectRemover)]
        public override IActionResult Delete(ProjectDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        [RequirePermissions(Permission.ProjectRemover)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        private void Populate(ProjectInputViewModel modelInput)
        {
            modelInput.CategorySelectListItems = categoryRepository.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToArray();
            modelInput.InstitutionSelectListItems = managerRepository.GetAll().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Identity.Name
            }).ToArray();
            modelInput.PersonSelectListItems = leaderRepository.GetAll().Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = $"{l.Identity.Name} {l.Identity.LastName}"
            }).ToArray();
            modelInput.ProgramSelectListItems = programRepository.GetAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToArray();
            modelInput.StateSelectListItems = projectStateRepository.GetAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToArray();
        }

        protected override void ConfigureCreate(ProjectInputViewModel modelInput)
        {
            base.ConfigureCreate(modelInput);

            Populate(modelInput);
        }

        protected override void ConfigurePostFailCreateValidation(ProjectInputViewModel modelInput)
        {
            base.ConfigurePostFailCreateValidation(modelInput);

            Populate(modelInput);
        }

        protected override void ConfigureEdit(Project entity, ProjectInputViewModel modelInput)
        {
            base.ConfigureEdit(entity, modelInput);

            Populate(modelInput);
        }

        protected override void ConfigurePostFailEditValidation(Project entity, ProjectInputViewModel modelInput)
        {
            base.ConfigurePostFailEditValidation(entity, modelInput);

            Populate(modelInput);
        }

        protected override void ValidateCreate(ProjectInputViewModel modelInput)
        {
            base.ValidateCreate(modelInput);

            if (modelInput.EndAt != null && modelInput.EndAt.Value.Date < modelInput.StartAt.Date)
            {
                ModelState.AddModelError("EndAt", "La Fecha de Terminación no puede ser menor que la Fecha de Inicio");
            }
        }

        protected override void ValidateEdit(ProjectInputViewModel modelInput)
        {
            base.ValidateEdit(modelInput);

            if (modelInput.EndAt != null && modelInput.EndAt.Value.Date < modelInput.StartAt.Date)
            {
                ModelState.AddModelError("EndAt", "La Fecha de Terminación no puede ser menor que la Fecha de Inicio");
            }
        }

        protected override void PreCreate(Project entity, ProjectInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            entity.CategoryId = modelInput.CategoryId.Value;
            entity.ManagerId = modelInput.ManagerId.Value;
            entity.LeaderId = modelInput.LeaderId.Value;
            entity.ProgramId = modelInput.ProgramId.Value;
            entity.StateId = modelInput.StateId.Value;
        }

        protected override void PreEdit(Project entity, ProjectInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            if (entity.CategoryId != modelInput.CategoryId)
            {
                entity.CategoryId = modelInput.CategoryId.Value;
                entity.Category = categoryRepository.Get(modelInput.CategoryId.Value);
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

            if (entity.ProgramId != modelInput.ProgramId)
            {
                entity.ProgramId = modelInput.ProgramId.Value;
                entity.Program = programRepository.Get(modelInput.ProgramId.Value);
            }

            if (entity.StateId != modelInput.StateId)
            {
                entity.StateId = modelInput.StateId.Value;
                entity.State = projectStateRepository.Get(modelInput.StateId.Value);
            }
        }

        #region ProgramExpectResult

        [Route("edit/{key}/ProgramExpectResults")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult ProgramExpectResults(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var projectInputModel = new ProjectInputViewModel();
                projectInputModel.Import(entity);

                return View(projectInputModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("edit/{key}/ProgramExpectResults/add")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult AddExpectResult(ProjectProgramExpectResultInputViewModel modelInput)
        {
            var entity = Repository.Get(modelInput.ProjectId);


            if (ModelState.IsValid)
            {
                var Stern = new ProgramExpectResult
                {
                    ProgramId = entity.ProgramId,
                    Program = entity.Program,
                    Title = modelInput.Title,
                    Description = modelInput.Description
                };

                programExpectResultRepository.Add(Stern, User.Identity.Name, false);

                var bridge = new ProjectProgramExpectResultBridge
                {
                    Prow = entity,
                    ProwId = entity.Id,
                    Stern = Stern
                };
                entity.ProgramExpectResultBridges.Add(bridge);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetCreationSuccessMessage());
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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, messages.ToArray());
            }

            return RedirectToAction("ProgramExpectResults", new { key = entity.Id });
        }

        [Route("edit/{key}/ProgramExpectResults/delete")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult DeleteExpectResult(System.Guid IdProgramExpectResult, System.Guid ProjectId)
        {
            ProgramExpectResult programExpectResult = null;
            try
            {
                programExpectResult = programExpectResultRepository.Get(IdProgramExpectResult);

            }
            catch { }

            try
            {
                var project = Repository.Get(ProjectId);

                var programExpectResultBridges = project.ProgramExpectResultBridges.FirstOrDefault(p => p.Stern.Id == programExpectResult.Id);

                project.ProgramExpectResultBridges.Remove(programExpectResultBridges);

                programExpectResultRepository.Delete(programExpectResult, User.Identity.Name, false);

                Repository.Update(project, User.Identity.Name, true);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            return RedirectToAction("ProgramExpectResults", new { key = ProjectId });
        }
        #endregion

        #region Participation
        [HttpGet]
        [Route("edit/{key}/projectInstitutionParticipation")]
        [RequirePermissions(Permission.ProjectEditor)]
        public IActionResult EditProjectInstitutionParticipation(Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var participants = entity.InstitutionParticipationBridges.Select(p => p.Stern).ToArray();

                var notSelectedParticipants = institutionRepository.GetAll().ToArray();

                if (participants.Count() != 0)
                {
                    notSelectedParticipants = notSelectedParticipants.Except(participants).ToArray();
                }

                var resultModel = new InstitutionParticipationManagerViewModel
                {
                    Project = new ProjectDisplayViewModel
                    {

                    }
                };

                resultModel.Project.Import(entity);

                resultModel.NotSelectedParticipants = notSelectedParticipants.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Identity.Name}"
                }).ToArray();

                resultModel.Participants = participants.Select(item =>
                {
                    var model = new InstitutionDisplayViewModel
                    {
                        InstitutionProjectLogicViewModel = new InstitutionParticipationDisplayViewModel
                        {
                            ProjectId = key,
                            InstitutionId = item.Id,
                            InstitutionName = $"{item.Identity.Name}"                           
                        }
                    };

                    model.Import(item);

                    return model;
                }).ToArray();

                return View(resultModel);
            }
            catch (Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/projectInstitutionParticipation/add")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstitutionParticipation(InstitutionParticipationInputViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProjectId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.InstitutionParticipationBridges.Add(new ProjectInstitutionParticipationBridge
                {
                    ProwId = entity.Id,
                    SternId = modelInput.InstitutionId,
                    Prow = entity,
                    Stern = institutionRepository.Get(modelInput.InstitutionId)
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

            return RedirectToAction("EditProjectInstitutionParticipation", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/projectInstitutionParticipation/remove")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveInstitutionParticipation(InstitutionParticipationDisplayViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProjectId);
            }
            catch (Exception)
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
                var brigde = entity.InstitutionParticipationBridges.FirstOrDefault(exp => exp.ProwId == modelInput.ProjectId && exp.SternId == modelInput.InstitutionId);

                entity.InstitutionParticipationBridges.Remove(brigde);

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

            return RedirectToAction("EditProjectInstitutionParticipation", new { key = entity.Id });
        }
        #endregion

        #region ProjectKeyWorld
        
        //[HttpGet]
        //[Route("edit/{key}/projectKeyWorlds")]
        //[RequirePermissions(Permission.ProjectEditor)]
        //public IActionResult EditProjectKeyWorlds(Guid key)
        //{
        //    var entity = Repository.Get(key);

        //    var model = new ProjectInputViewModel();

        //    if (entity != null)
        //    {

        //        PopulateKeyWords(entity, model.KeyWordsToSelect);

        //        model.Import(entity);

        //        return View(model);
        //    }
        //    return View(model);
        //}

        private void PopulateKeyWords(Project entity, List<SelectionDescriptedItemInputViewModel<System.Guid>> expertsForSelecting)
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

        //[HttpPost]
        //[Route("edit/{key}/projectKeyWorlds")]
        //[RequirePermissions(Permission.ProjectEditor)]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditProjectKeyWorlds(Guid key, ProjectInputViewModel modelInput)
        //{
        //    Persistence.Entities.Project entity = null;

        //    try
        //    {
        //        entity = Repository.Get(key);
        //    }
        //    catch { }

        //    if (entity == null)
        //    {
        //        SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

        //        return GetDefaultActionResult();
        //    }

        //    entity.KeyWordBridges.Clear();

        //    foreach (var item in modelInput.KeyWordsToSelect)
        //    {
        //        if (!item.Selected) continue;

        //        entity.KeyWordBridges.Add(new ProjectKeyWordBridge
        //        {
        //            ProwId = entity.Id,
        //            SternId = item.Id
        //        });
        //    }

        //    Repository.Update(entity, User.Identity.Name);

        //    SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

        //    return RedirectToAction("EditProjectKeyWorlds", new { key = entity.Id });
        //}

        #endregion

        #region Client
        [HttpGet]
        [Route("edit/{key}/projectInstitutionClient")]
        [RequirePermissions(Permission.ProjectEditor)]
        public IActionResult EditProjectInstitutionClient(Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var clients = entity.InstitutionClientBridges.Select(p => p.Stern).ToArray();

                var notSelectedClients = institutionRepository.GetAll().ToArray();

                if (clients.Count() != 0)
                {
                    notSelectedClients = notSelectedClients.Except(clients).ToArray();
                }

                var resultModel = new InstitutionClientManagerViewModel
                {
                    Project = new ProjectDisplayViewModel
                    {

                    }
                };

                resultModel.Project.Import(entity);

                resultModel.NotSelectedClients = notSelectedClients.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Identity.Name}"
                }).ToArray();

                resultModel.Clients = clients.Select(item =>
                {
                    var model = new InstitutionDisplayViewModel
                    {
                        InstitutionProjectLogicViewModel = new InstitutionClientDisplayViewModel
                        {
                            ProjectId = key,
                            InstitutionId = item.Id,
                            InstitutionName = $"{item.Identity.Name}"
                        }
                    };

                    model.Import(item);

                    return model;
                }).ToArray();

                return View(resultModel);
            }
            catch (Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/projectInstitutionClient/add")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstitutionClient(InstitutionClientInputViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProjectId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.InstitutionClientBridges.Add(new ProjectInstitutionClientBridge
                {
                    ProwId = entity.Id,
                    SternId = modelInput.InstitutionId,
                    Prow = entity,
                    Stern = institutionRepository.Get(modelInput.InstitutionId)
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

            return RedirectToAction("EditProjectInstitutionClient", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/projectInstitutionClient/remove")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveInstitutionClient(InstitutionClientDisplayViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProjectId);
            }
            catch (Exception)
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
                var brigde = entity.InstitutionClientBridges.FirstOrDefault(exp => exp.ProwId == modelInput.ProjectId && exp.SternId == modelInput.InstitutionId);

                entity.InstitutionClientBridges.Remove(brigde);

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

            return RedirectToAction("EditProjectInstitutionClient", new { key = entity.Id });
        }
        #endregion

        #region Impact
        [Route("edit/{key}/ProjectImpact")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult ProjectImpact(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);
                var projectImpacts = projectImpactRepository.GetAll().Where(p => p.ProjectId == key).ToList();
                var programExpectResults = programExpectResultRepository.GetAll().ToArray();
                var odsIndicators = odsIndicatorRepository.GetAll().ToArray();

                var projectImpactManagerModel = new ProjectImpactManagerViewModel
                {
                    Project = new ProjectDisplayViewModel()
                };
                projectImpactManagerModel.Project.Import(entity);
                projectImpactManagerModel.ProjectImpacts = projectImpacts;

                ViewBag.ImpactIndicator = impactIndicatorRepository.GetAll().Select(p => new SelectListItem 
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToArray();

                var selectedExpectResults = SelectedProgramExpectResult(projectImpacts);
                var notSelectedExpectResults = programExpectResults.Except(selectedExpectResults).ToArray();

                var selectedODSs = SelectedODSIndicator(projectImpacts);
                var notSelectedODSs = odsIndicators.Except(selectedODSs).ToArray();

                ViewBag.ProgramExpectResults = notSelectedExpectResults.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Title} - {p.Program.Name}"
                }).ToArray();

                ViewBag.ODSIndicators = notSelectedODSs.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Name}"
                }).ToArray();

                return View(projectImpactManagerModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ProgramExpectResult[] SelectedProgramExpectResult(List<ProjectImpact> projectImpacts)
        {
            var selectedProgramExpectResult = new List<ProgramExpectResult>();

            foreach (var projectImpact in projectImpacts)
            {
                foreach (var programExpectResultBridge in projectImpact.ProgramExpectResultBridges)
                {
                    var expectResult = programExpectResultBridge.Stern;
                    var exist = selectedProgramExpectResult.Any(p => p.Id == expectResult.Id);
                    if (!exist)
                    {
                        selectedProgramExpectResult.Add(expectResult);
                    }
                }
            }

            return selectedProgramExpectResult.ToArray();
        }

        private ODSIndicator[] SelectedODSIndicator(List<ProjectImpact> projectImpacts)
        {
            var selectedODSIndicator = new List<ODSIndicator>();

            foreach (var projectImpact in projectImpacts)
            {
                foreach (var ODSIndicatorBridge in projectImpact.ODSIndicatorBridges)
                {
                    var oDSIndicator = ODSIndicatorBridge.Stern;
                    var exist = selectedODSIndicator.Any(p => p.Id == oDSIndicator.Id);
                    if (!exist)
                    {
                        selectedODSIndicator.Add(oDSIndicator);
                    }
                }
            }

            return selectedODSIndicator.ToArray();
        }

        [Route("edit/{key}/ProjectImpact/add")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult AddProjectImpact(ProjectImpactInputViewModel modelInput)
        {
            var entity = Repository.Get(modelInput.ProjectId.Value);

            var indicator = impactIndicatorRepository.Get(modelInput.ImpactIndicatorId);

            if (ModelState.IsValid)
            {
                var projectImpact = new ProjectImpact
                {
                    ProjectId = entity.Id,
                    Project = entity,
                    IndicatorId = modelInput.ImpactIndicatorId,
                    Indicator = indicator,
                    Description = modelInput.Description
                };

                projectImpactRepository.Add(projectImpact, User.Identity.Name, false);

                Repository.Update(entity, User.Identity.Name, true);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetCreationSuccessMessage());
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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, "Agregar Impacto", messages.ToArray());
            }

            return RedirectToAction("ProjectImpact", new { key = entity.Id });
        }

        [Route("edit/{key}/ProjectImpact/delete")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult DeleteProjectImpact(ProjectImpactDisplayViewModel displayViewModel)
        {
            var projectImpact = projectImpactRepository.GetAll().FirstOrDefault(p => p.Id == displayViewModel.Id);
            var ProjectId = projectImpact.ProjectId;
            
            try
            {               
                
                projectImpactRepository.Delete(projectImpact, User.Identity.Name, true);
                               
                
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e) 
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());
            }            
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            return RedirectToAction("ProjectImpact", new { key = ProjectId });
        }

        [HttpPost]
        [Route("edit/ProjectImpact/addProjectImpactProgramExpectResult")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddProjectImpactProgramExpectResult(ProjectImpactProgramExpectResultInputViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;
            Persistence.Entities.ProjectImpact projectImpact = null;

            try
            {
                projectImpact = projectImpactRepository.Get(modelInput.ProjectImpactId);
                entity = Repository.Get((System.Guid)projectImpact.ProjectId);
            }
            catch { }

            if (projectImpact == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                projectImpact.ProgramExpectResultBridges.Add(new ProjectImpactProgramExpectResultBridge
                {
                    ProwId = projectImpact.Id,
                    SternId = modelInput.ProgramExpectResultId,
                    Prow = projectImpact,
                    Stern = programExpectResultRepository.Get(modelInput.ProgramExpectResultId)
                });

                projectImpactRepository.Update(projectImpact, User.Identity.Name);

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

            return RedirectToAction("ProjectImpact", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/ProjectImpact/addProjectImpactODSIndicator")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddProjectImpactODSIndicator(ProjectImpactODSIndicatorInputViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;
            Persistence.Entities.ProjectImpact projectImpact = null;

            try
            {
                projectImpact = projectImpactRepository.Get(modelInput.ProjectImpactId);
                entity = Repository.Get((System.Guid)projectImpact.ProjectId);
            }
            catch { }

            if (projectImpact == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                projectImpact.ODSIndicatorBridges.Add(new ProjectImpactODSIndicatorBridge
                {
                    ProwId = projectImpact.Id,
                    SternId = modelInput.ODSIndicatorId,
                    Prow = projectImpact,
                    Stern = odsIndicatorRepository.Get(modelInput.ODSIndicatorId)
                });

                projectImpactRepository.Update(projectImpact, User.Identity.Name);

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

            return RedirectToAction("ProjectImpact", new { key = entity.Id });
        }
        #endregion

        #region Participan        
        [HttpGet]
        [Route("edit/{key}/Participation")]
        [RequirePermissions(Permission.ProjectEditor)]
        public IActionResult EditProjectParticipan(Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var participans = entity.PersonParticipationBridges.Select(p => p.Stern).ToArray();

                var notSelectedParticipans = personRepository.GetAll().ToArray();

                if (participans.Count() != 0)
                {
                    notSelectedParticipans = notSelectedParticipans.Except(participans).ToArray();
                }

                var resultModel = new ProjectParticipanManagerViewModel
                {
                    Project = new ProjectDisplayViewModel()
                };

                resultModel.Project.Import(entity);

                resultModel.NotSelectedParticipans = notSelectedParticipans.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Identity.Name} {exp.Identity.LastName}"
                }).ToArray();

                resultModel.Participans = participans.Select(item =>
                {
                    var model = new PersonDisplayViewModel
                    {
                        ProjectParticipan = new ProjectParticipanDisplayViewModel
                        {
                            ProjectId = key,
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
            catch (Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/Participation/add")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddParticipans(ProjectParticipanInputViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProjectId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.PersonParticipationBridges.Add(new ProjectPersonParticipationBridge
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

            return RedirectToAction("EditProjectParticipan", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/Participation/remove")]
        [RequirePermissions(Permission.ProjectEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveParticipan(ProjectParticipanDisplayViewModel modelInput)
        {
            Persistence.Entities.Project entity = null;

            try
            {
                entity = Repository.Get(modelInput.ProjectId);
            }
            catch (Exception)
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
                var brigde = entity.PersonParticipationBridges.FirstOrDefault(exp => exp.ProwId == modelInput.ProjectId && exp.SternId == modelInput.PersonId);

                entity.PersonParticipationBridges.Remove(brigde);

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

            return RedirectToAction("EditProjectParticipan", new { key = entity.Id });
        }
        #endregion

        #region OutputKinds
        [Route("edit/{key}/ProjectOutputKinds")]
        [RequirePermissions(Permission.ProjectEditor)]
        public IActionResult ProjectOutputKinds(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);                
                var projectOutputs = projectOutputRepository.GetAll().Where(p => p.ProjectId == key).ToList();
                var outputKinds = outputKindRepository.GetAll().ToArray();

                var projectOuputManagerModel = new ProjectOutputManagerViewModel
                {
                    Project = new ProjectDisplayViewModel()
                };
                projectOuputManagerModel.Project.Import(entity);
                projectOuputManagerModel.ProjectOuputs = projectOutputs;

                

                var selectedOutputKinds = SelectedOutputKind(projectOutputs);
                var notSelectedOutputKinds = outputKinds.Except(selectedOutputKinds).ToArray();
                                

                ViewBag.OutputKinds = notSelectedOutputKinds.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Name}"
                }).ToArray();

                

                return View(projectOuputManagerModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private OutputKind[] SelectedOutputKind(List<ProjectOutput> projectOutputs)
        {
            var selectedOutputKinds = new List<OutputKind>();

            foreach (var projectOutput in projectOutputs)
            {
                var outputKind = projectOutput.Kind;
                selectedOutputKinds.Add(outputKind);
            }

            return selectedOutputKinds.ToArray();
        }

        [Route("edit/{key}/ProjectOutputKinds/add")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult AddProjectOutputKinds(ProjectOutputInputViewModel modelInput)
        {
            var key = (System.Guid)modelInput.ProjectId;

            var project = Repository.Get(key);

            var outputKind = outputKindRepository.Get(modelInput.OutputKindId);
            try
            {
                if (key != System.Guid.Empty && project != null && outputKind != null)
                {
                    var entity = Repository.Get(key);

                    var projectOutput = new ProjectOutput
                    {
                        ProjectId = key,
                        Project = project,
                        KindId = modelInput.OutputKindId,
                        Kind = outputKind,
                        Description = modelInput.Description
                    };

                    projectOutputRepository.Add(projectOutput, User.Identity.Name, false);

                    Repository.Update(entity, User.Identity.Name, true);

                    SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetCreationSuccessMessage());
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

                    SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, messages.ToArray());
                }
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("ProjectOutputKinds", new { key = project.Id });
        }

        [Route("edit/{key}/ProjectOutputKinds/delete")]
        [RequirePermissions(Permission.ProjectViewer)]
        public IActionResult DeleteProjectOutputKinds(ProjectOutputDisplayViewModel displayViewModel)
        {
            var projectOutput = projectOutputRepository.GetAll().FirstOrDefault(p => p.Id == displayViewModel.Id);
            var ProjectId = projectOutput.ProjectId;

            try
            {

                projectOutputRepository.Delete(projectOutput, User.Identity.Name, true);


            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            return RedirectToAction("ProjectOutputKinds", new { key = ProjectId });
        }


        #endregion
    }
}
