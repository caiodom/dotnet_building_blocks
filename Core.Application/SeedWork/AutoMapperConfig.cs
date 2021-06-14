using AutoMapper;
using Core.Application.ViewModel;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.SeedWork
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<BaseEntity, BaseEntityViewModel>().ReverseMap();
            CreateMap<BaseEntityViewModel, BaseEntity>().ReverseMap();

        }
    }
}
