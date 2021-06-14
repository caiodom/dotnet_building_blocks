using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces
{
    public interface INotificadorService
    {
        bool HasNotification();

        List<Notificacao> GetNotificacao();

        void Handle(Notificacao notificacao);
    }
}
