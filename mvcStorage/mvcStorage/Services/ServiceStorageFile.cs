using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace mvcStorage.Services
{
    public class ServiceStorageFile
    {
        private ShareClient client;
        private ShareDirectoryClient root;

        public ServiceStorageFile(String keys)
        {
    
            this.client = new ShareClient(keys, "ejemplo");
            this.root = client.GetRootDirectoryClient();
        }

        //public async Task<List<String>> GetFilesAsync()
        //{


        //    //Devuelve los segmentos y devuelve una lista de la clase IListFileItem
        //    var segmentos = await this.root.ListFilesAndDirectoriesSegmentedAsync(null);
        //    List<IListFileItem> azurefiles = segmentos.Results.ToList();
        //    List<String> files = new List<String>();

        //    foreach(IListFileItem f in azurefiles)
        //    {
        //        String uri = f.StorageUri.PrimaryUri.AbsoluteUri;
        //        int ultimo = uri.LastIndexOf("/") + 1;

        //        String filename = uri.Substring(ultimo);
        //        filename = filename.Replace('%', ' ');
        //        files.Add(filename);
        //    }
        //    return files;
        //}
        public async Task<List<String>> GetFilesAsync()
        {
            List<String> files = new List<string>();
            await foreach (var file in this.root.GetFilesAndDirectoriesAsync())
            {
                files.Add(file.Name);
            }
            return files;

        }



        public async Task DeleteFileAsync(String filename)
        {
            ShareFileClient file = root.GetFileClient(filename);
            await file.DeleteAsync();
        }

        public async Task UploadFileAsync(String filename
            , Stream stream)
        {
            ShareFileClient file = this.root.GetFileClient(filename);
            await file.CreateAsync(stream.Length);
            await file.UploadAsync(stream);
        }

        public async Task<String> GetFileContentAsync(String filename)
        {
            ShareFileClient file = this.root.GetFileClient(filename);
            var data = await file.DownloadAsync();
            Stream stream = data.Value.Content;
            StreamReader reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();

        }

    }
}
