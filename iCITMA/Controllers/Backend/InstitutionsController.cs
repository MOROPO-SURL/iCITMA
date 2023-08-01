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
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("ecosystem")]
    public class InstitutionsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Institution, System.Guid, InstitutionInputViewModel, InstitutionDisplayViewModel>
    {
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<OrganizationIdentity, System.Guid> identityRepository;
        private readonly IEntityRepository<PhoneContactItem, System.Guid> phoneContactItemRepository;
        private readonly IEntityRepository<EmailContactItem, System.Guid> emailContactItemRepository;
        private readonly IEntityRepository<SocialContactItem, System.Guid> socialContactItemRepository;
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactItemRepository;
        private readonly IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactItemRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<State, System.Guid> stateRepository;
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<Location, System.Guid> locationRepository;
        private readonly IEntityRepository<StateLocation, System.Guid> stateLocationRepository;        
        private readonly IEntityRepository<Person, System.Guid> personRepository;        

        public InstitutionsController(IEntityRepository<Institution, System.Guid> repository,
            IStringLocalizer<InstitutionsController> localizer,
            ILogger<InstitutionsController> logger,
            IImageFileManagerFacade imageFileManagerFacade,
            IEntityRepository<Image, System.Guid> imageRepository,
            IEntityRepository<OrganizationIdentity, System.Guid> identityRepository,
            IEntityRepository<PhoneContactItem, System.Guid> phoneContactItemRepository,
            IEntityRepository<EmailContactItem, System.Guid> emailContactItemRepository,
            IEntityRepository<SocialContactItem, System.Guid> socialContactItemRepository,
            IEntityRepository<PostalContactItem, System.Guid> postalContactItemRepository,
            IEntityRepository<WebSiteContactItem, System.Guid> webSiteContactItemRepository,
            IEntityRepository<Municipality, System.Guid> municipalityRepository,
            IEntityRepository<State, System.Guid> stateRepository,
            IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository,
            IEntityRepository<Location, System.Guid> locationRepository,
            IEntityRepository<StateLocation, System.Guid> stateLocationRepository,
            IEntityRepository<Person, System.Guid> personRepository
            ) : base(repository, localizer, logger)
        {
            this.imageFileManager = imageFileManagerFacade;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
            this.phoneContactItemRepository = phoneContactItemRepository;
            this.emailContactItemRepository = emailContactItemRepository;
            this.socialContactItemRepository = socialContactItemRepository;
            this.postalContactItemRepository = postalContactItemRepository;
            this.webSiteContactItemRepository = webSiteContactItemRepository;
            this.municipalityRepository = municipalityRepository;
            this.stateRepository = stateRepository;
            this.municipalityLocationRepository = municipalityLocationRepository;
            this.locationRepository = locationRepository;
            this.stateLocationRepository = stateLocationRepository;
            this.personRepository = personRepository;
        }

        [RequirePermissions(Permission.InstitusionViewer)]
        public IActionResult Index() => View();        
       

        [RequirePermissions(Permission.InstitusionCreator)]
        public override IActionResult Create() => base.Create();


        [RequirePermissions(Permission.InstitusionCreator)]
        public override IActionResult Create(InstitutionInputViewModel inputViewModel) 
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

        [RequirePermissions(Permission.InstitusionEditor)]
        public override IActionResult Edit(System.Guid key) => base.Edit(key);

        [RequirePermissions(Permission.InstitusionEditor)]
        public override IActionResult Edit(InstitutionInputViewModel inputViewModel) 
        {
            ModelState.ClearValidationState("ImageFile");
            ModelState.MarkFieldValid("ImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    inputViewModel.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(inputViewModel);

                    updateModelTask.Wait();

                }
            }
            return base.Edit(inputViewModel); 
        }
      

        [RequirePermissions(Permission.InstitusionRemover)]
        public override IActionResult Delete(System.Guid key) => base.Delete(key);

        [RequirePermissions(Permission.InstitusionRemover)]
        public override IActionResult Delete(InstitutionDisplayViewModel displayViewModel) => base.Delete(displayViewModel);

        [Route("edit/{key}/PopulateStateToMunicipality/{stateId}")]
        [HttpGet("PopulateStateToMunicipality/{stateId}")]
        public IActionResult PopulateStateToMunicipality(string stateId)
        {
            var stateIdParse = System.Guid.Parse(stateId);

            var municipalities = municipalityRepository.GetAll().Where(entity => entity.StateId == stateIdParse).ToList();
            
            return Ok(municipalities);
        }

        private void Populate(InstitutionInputViewModel inputViewModel)
        {
            inputViewModel.PersonSelectedListItems = personRepository.GetAll().Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Identity.LastName != null ? string.Format("{0} {1}", entity.Identity.Name, entity.Identity.LastName) : entity.Identity.Name }).ToArray();
            inputViewModel.OwnerSelectedListItems = Repository.GetAll().Where(entity => entity.Owner == null && entity.Id != inputViewModel.Id).Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Identity.Name }).ToArray();
        }

        protected override void ConfigureCreate(InstitutionInputViewModel modelInput)
        {
            base.ConfigureCreate(modelInput);
            
            Populate(modelInput);
        }

        protected override void ConfigurePostFailCreateValidation(InstitutionInputViewModel modelInput)
        {
            base.ConfigurePostFailCreateValidation(modelInput);

            Populate(modelInput);
        }

        protected override void ConfigureEdit(Institution entity, InstitutionInputViewModel modelInput)
        {
            base.ConfigureEdit(entity, modelInput);
            
            Populate(modelInput);
        }

        protected override void ConfigurePostFailEditValidation(Institution entity, InstitutionInputViewModel modelInput)
        {
            base.ConfigurePostFailEditValidation(entity, modelInput);

            Populate(modelInput);
        }

        protected override void PreCreate(Institution entity, InstitutionInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            if (modelInput.OwnerId != null)
            {
                entity.OwnerId = modelInput.OwnerId;
                entity.Owner = Repository.Get(modelInput.OwnerId.Value);
            }

            if (modelInput.RepresentativeId != null)
            {
                entity.RepresentativeId = modelInput.RepresentativeId;
                entity.Representative = personRepository.Get(modelInput.RepresentativeId.Value);
            }

            if (modelInput.ImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.ImageFile.CopyTo(memoryStream);

                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Institution " + entity.Id };

                imageFileManager.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                entity.Identity.Image = image;
            }
        }

        protected override void PreEdit(Institution entity, InstitutionInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            if (entity.OwnerId != modelInput.OwnerId)
            {
                if (modelInput.OwnerId == null)
                {
                    entity.OwnerId = null;
                    entity.Owner = null;
                }
                else
                {
                    entity.OwnerId = modelInput.OwnerId;
                    entity.Owner = Repository.Get(modelInput.OwnerId.Value);
                }
            }

            if (entity.RepresentativeId != modelInput.RepresentativeId)
            {
                if (modelInput.RepresentativeId == null)
                {
                    entity.RepresentativeId = null;
                    entity.Representative = null;
                }
                else
                {
                    entity.RepresentativeId = modelInput.RepresentativeId;
                    entity.Representative = personRepository.Get(modelInput.RepresentativeId.Value);
                }
            }

            if (modelInput.ImageFile == null)
            {
                if(modelInput.ResetImage && entity.Identity.Image != null)
                {
                    imageFileManager.DeleteImageFile(entity.Identity.Image);
                    imageRepository.Delete(entity.Identity.Image, User.Identity.Name);
                }
                return;
            }

            if (entity.Identity.Image != null)
            {
                imageFileManager.DeleteImageFile(entity.Identity.Image);

                imageRepository.Delete(entity.Identity.Image, User.Identity.Name);
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.ImageFile.CopyTo(memoryStream);

                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Institution " + entity.Id };

                imageFileManager.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                entity.Identity.Image = image;

                imageRepository.Add(image, User.Identity.Name);
            }
        }        

        protected override void PostDelete(Institution entity)
        {
            base.PostDelete(entity);

            identityRepository.Delete(entity.Identity, User.Identity.Name);

            if (entity.Identity.Image == null) return;

            imageRepository.Delete(entity.Identity.Image, User.Identity.Name);

            imageFileManager.DeleteImageFile(entity.Identity.Image);
        }

        #region Contacts

        [Route("edit/{key}/contacts")]
        [RequirePermissions(Permission.InstitusionViewer)]
        public IActionResult ManageContacts(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var resultModel = new InstitutionContactsManageViewModel
                {
                    Institution = new InstitutionDisplayViewModel(),
                    PhoneContacts = entity.Identity.PhoneContactItemBridges.Select(bridge => new InstitutionPhoneContactDisplayViewModel
                    {
                        Id = bridge.Stern.Id,
                        Label = bridge.Stern.Label,
                        Number = bridge.Stern.PhoneNumber,
                        InstitutionId = entity.Id
                    }).ToList(),
                    EmailContacts = entity.Identity.EmailContactItemBridges.Select(bridge => new InstitutionEmailContactDisplayViewModel
                    {
                        Id = bridge.Stern.Id,
                        Label = bridge.Stern.Label,
                        Email = bridge.Stern.EmailAddress,
                        InstitutionId = entity.Id
                    }).ToList(),
                    WebContacts = entity.Identity.WebSiteContactItemBridges.Select( bridge => new InstitutionWebContactDisplayViewModel
                    {
                        Id = bridge.SternId,
                        Label= bridge.Stern.Label,
                        Url = bridge.Stern.Url,                        
                        InstitutionId = entity.Id,
                    }).ToList(),
                    AddressContacts = entity.Identity.PostalContactItemBridges.Select(bridge => new InstitutionPostalContactDisplayViewModel 
                    { 
                        Id = bridge.SternId,
                        Label = bridge.Stern.Label,
                        Address = bridge.Stern.Address,
                        Longitude = bridge.Stern.Longitude,
                        Latitude = bridge.Stern.Latitude,
                        ZipCode = bridge.Stern.ZipCode,
                        InstitutionId = entity.Id,
                        Municipality = ((MunicipalityLocation)bridge.Stern.Location).Municipality,
                        State = ((MunicipalityLocation)bridge.Stern.Location).Municipality.State
                    }).ToList()
                };

                PopulateStateWithMunicipality(resultModel);

                resultModel.Institution.Import(entity);

                return View(resultModel);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(MOROPO.Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        #region Phones

        [Route("edit/contacts/phone/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPhoneContact(InstitutionPhoneContactInputViewModel modelInput)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelInput.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var PhoneContactItem = new PhoneContactItem { Label = modelInput.Label, PhoneNumber = modelInput.Number };
                
                phoneContactItemRepository.Add(PhoneContactItem, User.Identity.Name, false);
               
                var OrganizationPhoneContactItemBridge = new OrganizationPhoneContactItemBridge
                {
                    Prow = entity.Identity,
                    ProwId = entity.Identity.Id,
                    Stern = PhoneContactItem,
                    SternId =PhoneContactItem.Id
                };

                entity.Identity.PhoneContactItemBridges.Add(OrganizationPhoneContactItemBridge);

                identityRepository.Update(entity.Identity, User.Identity.Name);

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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, title: "Agregar Teléfono", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/contacts/phone/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePhoneContact(InstitutionPhoneContactDisplayViewModel modelDisplay)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelDisplay.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            try
            {
                var bridge = entity.Identity.PhoneContactItemBridges.FirstOrDefault(b => b.ProwId == entity.IdentityId && b.SternId == modelDisplay.Id);

                entity.Identity.PhoneContactItemBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetDeletionSuccessMessage());
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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Emails

        [Route("edit/contacts/email/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmailContact(InstitutionEmailContactInputViewModel modelInput)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelInput.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var emailContactItem = new EmailContactItem { Label = modelInput.Label, EmailAddress = modelInput.Address };
                emailContactItemRepository.Add(emailContactItem, User.Identity.Name, false);

                entity.Identity.EmailContactItemBridges.Add(new OrganizationEmailContactItemBridge { ProwId = entity.IdentityId.Value, Stern = emailContactItem , SternId = emailContactItem.Id});

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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, title: "Agregar Correo Electrónico", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/contacts/email/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmailContact(InstitutionEmailContactDisplayViewModel modelDisplay)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelDisplay.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            try
            {
                var bridge = entity.Identity.EmailContactItemBridges.First(b =>b.ProwId == entity.IdentityId && b.SternId == modelDisplay.Id);

                entity.Identity.EmailContactItemBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetDeletionSuccessMessage());
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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Social

        [Route("edit/contacts/social/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSocialContact(InstitutionSocialContactInputViewModel modelInput)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelInput.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var socialContactItem = new SocialContactItem { Label = modelInput.Label, SocialId = modelInput.SocialId };
                socialContactItemRepository.Add(socialContactItem, User.Identity.Name, false);

                entity.Identity.SocialContactItemBridges.Add(new OrganizationSocialContactItemBridge { ProwId = entity.IdentityId.Value, Stern = socialContactItem, SternId = modelInput.Id });

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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/contacts/social/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSocialContact(InstitusionSocialContactDisplayViewModel modelDisplay)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelDisplay.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            try
            {
                var bridge = entity.Identity.SocialContactItemBridges.First(b => b.ProwId == entity.IdentityId && b.SternId == modelDisplay.Id);

                entity.Identity.SocialContactItemBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetDeletionSuccessMessage());
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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Postal

        [Route("edit/contacts/postal/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPostalAddress(InstitutionPostalContactInputViewModel modelInput)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelInput.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

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

                entity.Identity.PostalContactItemBridges.Add(new OrganizationPostalContactItemBridge 
                { 
                    ProwId = entity.IdentityId.Value, 
                    Stern = postalContactItem, 
                    SternId = modelInput.Id 
                });

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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, title: "Agregar Dirección Postal", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/contacts/postal/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostalAddress(InstitutionPostalContactDisplayViewModel modelDisplay)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelDisplay.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            try
            {
                var bridge = entity.Identity.PostalContactItemBridges.First(b => b.ProwId == entity.IdentityId && b.SternId == modelDisplay.Id);

                entity.Identity.PostalContactItemBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetDeletionSuccessMessage());
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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #region Web

        [Route("edit/contacts/web/add")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWeb(InstitutionWebContactInputViewModel modelInput)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelInput.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var webSiteContactItem = new WebSiteContactItem { Url = modelInput.Url, Label = modelInput.Label };
                
                webSiteContactItemRepository.Add(webSiteContactItem, User.Identity.Name, false);

                entity.Identity.WebSiteContactItemBridges.Add(new OrganizationWebSiteContactItemBridge
                {
                    ProwId = entity.IdentityId.Value,
                    Prow = entity.Identity,
                    Stern = webSiteContactItem,
                    SternId = modelInput.Id
                });

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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, title: "Agregar Web Social", messages.ToArray());
            }

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        [Route("edit/contacts/web/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteWeb(InstitutionWebContactDisplayViewModel modelDisplay)
        {
            Institution entity = null;

            try
            {
                entity = Repository.Get(modelDisplay.InstitutionId);
            }
            catch { }

            if (entity == null)
            {
                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            try
            {
                var bridge = entity.Identity.WebSiteContactItemBridges.First(b => b.ProwId == entity.IdentityId && b.SternId == modelDisplay.Id);

                entity.Identity.WebSiteContactItemBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetDeletionSuccessMessage());
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

            return RedirectToAction("ManageContacts", new { key = entity.Id });
        }

        #endregion

        #endregion

        private void PopulateStateWithMunicipality(InstitutionContactsManageViewModel model)
        {
            model.SelectStates = stateRepository.GetAll().Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Name}).ToArray();
            
            if (model.SelectStates.Length > 0)
            {
                var firstStateId = System.Guid.Parse(model.SelectStates[0].Value);

                model.SelectMunicipalities = municipalityRepository.FindBy(entity => entity.StateId == firstStateId).Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Name }).ToArray();
            }
            else
            {
                model.SelectMunicipalities = new SelectListItem[] {};
            }
        }
    }
}
