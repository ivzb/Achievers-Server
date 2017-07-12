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

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null)
            {
                return this.BadRequest("Please upload a single file");
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
                Name = Guid.NewGuid().ToString(),
                Content = fileBytes,
                ContentType = file.ContentType
            };

            await this.files.CreateAsync(newFile);

            FileViewModel result = new FileViewModel
            {
                Id = newFile.Id,
                ContentType = newFile.ContentType
            };

            return this.Created(new Uri(this.Request.GetDisplayUrl()), result);
        }
    }
}
