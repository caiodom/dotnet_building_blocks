using Core.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Infra.Data.Context
{
    public class MyAppContext:MainContext
    {
        public MyAppContext(IConfiguration config):base(config)
        {
            base._extToMapping = typeof(MyAppContext);
        }
    }
}
