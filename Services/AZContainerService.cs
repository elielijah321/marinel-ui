using System;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Marinel_ui.Services
{
    public class AZContainerService : IAZContainerService
    {
        public IConfiguration _configuration { get; }

        private const string ContainerName = "documents";
        private const string MetaDataKey = "DocumentType";

        private BlobContainerClient _blobContainerClient { get; set; }


        public AZContainerService(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = Environment.GetEnvironmentVariable("ContainerString") ?? _configuration["ContainerString"];
            _blobContainerClient = new BlobContainerClient(connectionString, ContainerName);

        }

        public async void AddFile(IFormFile file, string prefferedName)
        {
            var fileName = CreateFileName(file.FileName, prefferedName);
            var blob = _blobContainerClient.GetBlobClient(fileName);

            var tag = new Dictionary<string, string>();

            tag.Add(MetaDataKey, "Receipts");

            var blobOptions = new BlobUploadOptions()
            {
                Metadata = tag
            };

            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;
                    await blob.UploadAsync(ms, blobOptions);
                }
            }
        }


        private string CreateFileName(string fileName, string prefferedName)
        {
            var extension = fileName.Split(".")[1];
            var result = $"{prefferedName}.{extension}";

            return result;
        }

    }
}

