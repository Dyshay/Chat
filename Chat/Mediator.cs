using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Mediator<TMessage>
    {
        private Action<TMessage> _Broadcast;

        private static Mediator<TMessage> _Instance;
        public static Mediator<TMessage> Instance
        {
            get
            {
                return _Instance ?? (_Instance = new Mediator<TMessage>());
            }
        }

        public void Send(TMessage Message)
        {
            _Broadcast?.Invoke(Message);
        }

        public void Register(Action<TMessage> Method)
        {
            _Broadcast += Method;
        }

        public void UnRegister(Action<TMessage> Method)
        {
            _Broadcast -= Method;
        }
    }
}
