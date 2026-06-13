using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Collisions;
using UnityEngine;

namespace Tank.Modules.AI.Project.Script.Modules.AI {
  public class AIController : MonoBehaviour, IHitReceiver {
    private IAIBehaviour _behaviour;
    private IHitReceiver _hitReceiver;

    private void Update() {
      if(_behaviour != null) {
        _behaviour.Tick(Time.deltaTime);
      }
    }

    public void OnHit (in HitInfo hit) {
      _hitReceiver?.OnHit(hit);
    }

    public void Initialize (IAIBehaviour behaviour) {
      _behaviour = behaviour;
      _hitReceiver = behaviour as IHitReceiver;
    }
  }
}