using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Service.Controller;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Teste.WebApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController:BaseAuthController<AuthController>
    {
        private readonly INotificadorService _notificador;
        public AuthController(INotificadorService notificadorService,
                                  IAppUser appUser,
                                  SignInManager<IdentityUser> signInManager,
                                  UserManager<IdentityUser> userManager,
                                  IOptions<AppSettings> appSettings,
                                  ILogger<AuthController> logger) :base(notificadorService,appUser,signInManager,userManager,appSettings,logger)
        {
            _notificador = notificadorService;
        }
    }
}
