using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Domain.Entities
{
    public class TesteEntity : BaseEntity
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
