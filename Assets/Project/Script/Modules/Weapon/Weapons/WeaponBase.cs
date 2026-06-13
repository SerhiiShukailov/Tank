using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Modules.Weapon.Project.Script.Modules.Weapon.Configs;
using UnityEngine;

namespace Tank.Modules.Weapon.Project.Script.Modules.Weapon.Weapons {
  public abstract class WeaponBase : MonoBehaviour, IWeapon {
    [SerializeField]
    protected WeaponConfig _config;

    public abstract void Fire();

    public abstract bool CanFire { get; }
  }
}