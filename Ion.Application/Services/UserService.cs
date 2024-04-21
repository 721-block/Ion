using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Services
{
    internal class UserService(
        IBaseMapper<User, UserViewModel> userMapper, 
        IUserRepository userRepository,
        IBaseMapper<License, LicenseViewModel> licenseMapper,
        ILicenseRepository licenseRepository) : IUserService
    {
        private readonly IBaseMapper<User, UserViewModel> userMapper = userMapper;
        private readonly IUserRepository userRepository = userRepository;
        private readonly IBaseMapper<License, LicenseViewModel> licenseMapper = licenseMapper;
        private readonly ILicenseRepository licenseRepository = licenseRepository;

        public void Add(UserViewModel model)
        {
            userRepository.AddAsync(userMapper.MapToEntity(model));
            userRepository.SaveChangesAsync();
        }

        public void AddLicenseToUser(int userId, LicenseViewModel license)
        {
            var user = userRepository.GetByID(userId);
            licenseRepository.AddAsync(licenseMapper.MapToEntity(license));
            user.LicenseId = licenseRepository.GetAll().Last().Id;
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
}
