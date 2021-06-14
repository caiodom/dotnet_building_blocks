using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Base;
using Core.Service.Controller;
using Core.Service.Controller.Interface;
using Core.Service.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Application.ViewModel;
using Teste.Domain.Entities;

namespace Teste.WebApi.Controllers
{
    //[ApiController]
    //[Route("api/Teste")]
    public class TesteController:BaseController<TesteEntityViewModel,TesteEntity>,IBaseController<TesteEntityViewModel>
    {
        
        public TesteController(IBaseAppService<TesteEntityViewModel, TesteEntity> baseAppService,
                               INotificadorService notificador,IAppUser user) :base(baseAppService,notificador,user)
        {

        }

        [ClaimsAuthorize("Teste", "Adicionar")]
        [HttpPost]
        public override Task<ActionResult<TesteEntityViewModel>> Post(TesteEntityViewModel entidade)
        {
            return base.Post(entidade);
        }

        [ClaimsAuthorize("Teste", "Consultar")]
        [HttpGet]
        public override Task<IEnumerable<TesteEntityViewModel>> Get()
        {
            return base.Get();
        }
    }
}
