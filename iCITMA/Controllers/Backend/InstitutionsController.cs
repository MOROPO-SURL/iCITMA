using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Auxiliares")]
    public class InstitutionsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Institution, System.Guid, InstitutionInputViewModel, InstitutionDisplayViewModel>
    {
        private readonly IImageFileManagerFacade imageFileManagerFacade;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<OrganizationIdentity, Guid> identityRepository;
        private readonly IEntityRepository<PhoneContactItem, Guid> phoneContactItemRepository;
        private readonly IEntityRepository<EmailContactItem, Guid> emailContactItemRepository;
        private readonly IEntityRepository<SocialContactItem, Guid> socialContactItemRepository;
        private readonly IEntityRepository<PostalContactItem, Guid> postalContactItemRepository;

        public InstitutionsController(IEntityRepository<Institution, System.Guid> repository,
            IStringLocalizer<InstitutionsController> localizer,
            ILogger<InstitutionsController> logger,
            IImageFileManagerFacade imageFileManagerFacade,
            IEntityRepository<Image, System.Guid> imageRepository,
            IEntityRepository<OrganizationIdentity, Guid> identityRepository,
            IEntityRepository<PhoneContactItem, Guid> phoneContactItemRepository,
            IEntityRepository<EmailContactItem, Guid> emailContactItemRepository,
            IEntityRepository<SocialContactItem, Guid> socialContactItemRepository,
            IEntityRepository<PostalContactItem, Guid> postalContactItemRepository) : base(repository, localizer, logger)
        {
            this.imageFileManagerFacade = imageFileManagerFacade;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
            this.phoneContactItemRepository = phoneContactItemRepository;
            this.emailContactItemRepository = emailContactItemRepository;
            this.socialContactItemRepository = socialContactItemRepository;
            this.postalContactItemRepository = postalContactItemRepository;
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

        protected override void PreCreate(Institution entity, InstitutionInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            if (modelInput.ImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.ImageFile.CopyTo(memoryStream);

                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Institution " + entity.Id };

                imageFileManagerFacade.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                entity.Identity.Image = image;
            }
        }

        protected override void PreEdit(Institution entity, InstitutionInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            if (modelInput.ImageFile == null)
            {
                if(modelInput.ResetImage && entity.Identity.Image != null)
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

                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Institution " + entity.Id };

                imageFileManagerFacade.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                entity.Identity.Image = image;
                imageRepository.Add(image, User.Identity.Name);
            }
        }        

        protected override void PostDelete(Institution entity)
        {
            base.PostDelete(entity);

            identityRepository.Delete(entity.Identity, User.Identity.Name);

           if( entity.Identity.Image == null) return;

            imageRepository.Delete(entity.Identity.Image, User.Identity.Name);
            imageFileManagerFacade.DeleteImageFile(entity.Identity.Image);
        }

        #region Contacts

        [Route("edit/{key}/contacts")]
        [RequirePermissions(Permission.InstitusionViewer)]
        public IActionResult Contacts(System.Guid key)
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
                    SocialContacts = entity.Identity.SocialContactItemBridges.Select(bridge => new InstitutionSocialContactDisplayViewModel
                    {
                        Id = bridge.Stern.Id,
                        Label = bridge.Stern.Label,
                        SocialId = bridge.Stern.SocialId,
                        InstitutionId = entity.Id,
                        Icon = GetIcon(bridge.Stern.SocialId)
                    }).ToList()
                };

                resultModel.Institution.Import(entity);

                return View(resultModel);
            }
            catch (Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(MOROPO.Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

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
                SetDefaultNotification(MOROPO.Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, GetNotFoundMessage());

                return GetDefaultActionResult();
            }

            if (ModelState.IsValid)
            {
                var PhoneContactItem = new PhoneContactItem { Label = modelInput.Label, PhoneNumber = modelInput.Number };
                phoneContactItemRepository.Add(PhoneContactItem, User.Identity.Name, true);
               
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

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Danger, messages.ToArray());
            }

            return RedirectToAction("contacts", new { key = entity.Id });
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

            return RedirectToAction("contacts", new { key = entity.Id });
        }

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
                emailContactItemRepository.Add(emailContactItem, User.Identity.Name, true);

                entity.Identity.EmailContactItemBridges.Add(new OrganizationEmailContactItemBridge { ProwId = (Guid)entity.IdentityId, Stern = emailContactItem , SternId = emailContactItem.Id});

                Repository.Update(entity, User.Identity.Name);

                SetDefaultNotification(Framework.Guama.Core.Presentation.Models.View.NotificationType.Success, GetCreationSuccessMessage());
            }
            else
            {
                var messages = new System.Collections.Generic.List<string>();

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

            return RedirectToAction("contacts", new { key = entity.Id });
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

            return RedirectToAction("contacts", new { key = entity.Id });
        }

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
                socialContactItemRepository.Add(socialContactItem, User.Identity.Name, true);

                entity.Identity.SocialContactItemBridges.Add(new OrganizationSocialContactItemBridge { ProwId = (Guid)entity.IdentityId, Stern = socialContactItem, SternId = modelInput.Id });

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

            return RedirectToAction("contacts", new { key = entity.Id });
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

            return RedirectToAction("contacts", new { key = entity.Id });
        }

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
                var postalContactItem = new PostalContactItem { Address = modelInput.Address, Latitude = modelInput.Latitude, LocationId = modelInput.LocationId, ZipCode = modelInput.ZipCode, Location = modelInput.Location };
                postalContactItemRepository.Add(postalContactItem, User.Identity.Name, true);

                entity.Identity.PostalContactItemBridges.Add(new OrganizationPostalContactItemBridge { ProwId = (Guid)entity.IdentityId, 
                    Stern = postalContactItem, SternId = modelInput.Id });

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

            return RedirectToAction("contacts", new { key = entity.Id });
        }

        [Route("edit/contacts/postal/delete")]
        [RequirePermissions(Permission.InstitusionEditor)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostalContact(InstitutionPostalContactDisplayViewModel modelDisplay)
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

            return RedirectToAction("contacts", new { key = entity.Id });
        }

        #endregion



        private Microsoft.AspNetCore.Html.HtmlString GetIcon(string socialId)
        {
            switch (socialId)
            {
                case string x when x.Contains("facebook.com"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"social-icon mdi mdi-facebook\"></span>");
                case string x when x.Contains("twitter.com"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"social-icon mdi mdi-twitter\"></span>");
                case string x when x.Contains("instagram.com"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"social-icon mdi mdi-instagram\"></span>");
                case string x when x.Contains("linkedin.com"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"social-icon mdi mdi-linkedin\"></span>");
                default:
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"social-icon mdi mdi-cloud-question\"></span>");
            }
        }
    }
}
