using Achievers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private readonly IFilesService files;

        public FilesController(IFilesService files)
        {
            this.files = files;
        }
        
        public async Task<IActionResult> Add()
        {
            //// Check if the request contains multipart/form-data.
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            //MultipartMemoryStreamProvider memoryProvider = new MultipartMemoryStreamProvider();

            //try
            //{
            //    await Request.Content.ReadAsMultipartAsync(memoryProvider);
            //    Stream stream = memoryProvider.GetStream(Request.Content, Request.Content.Headers);

            //    if (memoryProvider.Contents.Count != 1)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Please upload a single file");
            //    }

            //    HttpContent fileContents = memoryProvider.Contents.SingleOrDefault();
            //    byte[] fileBytes = await fileContents.ReadAsByteArrayAsync();
            //    string contentType = fileContents.Headers.ContentType.ToString();

            //    Data.Models.File file = new Data.Models.File
            //    {
            //        Content = fileBytes,
            //        ContentType = contentType
            //    };

            //    this.service.Add(file);

            //    FileViewModel result = new FileViewModel
            //    {
            //        Id = file.Id,
            //        ContentType = file.ContentType
            //    };

            //    return Request.CreateResponse(HttpStatusCode.Created, result);
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            //}
        }
    }
}
