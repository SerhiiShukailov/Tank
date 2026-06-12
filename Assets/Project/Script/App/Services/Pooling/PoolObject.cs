using UnityEngine;

namespace Tank.App.Project.Script.App.Services.Pooling {
  public abstract class PoolObject : MonoBehaviour, IPoolObject {
    public virtual void OnSpawn() {
      gameObject.SetActive(true);
    }

    public virtual void OnDespawn() {
      gameObject.SetActive(false);
    }
  }
}