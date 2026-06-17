using Tank.Contracts.Project.Script.Contracts.Data;

namespace Tank.Contracts.Project.Script.Contracts.Entities {
  public interface IDamageable {
    void TakeDamage (in DamageData damage);
  }
}