using Ion.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Ion.Application.IServices;

public interface IUserImageService
{
    public string ImagesString { get; set; }
    public string UploadImages(IEnumerable<IFormFile> images, string userName, string carName);
}
