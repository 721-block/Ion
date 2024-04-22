using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IUserService
{
    IEnumerable<UserViewModel> GetAll();
    UserViewModel GetById(int id);
    Task<UserViewModel> AddAsync(UserViewModel model);
    void Update(UserViewModel model);
    void Delete(UserViewModel model);
    Task<LicenseViewModel> AddLicenseToUserAsync(int userId, LicenseViewModel license);
    void UpdateLicense(LicenseViewModel license);
}