using System.IO;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public interface IImagesService
    {
        Task<string> SaveImageAsync(Stream stream);
    }
}
