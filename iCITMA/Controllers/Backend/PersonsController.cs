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
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System;
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
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<State, System.Guid> stateRepository;
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<PhoneContactItem, System.Guid> phoneContactItemRepository;
        private readonly IEntityRepository<EmailContactItem, System.Guid> emailContactItemRepository;
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactItemRepository;
        private readonly IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactItemRepository;

        public PersonsController(IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactItemRepository, IEntityRepository<PostalContactItem, System.Guid> postalContactItemRepository, IEntityRepository<EmailContactItem, System.Guid> emailContactItemRepository, IEntityRepository<PhoneContactItem, System.Guid> phoneContactItemRepository, IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository, IEntityRepository<State, System.Guid> stateRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<ResearchArea, System.Guid> researchAreaRepository, IEntityRepository<Institution, System.Guid> institutionsRepository, IEntityRepository<PersonIdentity, System.Guid> identityRepository, IEntityRepository<Image, System.Guid> imageRepository, IImageFileManagerFacade imageFileManagerFacade, IEntityRepository<TeachingCategory, System.Guid> TeachingCategoryRepository, IEntityRepository<ResearcherCategory, System.Guid> ResearcherCategoryRepository, IEntityRepository<Person, System.Guid> repository, IStringLocalizer<PersonsController> localizer, ILogger<PersonsController> logger) : base(repository, localizer, logger)
        {
            this.ResearcherCategoryRepository = ResearcherCategoryRepository;
            this.TeachingCategoryRepository = TeachingCategoryRepository;
            this.imageFileManagerFacade = imageFileManagerFacade;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
            this.institutionsRepository = institutionsRepository;
            this.researchAreaRepository = researchAreaRepository;
            this.stateRepository = stateRepository;
            this.municipalityRepository = municipalityRepository;
            this.municipalityLocationRepository = municipalityLocationRepository;
            this.phoneContactItemRepository = phoneContactItemRepository;
            this.emailContactItemRepository = emailContactItemRepository;
            this.postalContactItemRepository = postalContactItemRepository;
            this.webSiteContactItemRepository = webSiteContactItemRepository;
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

        #region Contacts

        [Route("edit/{key}/contacts")]
        [RequirePermissions(Permission.InstitusionViewer)]
        public IActionResult ManageContacts(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var model = new PersonContactsManageViewModel
                {
                    Person = new PersonDisplayViewModel(),
                    PhoneContacts = entity.Identity.PhoneContactItemBridges.Select(bridge => new PhoneContactDisplayViewModel
                    {
                        Id = bridge.Stern.Id,
                        Label = bridge.Stern.Label,
                        Number = bridge.Stern.PhoneNumber
                    }).ToList(),
                    EmailContacts = entity.Identity.EmailContactItemBridges.Select(bridge => new EmailContactDisplayViewModel
                    {
                        Id = bridge.Stern.Id,
                        Label = bridge.Stern.Label,
                        Email = bridge.Stern.EmailAddress
                    }).ToList(),
                    WebContacts = entity.Identity.WebSiteContactItemBridges.Select(bridge => new WebContactDisplayViewModel
                    {
                        Id = bridge.SternId,
                        Label = bridge.Stern.Label,
                        Url = bridge.Stern.Url
                    }).ToList(),
                    AddressContacts = entity.Identity.PostalContactItemBridges.Select(bridge => new PostalContactDisplayViewModel
                    {
                        Id = bridge.SternId,
                        Label = bridge.Stern.Label,
                        Address = bridge.Stern.Address,
                        Longitude = bridge.Stern.Longitude,
                        Latitude = bridge.Stern.Latitude,
                        ZipCode = bridge.Stern.ZipCode,
                        Municipality = ((MunicipalityLocation)bridge.Stern.Location).Municipality.Name,
                        State = ((MunicipalityLocation)bridge.Stern.Location).Municipality.State.Name
                    }).ToList(),
                    StateSelectListItems = stateRepository.GetAll().Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Name }).ToArray()
                };

                if (model.StateSelectListItems.Length > 0)
                {
                    var firstStateId = System.Guid.Parse(model.StateSelectListItems[0].Value);

                    model.MunicipalitySelectListItems = municipalityRepository.FindBy(entity => entity.StateId == firstStateId).Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Name }).ToArray();
                }
                else
                {
                    model.MunicipalitySelectListItems = System.Array.Empty<SelectListItem>();
                }

                model.Person.Import(entity);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        #region Phones

        [Route("edit/contacts/phone/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPhoneContact(PhoneContactInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.ContextId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var contactItem = new PhoneContactItem { Label = modelInput.Label, PhoneNumber = modelInput.Number };

                phoneContactItemRepository.Add(contactItem, User.Identity.Name, false);

                var bridge = new PersonPhoneContactItemBridge
                {
                    Prow = entity.Identity,
                    ProwId = entity.Identity.Id,
                    Stern = contactItem,
                    SternId = contactItem.Id
                };

                entity.Identity.PhoneContactItemBridges.Add(bridge);

                identityRepository.Update(entity.Identity, User.Identity.Name);

                SetDefaultNotification(NotificationType.Success, GetCreationSuccessMessage());
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

                SetDefaultNotification(NotificationType.Danger, title: "Agregar Teléfono", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/{key}/contacts/phone/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePhoneContact(System.Guid key, System.Guid contactId)
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

            try
            {
                var bridge = entity.Identity.PhoneContactItemBridges.FirstOrDefault(b => b.ProwId == entity.IdentityId && b.SternId == contactId);

                entity.Identity.PhoneContactItemBridges.Remove(bridge);

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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Emails

        [Route("edit/contacts/email/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmailContact(EmailContactInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.ContextId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var emailContactItem = new EmailContactItem { Label = modelInput.Label, EmailAddress = modelInput.Address };
                
                emailContactItemRepository.Add(emailContactItem, User.Identity.Name, false);

                entity.Identity.EmailContactItemBridges.Add(new PersonEmailContactItemBridge { ProwId = entity.IdentityId.Value, Stern = emailContactItem, SternId = emailContactItem.Id });

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(NotificationType.Success, GetCreationSuccessMessage());
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

                SetDefaultNotification(NotificationType.Danger, title: "Agregar Correo Electrónico", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/{key}/contacts/email/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmailContact(System.Guid key, System.Guid contactId)
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

            try
            {
                var bridge = entity.Identity.EmailContactItemBridges.First(b => b.ProwId == entity.IdentityId && b.SternId == contactId);

                entity.Identity.EmailContactItemBridges.Remove(bridge);

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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Postal

        [Route("edit/contacts/postal/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPostalContact(PostalContactInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.ContextId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var municipality = municipalityRepository.Get(modelInput.MunicipalityId);

                var municipalityLocaction = municipalityLocationRepository.GetAll().FirstOrDefault(m => m.MunicipalityId == modelInput.MunicipalityId);

                if (municipalityLocaction == null)
                {
                    municipalityLocaction = new MunicipalityLocation
                    {
                        MunicipalityId = modelInput.MunicipalityId,
                        Municipality = municipality
                    };

                    municipalityLocationRepository.Add(municipalityLocaction, User.Identity.Name, false);
                }

                var postalContactItem = new PostalContactItem
                {
                    Label = modelInput.Label,
                    Address = modelInput.Address,
                    Latitude = modelInput.Latitude ?? 0,
                    Longitude = modelInput.Longitude ?? 0,
                    LocationId = municipalityLocaction.Id,
                    ZipCode = modelInput.ZipCode ?? 0
                };

                postalContactItemRepository.Add(postalContactItem, User.Identity.Name, false);

                entity.Identity.PostalContactItemBridges.Add(new PersonPostalContactItemBridge
                {
                    ProwId = entity.IdentityId.Value,
                    Stern = postalContactItem,
                    SternId = modelInput.Id
                });

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(NotificationType.Success, GetCreationSuccessMessage());
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

                SetDefaultNotification(NotificationType.Danger, title: "Agregar Dirección Postal", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/{key}/contacts/postal/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostalContact(System.Guid key, System.Guid contactId)
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

            try
            {
                var bridge = entity.Identity.PostalContactItemBridges.First(b => b.ProwId == entity.IdentityId && b.SternId == contactId);

                entity.Identity.PostalContactItemBridges.Remove(bridge);

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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Web

        [Route("edit/contacts/web/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWebContact(WebContactInputViewModel modelInput)
        {
            Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.ContextId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var webSiteContactItem = new WebSiteContactItem { Url = modelInput.Url, Label = modelInput.Label };

                webSiteContactItemRepository.Add(webSiteContactItem, User.Identity.Name, false);

                entity.Identity.WebSiteContactItemBridges.Add(new PersonWebSiteContactItemBridge
                {
                    ProwId = entity.IdentityId.Value,
                    Prow = entity.Identity,
                    Stern = webSiteContactItem,
                    SternId = modelInput.Id
                });

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(NotificationType.Success, GetCreationSuccessMessage());
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

                SetDefaultNotification(NotificationType.Danger, title: "Agregar Web Social", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/{key}/contacts/web/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteWebContact(System.Guid key, System.Guid contactId)
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

            try
            {
                var bridge = entity.Identity.WebSiteContactItemBridges.First(b => b.ProwId == entity.IdentityId && b.SternId == contactId);

                entity.Identity.WebSiteContactItemBridges.Remove(bridge);

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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #endregion

        #region Institutions

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

        #endregion

        #region Specializations

        [HttpGet]
        [Route("edit/{key}/personSpecializations")]
        [RequirePermissions(Permission.PersonEditor)]
        public IActionResult EditPersonSpecializations(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var specializations = entity.ResearchAreaSpecializationBridges.Select(p => p.Stern).ToArray();

                var notSelectedSpecialization = researchAreaRepository.GetAll().ToArray();

                if (specializations.Count() != 0)
                {
                    notSelectedSpecialization = notSelectedSpecialization.Except(specializations).ToArray();
                }

                var resultModel = new PersonSpecializationsManagerViewModel
                {
                    Person = new PersonDisplayViewModel
                    {

                    }
                };

                resultModel.Person.Import(entity);

                resultModel.NotSelectedSpecializations = notSelectedSpecialization.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Name}"
                }).ToArray();

                resultModel.Specializations = specializations.Select(item =>
                {
                    var model = new ResearchAreaDisplayViewModel
                    {
                        PersonMasteryLogicViewModel = new PersonMasteryLogicViewModel
                        {
                            PersonId = key,
                            ResearchAreaId = item.Id,
                            ResearchAreaName = $"{item.Name}"
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
        [Route("edit/personSpecializations/add")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonSpecializations(PersonSpecializationInputViewModel modelInput)
        {
            Persistence.Entities.Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.PersonId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.ResearchAreaSpecializationBridges.Add(new PersonResearchAreaSpecializationBridge
                {
                    ProwId = entity.Id,
                    SternId = modelInput.ResearchAreaId,
                    Prow = entity,
                    Stern = researchAreaRepository.Get(modelInput.ResearchAreaId)
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

            return RedirectToAction("EditPersonSpecializations", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/{key}/personSpecializations/remove")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePersonSpecializations(System.Guid key, System.Guid ResearchAreaId)
        {
            Persistence.Entities.Person entity = null;

            try
            {
                entity = Repository.Get(key);
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
                var brigde = entity.ResearchAreaSpecializationBridges.FirstOrDefault(exp => exp.SternId == ResearchAreaId);

                entity.ResearchAreaSpecializationBridges.Remove(brigde);

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

            return RedirectToAction("EditPersonSpecializations", new { key = entity.Id });
        }

        #endregion

        #region Masterys

        [HttpGet]
        [Route("edit/{key}/personMasterys")]
        [RequirePermissions(Permission.PersonEditor)]
        public IActionResult EditPersonMasterys(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var masterys = entity.ResearchAreaMasteryBridges.Select(p => p.Stern).ToArray();

                var notSelectedMasterys = researchAreaRepository.GetAll().ToArray();

                if (masterys.Count() != 0)
                {
                    notSelectedMasterys = notSelectedMasterys.Except(masterys).ToArray();
                }

                var resultModel = new PersonMasteryManagerViewModel
                {
                    Person = new PersonDisplayViewModel
                    {

                    }
                };

                resultModel.Person.Import(entity);

                resultModel.NotSelectedMasterys = notSelectedMasterys.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Name}"
                }).ToArray();

                resultModel.Masterys = masterys.Select(item =>
                {
                    var model = new ResearchAreaDisplayViewModel
                    {
                        PersonMasteryLogicViewModel = new PersonMasteryLogicViewModel
                        {
                            PersonId = key,
                            ResearchAreaId = item.Id,
                            ResearchAreaName = $"{item.Name}"
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
        [Route("edit/personMasterys/add")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonMasterys(PersonMasteryInputViewModel modelInput)
        {
            Persistence.Entities.Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.PersonId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.ResearchAreaMasteryBridges.Add(new PersonResearchAreaMasteryBridge
                {
                    ProwId = entity.Id,
                    SternId = modelInput.ResearchAreaId,
                    Prow = entity,
                    Stern = researchAreaRepository.Get(modelInput.ResearchAreaId)
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

            return RedirectToAction("EditPersonMasterys", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/{key}/personMasterys/remove")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePersonMasterysn(System.Guid key, System.Guid ResearchAreaId)
        {
            Persistence.Entities.Person entity = null;

            try
            {
                entity = Repository.Get(key);
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
                var brigde = entity.ResearchAreaMasteryBridges.FirstOrDefault( exp => exp.SternId == ResearchAreaId);

                entity.ResearchAreaMasteryBridges.Remove(brigde);

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

            return RedirectToAction("EditPersonMasterys", new { key = entity.Id });
        }

        #endregion

        #region Doctorates

        [HttpGet]
        [Route("edit/{key}/personDoctorates")]
        [RequirePermissions(Permission.PersonEditor)]
        public IActionResult EditPersonDoctorates(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var doctorates = entity.ResearchAreaDoctorateBridges.Select(p => p.Stern).ToArray();

                var notSelectedDoctorates = researchAreaRepository.GetAll().ToArray();

                if (doctorates.Count() != 0)
                {
                    notSelectedDoctorates = notSelectedDoctorates.Except(doctorates).ToArray();
                }

                var resultModel = new PersonDoctorateManagerViewModel
                {
                    Person = new PersonDisplayViewModel
                    {

                    }
                };

                resultModel.Person.Import(entity);

                resultModel.NotSelectedDoctorates = notSelectedDoctorates.Select(exp => new SelectListItem
                {
                    Value = exp.Id.ToString(),
                    Text = $"{exp.Name}"
                }).ToArray();

                resultModel.Doctorates = doctorates.Select(item =>
                {
                    var model = new ResearchAreaDisplayViewModel
                    {
                        PersonMasteryLogicViewModel = new PersonMasteryLogicViewModel
                        {
                            PersonId = key,
                            ResearchAreaId = item.Id,
                            ResearchAreaName = $"{item.Name}"
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
        [Route("edit/personDoctorates/add")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonDoctorates(PersonDoctorateInputViewModel modelInput)
        {
            Persistence.Entities.Person entity = null;

            try
            {
                entity = Repository.Get(modelInput.PersonId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                entity.ResearchAreaDoctorateBridges.Add(new PersonResearchAreaDoctorateBridge
                {
                    ProwId = entity.Id,
                    SternId = modelInput.ResearchAreaId,
                    Prow = entity,
                    Stern = researchAreaRepository.Get(modelInput.ResearchAreaId)
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

            return RedirectToAction("EditPersonDoctorates", new { key = entity.Id });
        }

        [HttpPost]
        [Route("edit/{key}/personDoctorates/remove")]
        [RequirePermissions(Permission.PersonEditor)]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePersonDoctorates(System.Guid key, System.Guid ResearchAreaId)
        {
            Persistence.Entities.Person entity = null;

            try
            {
                entity = Repository.Get(key);
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
                var brigde = entity.ResearchAreaDoctorateBridges.FirstOrDefault(exp => exp.SternId == ResearchAreaId);

                entity.ResearchAreaDoctorateBridges.Remove(brigde);

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

            return RedirectToAction("EditPersonDoctorates", new { key = entity.Id });
        }

        #endregion
    }
}
