using Ion.Application.IServices;
using Microsoft.AspNetCore.Http;

namespace Ion.Application.Services;

public class UserImageService : IUserImageService
{
    public string ImagesPath { get; set; }
    
    public string UploadImages(IEnumerable<IFormFile> images, string userName, string carName)
    {
        var pathToDirectory = Path.Combine(ImagesPath, userName, carName);
        var fileIndex = 0;
        foreach (var file in images)
        {
            if (file.Length <= 0) continue;
            var filePath = Path.Combine(pathToDirectory, fileIndex.ToString());
            using (var stream = new FileStream(filePath, FileMode.Create)) 
            {
                file.CopyTo(stream);
            }

            fileIndex++;
        }

        return pathToDirectory;
    }
}
