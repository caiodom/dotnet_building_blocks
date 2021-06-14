using Core.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Context
{
    public class MainContext:UnitOfWorkBase
    {
        protected Type _extToMapping;
        public MainContext(IConfiguration config)
            :base(config)
        {
            _TypeToMap = _extToMapping;
        }
    }
}
