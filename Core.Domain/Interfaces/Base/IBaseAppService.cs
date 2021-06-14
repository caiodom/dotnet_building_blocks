using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Base
{
    public interface IBaseAppService<TSrc,TDest>
    {

        Task<IEnumerable<TSrc>> GetAsync(bool asNoTracking = true);

        Task<TSrc> GetByIdAsync(int entityId, bool asNoTracking = true);

        Task AddAsync(TSrc entity);


        Task AddCollectionAsync(IEnumerable<TSrc> entities);


        Task UpdateAsync(TSrc entity);


        Task UpdateCollectionAsync(IEnumerable<TSrc> entities);

        Task RemoveAsync(TSrc entity);





    }
}
