using Ion.Application.IServices;
using Microsoft.AspNetCore.Http;

namespace Ion.Application.Services;

public class UserImageService : IUserImageService
{
    private string imagesPath { get; set; }
    
    public UserImageService(string imagesPath)
    {
        this.imagesPath = imagesPath;
    }

    public string UploadImages(IEnumerable<IFormFile> images, int userId, int carId)
    {
        var pathToDirectory = Path.Combine(imagesPath, userId.ToString(), carId.ToString());
        if (!Directory.Exists(pathToDirectory))
        {
            Directory.CreateDirectory(pathToDirectory);
        }
        var fileIndex = 0;
        foreach (var file in images)
        {
            if (file.Length <= 0) continue;
            var filePath = Path.Combine(pathToDirectory, $"{fileIndex}.png");
            using (var stream = new FileStream(filePath, FileMode.Create)) 
            {
                file.CopyTo(stream);
            }

            fileIndex++;
        }

        return pathToDirectory.Replace('\\', '/');
    }
}
