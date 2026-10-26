using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Controllers;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using SkiaSharp;
using System;
using System.IO;
using System.Net.Mail;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Auxiliares")]
    public class DocumentsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Persistence.Entities.Document, System.Guid, DocumentInputViewModel, DocumentDisplayViewModel>
    {
        private readonly Managers.RelativeDocumentFileManager attachmentFileManager;
        public DocumentsController(Managers.RelativeDocumentFileManager attachmentFileManager, IEntityRepository<Document, Guid> repository, IStringLocalizer<DocumentsController> localizer, ILogger<DocumentsController> logger) : base(repository, localizer, logger)
        {
            this.attachmentFileManager = attachmentFileManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.DocumentCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.DocumentCreator)]
        public override IActionResult Create(DocumentInputViewModel modelInput)
        {
            ModelState.ClearValidationState("File");

            modelInput.File = Request.Form.Files[0];
            modelInput.ContentType = modelInput.File.ContentType;

            var updateModelTask = TryUpdateModelAsync(modelInput);
            updateModelTask.Wait();          
           
            
            return base.Create(modelInput);
        }

        [RequirePermissions(Permission.DocumentEditor)]
        public override IActionResult Edit(Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.DocumentEditor)]
        public override IActionResult Edit(DocumentInputViewModel modelInput)
        {
            return base.Edit(modelInput);
        }

        [RequirePermissions(Permission.DocumentRemover)]
        public override IActionResult Delete(DocumentDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        [RequirePermissions(Permission.DocumentRemover)]
        public override IActionResult Delete(Guid key)
        {
            return base.Delete(key);
        }

        protected override void PostCreate(Document entity, DocumentInputViewModel modelInput)
        {            
            base.PostCreate(entity, modelInput);

            var extension = System.IO.Path.GetExtension(modelInput.File.FileName);

            if (ModelState.IsValid)
            {

                using (var memoryStream = new System.IO.MemoryStream())
                {
                    modelInput.File.CopyTo(memoryStream);

                    var document = new Document { ContentType = modelInput.File.ContentType, Length = modelInput.File.Length};

                    attachmentFileManager.SaveImageFileContent(entity.Id, memoryStream.ToArray(), modelInput.File.ContentType);
                                        
                }
            }
        }

        protected override void PostDelete(Document entity)
        {
            base.PostDelete(entity);

            attachmentFileManager.DeleteImageFile(entity);
        }
    }
}
