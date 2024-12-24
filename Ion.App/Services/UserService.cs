using Ion.Application.Base.Hashers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

internal class UserService(
    IMapper mapper,
    IUserRepository userRepository,
    ILicenseRepository licenseRepository,
    IHasher passwordHasher) : IUserService
{
    public async Task<UserViewModel> AddAsync(UserViewModel model)
    {
        var user = mapper.Map<User>(model);
        user.HashPassword = passwordHasher.Hash(model.Password);
        user = await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();
        return mapper.Map<UserViewModel>(user);
    }

    public async Task<LicenseViewModel> AddLicenseToUserAsync(int userId, LicenseViewModel license)
    {
        var user = userRepository.GetByID(userId);
        var newLicense = await licenseRepository.AddAsync(mapper.Map<License>(license));

        user.LicenseId = newLicense.Id;
        userRepository.Update(user);
        await userRepository.SaveChangesAsync();
        await licenseRepository.SaveChangesAsync();

        return mapper.Map<LicenseViewModel>(newLicense);
    }

    public async Task DeleteAsync(UserViewModel model)
    {
        userRepository.Delete(mapper.Map<User>(model));
        await userRepository.SaveChangesAsync();
    }

    public IEnumerable<UserViewModel> GetAll()
    {
        return userRepository.GetAll().Select(mapper.Map<UserViewModel>);
    }

    public UserViewModel GetById(int id)
    {
        return mapper.Map<UserViewModel>(userRepository.GetByID(id));
    }

    public UserViewModel GetByNamesAndEmail(string firstName, string lastName, string email)
    {
        return mapper.Map<UserViewModel>(userRepository.GetByNamesAndEmail(firstName, lastName, email));
    }

    public async Task UpdateAsync(UserViewModel model)
    {
        var entity = userRepository.GetByID(model.Id);
        var updatedEntity = mapper.Map(model, entity);

        userRepository.Update(updatedEntity);
        await userRepository.SaveChangesAsync();
    }

    public async Task UpdateLicenseAsync(LicenseViewModel license)
    {
        var entity = licenseRepository.GetByID(license.Id);
        var updatedEntity = mapper.Map(license, entity);

        licenseRepository.Update(updatedEntity);
        await licenseRepository.SaveChangesAsync();
    }
}