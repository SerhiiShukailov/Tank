using System;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore {
  public class TankHealth : MonoBehaviour, IHealth, IDamageable {
    public event Action<float> Changed;
    public event Action Died;

    [SerializeField]
    private float _max;

    private void Awake() {
      Current = _max;
    }

    public void TakeDamage (in DamageData damage) {
      if(!IsAlive) {
        return;
      }

      Current = Mathf.Max(0f, Current - damage.Amount);
      Changed?.Invoke(Current);

      if(!IsAlive) {
        Died?.Invoke();
      }
    }

    public void Revive() {
      Current = _max;
      Changed?.Invoke(Current);
    }

    public float Current { get; private set; }
    public float Max {
      get {
        return _max;
      }
    }
    public bool IsAlive {
      get {
        return Current > 0f;
      }
    }
  }
}