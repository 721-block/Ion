using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IUserService
{
    IEnumerable<UserViewModel> GetAll();
    UserViewModel GetById(int id);
    Task<UserViewModel> AddAsync(UserViewModel model);
    Task UpdateAsync(UserViewModel model);
    Task DeleteAsync(UserViewModel model);
    Task<LicenseViewModel> AddLicenseToUserAsync(int userId, LicenseViewModel license);
    Task UpdateLicenseAsync(LicenseViewModel license);
}