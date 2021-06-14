using Core.Domain;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

using System.Linq;


namespace Core.Service.Controller
{

    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificadorService _notificador;
        private readonly IAppUser _appUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        public MainController(INotificadorService notificador, IAppUser appUser)
        {
            this._notificador = notificador;
            this._appUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if(OperacaoValida())
            return Ok(new
            {
                success=true,
                data=result
            });

            return BadRequest(new
            {
                success = false,
                errors = _notificador.GetNotificacao().Select(n=>n.Mensagem)
            }) ;
        }


        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in errors)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificaErro(erroMsg);
            }
        }

        protected void NotificaErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

     
    }
}
