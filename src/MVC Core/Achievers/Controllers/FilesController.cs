using Achievers.Models.Files;
using Achievers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Achievers.Infrastructure.Extensions;

namespace Achievers.Controllers
{
    //[Authorize]
    public class FilesController : Controller
    {
        private readonly IFilesService files;

        public FilesController(IFilesService files)
        {
            this.files = files;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return await this.FileOrNotFound(async () => await this.files.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null)
            {
                return this.BadRequest("Please upload a file");
            }
            
            byte[] fileBytes;

            using (Stream stream = file.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
            }

            Data.Models.File newFile = new Data.Models.File
            {
                Name = file.FileName, 
                Content = fileBytes,
                ContentType = file.ContentType
            };

            await this.files.CreateAsync(newFile);

            // TODO: map with automapper
            FileViewModel result = new FileViewModel
            {
                Id = newFile.Id,
                Name = newFile.Name,
                ContentType = newFile.ContentType
            };

            return this.Created(new Uri(this.Request.GetDisplayUrl()), result);
        }
    }
}
