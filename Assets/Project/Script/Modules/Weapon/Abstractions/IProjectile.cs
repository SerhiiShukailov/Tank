using UnityEngine;

namespace Tank.Modules.Weapon.Project.Script.Modules.Weapon.Abstractions {
  public interface IProjectile {
    void Launch (Vector3 origin, Vector3 direction);
  }
}