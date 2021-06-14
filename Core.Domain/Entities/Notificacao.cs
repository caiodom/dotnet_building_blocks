using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
  public  class Notificacao
    {

        public string Mensagem { get; set; }
        public Notificacao(string mensagem)
        {
            this.Mensagem = mensagem;
        }
    }
}
