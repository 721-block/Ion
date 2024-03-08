using Ion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Common
{
    public interface IRepository<TEntity, Tid> where TEntity : BaseEntity<Tid> where Tid : struct
    {
        public IQueryable<TEntity> GetAll();

        public TEntity GetByID(Tid id);
    }
}
