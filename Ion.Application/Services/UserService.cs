using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

internal class UserService(
    IBaseMapper<User, UserViewModel> userMapper,
    IUserRepository userRepository,
    IBaseMapper<License, LicenseViewModel> licenseMapper,
    ILicenseRepository licenseRepository) : IUserService
{
    public async void AddAsync(UserViewModel model)
    {
        await userRepository.AddAsync(userMapper.MapToEntity(model));
        userRepository.SaveChangesAsync();
    }

    public async void AddLicenseToUserAsync(int userId, LicenseViewModel license)
    {
        var user = userRepository.GetByID(userId);
        var newLicense = await licenseRepository.AddAsync(licenseMapper.MapToEntity(license));
        user.LicenseId = newLicense.Id;
        userRepository.Update(user);
        userRepository.SaveChangesAsync();
        licenseRepository.SaveChangesAsync();
    }

    public void Delete(UserViewModel model)
    {
        userRepository.Delete(userMapper.MapToEntity(model));
        userRepository.SaveChangesAsync();
    }

    public IEnumerable<UserViewModel> GetAll()
    {
        return userRepository.GetAll().Select(userMapper.MapFromEntity);
    }

    public UserViewModel GetById(int id)
    {
        return userMapper.MapFromEntity(userRepository.GetByID(id));
    }

    public void Update(UserViewModel model)
    {
        userRepository.Update(userMapper.MapToEntity(model));
        userRepository.SaveChangesAsync();
    }

    public void UpdateLicense(LicenseViewModel license)
    {
        licenseRepository.Update(licenseMapper.MapToEntity(license));
        licenseRepository.SaveChangesAsync();
    }
}