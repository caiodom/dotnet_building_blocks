using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Application.ViewModel;
using Teste.Domain.Entities;

namespace Teste.WebApi.Configuration
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TesteEntity, TesteEntityViewModel>().ReverseMap();
            CreateMap<TesteEntityViewModel, TesteEntity>().ReverseMap();
        }
    }
}
