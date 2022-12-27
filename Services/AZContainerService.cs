using System;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Marinel_ui.Models;
using Azure;
using System.Reflection.Metadata;
using System.Net;
using System.Net.Http;
using static System.Reflection.Metadata.BlobBuilder;

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
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        ms.Position = 0;
                        await blob.UploadAsync(ms, blobOptions);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public List<DocumentModel> GetFiles()
        {
            var blobs = _blobContainerClient.GetBlobs(BlobTraits.Metadata);

            List<DocumentModel> documents = new List<DocumentModel>();

            foreach (var blob in blobs)
            {
                documents.Add(CreateDocumentModel(blob));
            }

            return documents;
        }

        private string CreateFileName(string fileName, string prefferedName)
        {
            var extension = fileName.Split(".")[1];
            var result = $"{prefferedName}.{extension}";

            return result;
        }


        private DocumentModel CreateDocumentModel(BlobItem blobItem)
        {
            var document = new DocumentModel();
            document.Id = blobItem.Properties.ETag.ToString();
            document.Name = blobItem.Name;
            document.CreatedAt = blobItem.Properties.CreatedOn.Value.Date;
            document.DocumentType = blobItem.Metadata[MetaDataKey];
            document.URL = $"{_blobContainerClient.Uri}/{document.Name}";

            return document;
        }

        public void DeleteDocument(string documentName)
        {
            BlobClient blob = _blobContainerClient.GetBlobClient(documentName);

            blob.Delete();
        }
    }
}

