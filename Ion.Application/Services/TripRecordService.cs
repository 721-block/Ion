﻿using Ion.Application.IMappers;
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
    internal class TripRecordService(IBaseMapper<TripRecord, TripRecordViewModel> mapper, ITripRecordRepository repository) : ITripRecordService
    {
        private readonly IBaseMapper<TripRecord, TripRecordViewModel> mapper = mapper;
        private readonly ITripRecordRepository repository = repository;

        public void Delete(TripRecordViewModel model)
        {
            repository.Delete(mapper.MapToEntity(model));
            repository.SaveChanges();
        }

        public IEnumerable<TripRecordViewModel> GeByUserId(int id)
        {
            return repository.GetByUserId(id).Select(mapper.MapFromEntity);
        }

        public IEnumerable<TripRecordViewModel> GetAll()
        {
            return repository.GetAll().Select(mapper.MapFromEntity);
        }

        public TripRecordViewModel GetById(int id)
        {
            return mapper.MapFromEntity(repository.GetByID(id));
        }
    }
}