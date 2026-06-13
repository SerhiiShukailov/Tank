using Tank.App.Project.Script.App.Services.Pooling;
using Tank.Modules.Weapon.Project.Script.Modules.Weapon.Projectiles;
using UnityEngine;

namespace Tank.Modules.Weapon.Project.Script.Modules.Weapon.Weapons {
  public class Cannon : WeaponBase {
    [SerializeField]
    private Shell _shellPrefab;
    [SerializeField]
    private Transform _muzzle;

    private Pool<Shell> _pool;
    private float _lastFireTime = -999f;

    private void Awake() {
      _pool = new Pool<Shell>(CreateShell);
    }

    public override bool CanFire {
      get {
        return _shellPrefab != null && _config != null && Time.time - _lastFireTime >= _config.Cooldown;
      }
    }

    public override void Fire() {
      if(!CanFire) {
        return;
      }

      Transform source = _muzzle != null ? _muzzle : transform;
      Vector3 origin = source.position + source.forward * _config.MuzzleOffset;

      Shell shell = _pool.Get();
      shell.Launch(origin, source.forward);
      _lastFireTime = Time.time;
    }

    private Shell CreateShell() {
      Shell shell = Instantiate(_shellPrefab);
      shell.Construct(projectile => _pool.Release((Shell)projectile), _config);
      return shell;
    }
  }
}