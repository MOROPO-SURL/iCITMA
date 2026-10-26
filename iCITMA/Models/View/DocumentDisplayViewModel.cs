using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class DocumentDisplayViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Document, System.Guid>
    {        
        public System.Guid Id { get; set; }

        public string Extension { get; set; }   

        public string Name { get; set; }

        public string Description { get; set; }

        public Microsoft.AspNetCore.Html.HtmlString Icon { get; set; }

        public void Import(Document entity)
        {
            Id = entity.Id;
            Extension = GetExtension(entity.ContentType);
            Name = entity.Name;           
            Description = entity.Description;
            Icon = GetAttachmentIcon(entity.ContentType);
        }

        public DocumentInputViewModel MergeViewModels()
        {
            DocumentInputViewModel viewModel = new DocumentInputViewModel();
            viewModel.Id = Id;
            viewModel.Name = Name;            
            viewModel.Description = Description;
            return viewModel;
        }

        private Microsoft.AspNetCore.Html.HtmlString GetAttachmentIcon(string contentType)
        {
            switch (contentType)
            {
                case string x when x.Contains("pdf"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-36px mdi-file-pdf\"></span>");
                case string x when x.Contains("word"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-36px mdi-file-word\"></span>");
                case string x when (x.Contains("excel") || (x.Contains("sheet"))):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-36px mdi-file-excel\"></span>");
                case string x when x.Contains("image"):
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-36px mdi-file-image\"></span>");
                default:
                    return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-36px mdi-file\"></span>");
            }
        }

        private string GetExtension(string contentType)
        {
            switch (contentType)
            {
                case string x when x.Contains("pdf"):
                    return "pdf";
                case string x when x.Contains("word"):
                    return "word";
                case string x when (x.Contains("excel") || (x.Contains("sheet"))):
                    return "excel";
                case string x when x.Contains("image"):
                    return "image";
                default:
                    return "desconocido";
            }
        }
    }
}
