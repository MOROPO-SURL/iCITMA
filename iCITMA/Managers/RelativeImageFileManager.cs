using MOROPO.CITMA.CMG.iCITMA.Extensions;

namespace MOROPO.CITMA.CMG.iCITMA.Managers
{
    public class RelativeImageFileManager: MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade
    {
        private const string MEDIA_ROOT_DIRECTORY_NAME = "media";
        private const string IMAGES_DIRECTORY_NAME = "images";

        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;

        public RelativeImageFileManager(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void DeleteImageFile(Framework.Guama.Media.Persistence.Entities.Image image)
        {
            System.IO.File.Delete(GetImageAbsoluteFilePath(image));
        }

        public string GetImageAbsoluteFilePath(Framework.Guama.Media.Persistence.Entities.Image image)
        {
            string[] path = { env.WebRootPath, MEDIA_ROOT_DIRECTORY_NAME, IMAGES_DIRECTORY_NAME, string.Format("{0}.{1}", image.Id, image.ContentType.ContentTypeToExtension()) };
            
            return System.IO.Path.Combine(path);
        }

        public byte[] GetImageFileContent(MOROPO.Framework.Guama.Media.Persistence.Entities.Image image)
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

        public string GetImageRelativeFilePath(MOROPO.Framework.Guama.Media.Persistence.Entities.Image image)
        {
            return null;
        }

        public void SaveImageFileContent(System.Guid imageId, byte[] content, string contentType)
        {
            System.IO.File.WriteAllBytes(GetImageAbsoluteFilePath(new MOROPO.Framework.Guama.Media.Persistence.Entities.Image { Id = imageId, ContentType = contentType }), content);
        }
    }
}
