using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Minio;
using Minio.DataModel.Args;

namespace Library_Management_System_project.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly string _bucket;
        private IMinioClient _client;

        public ImageStorageService()
        {
            _bucket = ConfigurationManager.AppSettings["MinioBucket"];
        }

        // Built on first actual use, not at construction time - constructing a
        // BookService (e.g. from the WinForms designer instantiating a parent
        // form) must not require a reachable Minio endpoint.
        private IMinioClient Client
        {
            get
            {
                if (_client == null)
                {
                    bool useSsl = bool.Parse(ConfigurationManager.AppSettings["MinioUseSSL"] ?? "false");
                    _client = new MinioClient()
                        .WithEndpoint(ConfigurationManager.AppSettings["MinioEndpoint"])
                        .WithCredentials(
                            ConfigurationManager.AppSettings["MinioAccessKey"],
                            ConfigurationManager.AppSettings["MinioSecretKey"])
                        .WithSSL(useSsl)
                        .Build();
                }
                return _client;
            }
        }

        public void UploadImage(string localFilePath, string objectKey)
        {
            var args = new PutObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectKey)
                .WithFileName(localFilePath)
                .WithContentType("image/jpeg");

            Task.Run(() => Client.PutObjectAsync(args)).GetAwaiter().GetResult();
        }

        public Stream DownloadImage(string objectKey)
        {
            var stream = new MemoryStream();
            var args = new GetObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectKey)
                .WithCallbackStream(s => s.CopyTo(stream));

            Task.Run(() => Client.GetObjectAsync(args)).GetAwaiter().GetResult();
            stream.Position = 0;
            return stream;
        }
    }
}
