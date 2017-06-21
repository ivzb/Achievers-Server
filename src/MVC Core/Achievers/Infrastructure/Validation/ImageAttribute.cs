using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Achievers.Infrastructure.Validation
{
    public class ImageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var image = value as IFormFile;
            if (image == null)
            {
                return true;
            }
            
            if (image == null || image.Length == 0 || !image.FileName.EndsWith(".jpg"))
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Invalid or missing image.";
        }
    }
}
