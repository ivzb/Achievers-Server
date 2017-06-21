using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public class ImagesService : IImagesService
    {
        private readonly IHostingEnvironment env;

        public ImagesService(IHostingEnvironment env)
        {
            this.env = env;
        }

        public async Task<string> SaveImageAsync(Stream stream)
        {
            var imagesFolder = Path.Combine(env.WebRootPath, "images");
            var imageId = Guid.NewGuid().ToString();

            using (var fileStream = new FileStream(Path.Combine(imagesFolder, imageId + ".jpg"), FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            return imageId;
        }
    }
}
