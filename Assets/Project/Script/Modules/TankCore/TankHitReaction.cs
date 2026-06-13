using Tank.Contracts.Project.Script.Contracts.Collisions;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore {
  [RequireComponent(typeof(TankEntity))]
  public class TankHitReaction : MonoBehaviour, IHitReceiver {
    private TankEntity _entity;
    private IDamageable _health;

    private void Awake() {
      _entity = GetComponent<TankEntity>();
      _health = GetComponent<IDamageable>();
    }

    public void OnHit (in HitInfo hit) {
      if(_entity.Team == Team.Player && hit.OtherKind == HitKind.Tank && hit.OtherTeam == Team.Enemy) {
        _health?.TakeDamage(new DamageData(9999f, hit.OtherTeam, hit.Point));
      }
    }
  }
}