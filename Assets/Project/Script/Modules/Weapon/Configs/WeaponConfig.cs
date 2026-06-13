using UnityEngine;

namespace Tank.Modules.Weapon.Project.Script.Modules.Weapon.Configs {
  [CreateAssetMenu(menuName = "Tank/Weapon/WeaponConfig", fileName = "WeaponConfig")]
  public class WeaponConfig : ScriptableObject {
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private float _projectileLifeTime;
    [SerializeField]
    private float _muzzleOffset;

    public float Damage {
      get {
        return _damage;
      }
    }
    public float Cooldown {
      get {
        return _cooldown;
      }
    }
    public float ProjectileSpeed {
      get {
        return _projectileSpeed;
      }
    }
    public float ProjectileLifeTime {
      get {
        return _projectileLifeTime;
      }
    }
    public float MuzzleOffset {
      get {
        return _muzzleOffset;
      }
    }
  }
}