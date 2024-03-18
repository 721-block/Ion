using Ion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Common.Interfaces;

public interface IReadRepository<TEntity>
{
    public IQueryable<TEntity> GetAll();

    public TEntity GetByID(int id);
}