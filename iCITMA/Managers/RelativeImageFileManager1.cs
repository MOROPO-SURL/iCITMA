
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Managers
{
    public class RelativeImageFileManager1 : Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade
    {
        private const string MEDIA_ROOT_DIRECTORY_NAME = "media";
        private const string IMAGES_DIRECTORY_NAME = "images";

        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;

        public RelativeImageFileManager1(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void DeleteImageFile(Image image)
        {
            System.IO.File.Delete(GetImageAbsoluteFilePath(image));
        }

        public string GetImageAbsoluteFilePath(Image image)
        {
            var webRootPhath = env.WebRootPath; 
            var a = System.IO.Path.Combine(webRootPhath, MEDIA_ROOT_DIRECTORY_NAME, IMAGES_DIRECTORY_NAME, string.Format("{0}.{1}", image.Id, image.ContentType.ContentTypeToExtension()));
            var r = env.WebRootFileProvider.GetFileInfo(a);
            return r.PhysicalPath;
        }

        public byte[] GetImageFileContent(Image image)
        {
            byte[] result;

            using (var file = System.IO.File.OpenRead(GetImageAbsoluteFilePath(image)))
            {
                result = new byte[file.Length];

                file.Read(result, 0, (int)file.Length);

                file.Close();
            }

            return result;
        }

        public string GetImageRelativeFilePath(Image image)
        {
            var a = System.IO.Path.Combine(MEDIA_ROOT_DIRECTORY_NAME, IMAGES_DIRECTORY_NAME);
            var r = env.WebRootFileProvider.GetFileInfo(a);
            return r.PhysicalPath;
        }

        public void SaveImageFileContent(Guid imageId, byte[] content, string contentType)
        {
            var a = GetImageAbsoluteFilePath(new Image { Id = imageId, ContentType = contentType });
            //var a = System.IO.Path.Combine(MEDIA_ROOT_DIRECTORY_NAME, IMAGES_DIRECTORY_NAME, string.Format("{0}.{1}", image.Id, image.ContentType.ContentTypeToExtension()));
            //var r = env.WebRootFileProvider.GetFileInfo(a);
            //var a = GetImageRelativeFilePath(new Image { Id = imageId, ContentType = contentType });
            System.IO.File.WriteAllBytes(a, content);
        }
    }
}
