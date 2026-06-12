using System;
using System.Collections.Generic;

namespace Tank.App.Project.Script.App.Communication {
  public class EventBus : IEventBus {
    private readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

    public void Publish<TEvent> (TEvent message) {
      if(!_handlers.TryGetValue(typeof(TEvent), out List<Delegate> list)) {
        return;
      }

      for(int i = list.Count - 1; i >= 0; i--) {
        ((Action<TEvent>)list[i]).Invoke(message);
      }
    }

    public IDisposable Subscribe<TEvent> (Action<TEvent> handler) {
      Type type = typeof(TEvent);

      if(!_handlers.TryGetValue(type, out List<Delegate> list)) {
        list = new List<Delegate>();
        _handlers.Add(type, list);
      }

      list.Add(handler);
      return new Subscription(() => list.Remove(handler));
    }

    private class Subscription : IDisposable {
      private Action _dispose;

      public Subscription (Action dispose) {
        _dispose = dispose;
      }

      public void Dispose() {
        _dispose?.Invoke();
        _dispose = null;
      }
    }
  }
}