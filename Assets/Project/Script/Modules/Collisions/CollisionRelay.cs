using Tank.Contracts.Project.Script.Contracts.Collisions;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Modules.Collisions.Project.Script.Modules.Collisions {
  [RequireComponent(typeof(Collider))]
  public class CollisionRelay : MonoBehaviour {
    private IHitReceiver [] _receivers;

    private void Awake() {
      _receivers = GetComponents<IHitReceiver>();
    }

    private void OnCollisionEnter (Collision collision) {
      Dispatch(collision.collider);
    }

    private void OnTriggerEnter (Collider other) {
      Dispatch(other);
    }

    private void Dispatch (Collider other) {
      HitInfo hit = Classify(other);

      for(int i = 0; i < _receivers.Length; i++) {
        _receivers[i].OnHit(hit);
      }
    }

    private HitInfo Classify (Collider other) {
      IEntity entity = other.GetComponentInParent<IEntity>();

      if(entity != null) {
        return new HitInfo(HitKind.Tank, entity.Team, entity.Transform, transform.position, Vector3.zero);
      }

      return new HitInfo(HitKind.Wall, Team.None, other.transform, transform.position, Vector3.zero);
    }
  }
}