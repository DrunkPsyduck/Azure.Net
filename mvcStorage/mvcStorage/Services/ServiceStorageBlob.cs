using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using mvcStorage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Services
{
    public class ServiceStorageBlob
    {
        BlobServiceClient service;
        BlobContainerClient BlobContainerClient;

        public ServiceStorageBlob(String keys)
        {
            this.service = new BlobServiceClient(keys);
          
        }

        public async Task<List<String>> GetContainerAsync()
        {
            List<String> containers = new List<String>();
            await foreach(BlobContainerItem container in this.service.GetBlobContainersAsync())
            {
                containers.Add(container.Name);
            }
            return containers;
        }

        public async Task CreateContainerAsync(String containername)
        {
            await this.service.CreateBlobContainerAsync(containername, PublicAccessType.Blob);
        }

        public async Task DeleteContainerAsync(String containername)
        {
            await this.service.DeleteBlobContainerAsync(containername);
        }

        public async Task DeleteBlobAsync(String containername, string blobname)
        {
            BlobContainerClient containerClient = this.service.GetBlobContainerClient(containername);
            await containerClient.DeleteBlobAsync(blobname);
        }

        public async Task UploadBlobAsync(string containername, String blobname, Stream stream)
        {
            BlobContainerClient containerClient = this.service.GetBlobContainerClient(containername);

            await containerClient.UploadBlobAsync(blobname, stream);
        }



        public async Task<List<Blob>> GetBlobsAsync(String containername)
        {
            BlobContainerClient containerClient =
                this.service.GetBlobContainerClient(containername);
            List<Blob> blobs = new List<Blob>();
            await foreach(BlobItem blob in containerClient.GetBlobsAsync())
            {
                BlobClient blobclient = containerClient.GetBlobClient(blob.Name);
                String uri = blobclient.Uri.AbsoluteUri;
                string name = blob.Name;

                blobs.Add(new Blob { Nombre = name, Uri = uri });
            }
            return blobs;
        }

    }

}
