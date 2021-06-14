
using Core.Application.ViewModel;
using Core.Domain;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Base;
using Core.Service.Controller.Interface;
using Core.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TSrc,TDest>:MainController,IBaseController<TSrc> where TSrc:BaseEntityViewModel
                                                                                 where TDest:BaseEntity
    {
        private readonly IBaseAppService<TSrc, TDest> _baseAppService;
        public BaseController(IBaseAppService<TSrc, TDest> baseAppService, 
                                            INotificadorService notificador,
                                            IAppUser appUser) :base(notificador, appUser)
        {
            this._baseAppService = baseAppService;
        }


        [ClaimsAuthorize(nameof(TDest), "Consultar")]
        [HttpGet]
        public virtual async Task<IEnumerable<TSrc>> Get()
                     => await _baseAppService.GetAsync();
      

        [ClaimsAuthorize(nameof(TDest), "Consultar")]
        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<TSrc>> GetById(int id)
        {
            var retorno = await _baseAppService.GetByIdAsync(id);

            if (retorno == null)
                return NotFound();

            return retorno;
        }

        [ClaimsAuthorize(nameof(TDest), "Adicionar")]
        [HttpPost]
        public virtual async Task<ActionResult<TSrc>> Post(TSrc entidade)
        {
            if (!ModelState.IsValid) 
                    return CustomResponse(ModelState);

            await _baseAppService
                .AddAsync(entidade);

            return CustomResponse(entidade);
        }

       /* [ClaimsAuthorize(nameof(TDest), "Adicionar")]
        [HttpPost("PostCollection")]
        public async Task<ActionResult<TSrc>> PostCollection(IEnumerable<TSrc> entidades)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _baseAppService.AddCollectionAsync(entidades);

            return CustomResponse(entidades);
        }*/

        [ClaimsAuthorize(nameof(TDest), "Alterar")]
        [HttpPut]
        public virtual async Task<ActionResult<TSrc>> Put(int id, TSrc entidade)
        {

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _baseAppService.UpdateAsync(entidade);

            return CustomResponse(entidade);
        }

        [ClaimsAuthorize(nameof(TDest), "Deletar")]
        [HttpDelete]
        public virtual async Task<ActionResult<TSrc>> Delete(TSrc entidade)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _baseAppService.RemoveAsync(entidade);

            return CustomResponse(entidade);
        }

        protected virtual async Task<bool> UploadArquivoHandler(string currentDirectory, IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                NotificaErro("Forneça uma imagem para este produto");
                return false;
            }


            //currentDirectory=Directory.GetCurrentDirectory()
            var path = Path.Combine(currentDirectory, "wwwroot", imgPrefixo, arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                NotificaErro("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
