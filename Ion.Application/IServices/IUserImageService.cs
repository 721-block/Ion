using Microsoft.AspNetCore.Http;

namespace Ion.Application.IServices;

public interface IUserImageService
{
    public string UploadImages(IEnumerable<IFormFile> images, int userId, int carId);
}
