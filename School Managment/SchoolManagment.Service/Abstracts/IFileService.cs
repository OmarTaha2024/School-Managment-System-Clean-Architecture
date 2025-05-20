using Microsoft.AspNetCore.Http;

namespace SchoolManagment.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);

    }
}
