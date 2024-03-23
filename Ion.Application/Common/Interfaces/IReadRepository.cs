using Ion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Common.Interfaces;

public interface IReadRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    public IQueryable<TEntity> GetAll();

    public TEntity GetByID(TKey id);
}