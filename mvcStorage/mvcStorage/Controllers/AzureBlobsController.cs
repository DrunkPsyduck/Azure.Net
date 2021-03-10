using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Controllers
{
    public class AzureBlobsController : Controller
    {
        ServiceStorageBlob serviceBlobs;

        public AzureBlobsController(ServiceStorageBlob serviceBlobs)
        { 
            this.serviceBlobs = serviceBlobs;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.serviceBlobs.GetContainerAsync());
        }

        public IActionResult CreateContainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(String containername) {
            await this.serviceBlobs.CreateContainerAsync(containername.ToLower());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContainer(String containername)
        {
            await this.serviceBlobs.DeleteContainerAsync(containername.ToLower());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ListBlobs(String containername)
        {
            ViewData["CONTAINERNAME"] = containername;
            return View(await this.serviceBlobs.GetBlobsAsync(containername));
        }

        public async Task<IActionResult> DeleteBlob(String containername, String blobname)
        {
            await this.serviceBlobs.DeleteBlobAsync(containername, blobname);
            return RedirectToAction("ListBlobs", new { containername = containername });
        }

        public IActionResult UploadBlob(String containername)
        {
            ViewData["CONTAINERNAME"] = containername;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(IFormFile blobfile, String containername)
        {
            String blobname = blobfile.FileName;
            using (var stream = blobfile.OpenReadStream())
            {
                await this.serviceBlobs.UploadBlobAsync(containername, blobname, stream);
            }
            return RedirectToAction("ListBlobs", new { containername = containername });
        }
    }
}
