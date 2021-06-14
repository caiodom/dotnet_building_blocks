using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Controller.Interface
{
    public interface IBaseController<TSrc>
    {

        Task<IEnumerable<TSrc>> Get();


        Task<ActionResult<TSrc>> GetById(int id);

        /*Task<ActionResult<TSrc>> PostCollection(IEnumerable<TSrc> entidades);*/


        Task<ActionResult<TSrc>> Post(TSrc entidade);


        Task<ActionResult<TSrc>> Put(int id, TSrc entidade);


      Task<ActionResult<TSrc>> Delete(TSrc entidade);




    }
}
