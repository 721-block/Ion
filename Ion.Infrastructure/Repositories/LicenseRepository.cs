using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class LicenseRepository : BaseRepository<License>, ILicenseRepository
{
    public LicenseRepository(CarRentContext context) : base(context)
    {
        set = context.Licenses;
    }
}