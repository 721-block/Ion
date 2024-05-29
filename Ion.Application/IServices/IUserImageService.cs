using Microsoft.AspNetCore.Http;

namespace Ion.Application.IServices;

public interface IUserImageService
{
    public string UploadImages(IEnumerable<IFormFile> images, string userName, string carName);
}
