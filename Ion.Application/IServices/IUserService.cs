using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.IServices;

public interface IUserService
{
    IEnumerable<UserViewModel> GetAll();
    UserViewModel GetById(int id);
    void Add(UserViewModel model);
    void Update(UserViewModel model);
    void Delete(UserViewModel model);
    void AddLicenseToUser(int userId, LicenseViewModel license);
    void UpdateLicense(LicenseViewModel license);
}