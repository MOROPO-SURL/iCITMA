using MOROPO.CITMA.CMG.iCITMA.Extensions;

namespace MOROPO.CITMA.CMG.iCITMA.Managers
{
    public class RelativeDocumentFileManager
    {
        private const string MEDIA_ROOT_DIRECTORY_NAME = "media";
        private const string DOCUMENTS_DIRECTORY_NAME = "attachments";

        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;

        public RelativeDocumentFileManager(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void DeleteImageFile(Persistence.Entities.Document document)
        {
            var path = GetImageAbsoluteFilePath(document);
            System.IO.File.Delete(path);
        }

        public string GetImageAbsoluteFilePath(Persistence.Entities.Document document)
        {
            string[] path = { env.WebRootPath, MEDIA_ROOT_DIRECTORY_NAME, DOCUMENTS_DIRECTORY_NAME, string.Format("{0}.{1}", document.Id, document.ContentType.ContentTypeToExtension()) };

            return System.IO.Path.Combine(path);
        }

        public byte[] GetImageFileContent(Persistence.Entities.Document document)
        {
            byte[] result;

            using (var file = System.IO.File.OpenRead(GetImageAbsoluteFilePath(document)))
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
            System.IO.File.WriteAllBytes(GetImageAbsoluteFilePath(new Persistence.Entities.Document { Id = imageId, ContentType = contentType }), content);
        }
    }
}
