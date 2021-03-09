using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Controllers
{
    public class AzureFilesController : Controller
    {
        ServiceStorageFile serviceFiles;

        public AzureFilesController(ServiceStorageFile servicefiles)
        {
            this.serviceFiles = servicefiles;
        }

        public async Task<IActionResult> Index(String filename)
        {
            if (filename != null)
            {
                String content = await this.serviceFiles.GetFileContentAsync(filename);
                ViewData["CONTENT"] = content;
            }

            List<string> files = await this.serviceFiles.GetFilesAsync();
            return View(files);
        }

        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            String filename = file.FileName;

            using(var stream = file.OpenReadStream())
            {
                await this.serviceFiles.UploadFileAsync(filename, stream);

            }
            ViewData["MENSAJE"] = "Archivo subido correctamente";
            return View();
            
        }

        public async Task<IActionResult> DeleteFile(String filename)
        {
            await this.serviceFiles.DeleteFileAsync(filename);
            return RedirectToAction("Index");
        }
    }
}
