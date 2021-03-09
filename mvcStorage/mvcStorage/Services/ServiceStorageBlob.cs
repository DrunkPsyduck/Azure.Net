using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Services
{
    public class ServiceStorageBlob
    {
        BlobServiceClient blobServiceClient;
        BlobContainerClient BlobContainerClient;

        public ServiceStorageBlob(BlobServiceClient blobServiceclient, BlobContainerClient blobContainerClient)
        {
            this.blobServiceClient = blobServiceclient;
            this.BlobContainerClient = blobContainerClient;
        }

        public async Task CreateBlob(String name)
        {
            String containerName = name;

            await this.blobServiceClient.CreateBlobContainerAsync(containerName);
        }

        public async Task LoadBlobServer(String path, String filename)
        {
            String localFilePath = Path.Combine(path, filename);

            await File.WriteAllTextAsync(localFilePath, "");
            BlobClient blobClient = this.BlobContainerClient.GetBlobClient(filename);

            using (FileStream uploadFileStream = File.OpenRead(localFilePath))
            {
                await blobClient.UploadAsync(uploadFileStream, true);
                uploadFileStream.Close();
            }
          
        }

        public async Task<List<String>> ListContainerBlob()
        {
            List<String> blobs = new List<string>();
            await foreach (BlobItem item in BlobContainerClient.GetBlobsAsync())
            {
                blobs.Add(item.ToString());
            }

            return blobs;
        }

    }

}
