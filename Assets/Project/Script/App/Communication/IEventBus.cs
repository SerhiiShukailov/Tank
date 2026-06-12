using System;

namespace Tank.App.Project.Script.App.Communication {
  public interface IEventBus {
    void Publish<TEvent> (TEvent message);

    IDisposable Subscribe<TEvent> (Action<TEvent> handler);
  }
}