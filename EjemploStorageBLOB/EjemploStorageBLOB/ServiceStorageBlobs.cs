using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploStorageBLOB
{
    class ServiceStorageBlobs
    {
        CloudBlobClient client;

        public ServiceStorageBlobs()
        {
            String keys = ConfigurationSettings.AppSettings["storageaccount"];
            CloudStorageAccount account = CloudStorageAccount.Parse(keys);
            this.client = account.CreateCloudBlobClient();
        }

        public async Task CreateContainerAsync(String containername)
        {
            CloudBlobContainer container = this.client.GetContainerReference(containername);
            await container.CreateIfNotExistsAsync();
            //Por defecto se crean de forma privada
            await container.SetPermissionsAsync(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
        }

        public List<String> GetContainers()
        {
            List<String> containers = new List<string>();
            foreach(CloudBlobContainer c in this.client.ListContainers())
            {
                containers.Add(c.Name);
            }
            return containers;
        }

        public async Task UploadBlob(String containerName, String filename, String path)
        {
            CloudBlobContainer container = this.client.GetContainerReference(containerName);
            // crear un blob de tipo cloudblockblon
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
            using(var stream = File.OpenRead(path))
            {
                await blob.UploadFromStreamAsync(stream);
            }
        }

        public async Task DeleteBlobAsync(String containerName, String filename)
        {
            CloudBlobContainer container = this.client.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
            await blob.DeleteIfExistsAsync();
        }

        public List<CloudBlockBlob> GetBlobs(String containername)
        {
            CloudBlobContainer container = this.client.GetContainerReference(containername);
            List<CloudBlockBlob> blobs = new List<CloudBlockBlob>();

            foreach(IListBlobItem blob in container.ListBlobs().ToList())
            {
                blobs.Add((CloudBlockBlob)blob);
            }
            return blobs;
        }
    }
}
