using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Controllers;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Auxiliares")]
    public class ProjectsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Project , System.Guid, ProjectInputViewModel, ProjectDisplayViewModel>
    {
        public readonly IEntityRepository<Person, System.Guid> leaderRepository;
        public readonly IEntityRepository<ProjectCategory, System.Guid> categoryRepository;
        public readonly IEntityRepository<Institution, System.Guid> managerRepository;
        public readonly IEntityRepository<Persistence.Entities.Program, System.Guid> programRepository;
        public readonly IEntityRepository<ProjectState, System.Guid> projectStateRepository;
        public readonly IEntityRepository<ProgramExpectResult, System.Guid> programExpectResultRepository;
        public ProjectsController(IEntityRepository<ProgramExpectResult, System.Guid> programExpectResultRepository, IEntityRepository<ProjectState, System.Guid> projectStateRepository, IEntityRepository<Persistence.Entities.Program, System.Guid> programRepository, IEntityRepository<Institution, System.Guid> managerRepository, IEntityRepository<ProjectCategory, System.Guid> categoryRepository, IEntityRepository<Person, System.Guid> leaderRepository, IEntityRepository<Project, Guid> repository, IStringLocalizer<ProjectsController> localizer, ILogger<ProjectsController> logger) : base(repository, localizer, logger)
        {
            this.leaderRepository = leaderRepository;
            this.categoryRepository = categoryRepository;
            this.managerRepository = managerRepository;
            this.programRepository = programRepository;
            this.projectStateRepository = projectStateRepository;
            this.programExpectResultRepository = programExpectResultRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [RequirePermissions(Permission.ProjectCreator)]
        public override IActionResult Create() => base.Create();

        [RequirePermissions(Permission.ProjectEditor)]
        public override IActionResult Create(ProjectInputViewModel modelInput) =>  base.Create(modelInput);

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

        private void PopulateCategory(ProjectInputViewModel modelInput)
        {
            modelInput.CategorySelected = categoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToArray();   
        }

        private void PopulateManager(ProjectInputViewModel modelInput)
        {
            modelInput.ManagerSelected = managerRepository.GetAll().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Identity.Name
            }).ToArray();
        }

        private void PopulateLeader(ProjectInputViewModel modelInput)
        {
            modelInput.LeaderSelected = leaderRepository.GetAll().Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = $"{l.Identity.Name} {l.Identity.LastName}"
            }).ToArray();
        }

        private void PopulateProgram(ProjectInputViewModel modelInput)
        {
            modelInput.ProgramSelected = programRepository.GetAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToArray();
        }

        private void PopulateProjectState(ProjectInputViewModel modelInput)
        {
            modelInput.ProjectStateSelected = projectStateRepository.GetAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToArray();
        }

        protected override void PreCreate(Project entity, ProjectInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            PopulateCategory(modelInput);
            PopulateManager(modelInput);
            PopulateLeader(modelInput);
            PopulateProgram(modelInput);
            PopulateProjectState(modelInput);

        }

        protected override void ConfigureCreate(ProjectInputViewModel modelInput)
        {
            base.ConfigureCreate(modelInput);

            PopulateCategory(modelInput);
            PopulateManager(modelInput);
            PopulateLeader(modelInput);
            PopulateProgram(modelInput);
            PopulateProjectState(modelInput);
        }



        protected override void ConfigurePostFailCreateValidation(ProjectInputViewModel modelInput)
        {
            base.ConfigurePostFailCreateValidation(modelInput);           

            PopulateCategory(modelInput);
            PopulateManager(modelInput);
            PopulateLeader(modelInput);
            PopulateProgram(modelInput);
            PopulateProjectState(modelInput);
        }

        protected override void ConfigureEdit(Project entity, ProjectInputViewModel modelInput)
        {
            base.ConfigureEdit(entity, modelInput);

            PopulateCategory(modelInput);
            PopulateManager(modelInput);
            PopulateLeader(modelInput);
            PopulateProgram(modelInput);
            PopulateProjectState(modelInput);
        }

        protected override void PostCreate(Project entity, ProjectInputViewModel modelInput)
        {
            base.PostCreate(entity, modelInput);
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
        public IActionResult DeleteExpectResult(System.Guid key)
        {
            return View();
        }
        #endregion
    }
}
