using Tank.App.Services;

namespace Tank.App.Project.Script.App.Services.Pooling {
  public interface IPool<TItem> where TItem : IPoolObject {
    TItem Get();

    void Release (TItem item);
  }
}