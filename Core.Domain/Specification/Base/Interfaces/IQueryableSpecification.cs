using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Specification.Base.Interfaces
{
    public interface IQueryableSpecification<T> where T :class
    {
        IEnumerable<T> IsSatisfiedBy(IQueryable<T> queryable);
    }
}
