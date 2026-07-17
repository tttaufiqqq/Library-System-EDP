using System.Configuration;
using System.IO;
using Minio;
using Minio.DataModel.Args;

namespace Library_Management_System_project.Services
{
    public class ImageStorageService
    {
        private readonly string _bucket;
        private readonly IMinioClient _client;

        public ImageStorageService()
        {
            _bucket = ConfigurationManager.AppSettings["MinioBucket"];
            bool useSsl = bool.Parse(ConfigurationManager.AppSettings["MinioUseSSL"] ?? "false");

            _client = new MinioClient()
                .WithEndpoint(ConfigurationManager.AppSettings["MinioEndpoint"])
                .WithCredentials(
                    ConfigurationManager.AppSettings["MinioAccessKey"],
                    ConfigurationManager.AppSettings["MinioSecretKey"])
                .WithSSL(useSsl)
                .Build();
        }

        public void UploadImage(string localFilePath, string objectKey)
        {
            var args = new PutObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectKey)
                .WithFileName(localFilePath)
                .WithContentType("image/jpeg");

            _client.PutObjectAsync(args).GetAwaiter().GetResult();
        }

        public Stream DownloadImage(string objectKey)
        {
            var stream = new MemoryStream();
            var args = new GetObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectKey)
                .WithCallbackStream(s => s.CopyTo(stream));

            _client.GetObjectAsync(args).GetAwaiter().GetResult();
            stream.Position = 0;
            return stream;
        }
    }
}
