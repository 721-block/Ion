using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.IServices;

internal interface ITripRecordService
{
    IEnumerable<TripRecordViewModel> GetAll();
    TripRecordViewModel GetById(int id);
    IEnumerable<TripRecordViewModel> GeByUserId(int id);
    void Delete(TripRecordViewModel model);
}