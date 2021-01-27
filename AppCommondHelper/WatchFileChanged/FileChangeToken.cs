using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCommondHelper.WatchFileChanged
{
    public static class ChangeToken
    {
        public static IDisposable OnChange(Func<IChangeToken> changeTokenProducer, Action changeTokenConsumer)
        {
            Action<object> callback = null;
            callback = delegate (object s)
            {
                changeTokenConsumer();
                changeTokenProducer().RegisterChangeCallback(callback, null);
            };
            return changeTokenProducer().RegisterChangeCallback(callback, null);
        }

        public static IDisposable OnChange<TState>(Func<IChangeToken> changeTokenProducer, Action<TState> changeTokenConsumer, TState state)
        {
            Action<object> callback = null;
            callback = delegate (object s)
            {
                changeTokenConsumer((TState)s);
                changeTokenProducer().RegisterChangeCallback(callback, s);
            };
            return changeTokenProducer().RegisterChangeCallback(callback, state);
        }
    }
}
