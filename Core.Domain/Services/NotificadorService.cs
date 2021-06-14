using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Services
{
    public class NotificadorService:INotificadorService
    {

        private List<Notificacao> _notificacoes;
        public NotificadorService()
        {
            _notificacoes = new List<Notificacao>();
        }
 
        public List<Notificacao> GetNotificacao()
        {
            return _notificacoes;
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HasNotification()
        {
            return _notificacoes.Any();
        }
    }
}
