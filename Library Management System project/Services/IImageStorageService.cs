using System.IO;

namespace Library_Management_System_project.Services
{
    public interface IImageStorageService
    {
        void UploadImage(string localFilePath, string objectKey);
        Stream DownloadImage(string objectKey);
    }
}
