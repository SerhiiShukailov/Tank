using System;
using System.Collections.Generic;

namespace Tank.App.Project.Script.App.Services.Pooling {
  public class Pool<TItem> : IPool<TItem> where TItem : IPoolObject {
    private readonly Func<TItem> _factory;
    private readonly Queue<TItem> _free = new Queue<TItem>();

    public Pool (Func<TItem> factory) {
      _factory = factory;
    }

    public TItem Get() {
      TItem item = _free.Count > 0 ? _free.Dequeue() : _factory();
      item.OnSpawn();
      return item;
    }

    public void Release (TItem item) {
      item.OnDespawn();
      _free.Enqueue(item);
    }
  }
}