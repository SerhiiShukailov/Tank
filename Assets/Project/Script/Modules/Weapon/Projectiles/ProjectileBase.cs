using System;
using Tank.App.Project.Script.App.Services.Pooling;
using Tank.Contracts.Project.Script.Contracts.Collisions;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using Tank.Modules.Weapon.Project.Script.Modules.Weapon.Abstractions;
using Tank.Modules.Weapon.Project.Script.Modules.Weapon.Configs;
using UnityEngine;

namespace Tank.Modules.Weapon.Project.Script.Modules.Weapon.Projectiles {
  public abstract class ProjectileBase : PoolObject, IProjectile, IHitReceiver {
    private Action<ProjectileBase> _release;
    private WeaponConfig _config;
    private Vector3 _velocity;
    private float _age;

    protected virtual void Update() {
      transform.position += _velocity * Time.deltaTime;

      _age += Time.deltaTime;

      if(_age >= _config.ProjectileLifeTime) {
        Release();
      }
    }

    public virtual void OnHit (in HitInfo hit) {
      if(hit.OtherKind == HitKind.Tank && hit.Other != null) {
        IDamageable damageable = hit.Other.GetComponentInParent<IDamageable>();
        damageable?.TakeDamage(new DamageData(_config.Damage, Team.None, hit.Point));
      }

      Release();
    }

    public virtual void Launch (Vector3 origin, Vector3 direction) {
      if(direction.sqrMagnitude < 0.0001f) {
        direction = Vector3.forward;
      }

      direction.Normalize();
      transform.SetPositionAndRotation(origin, Quaternion.LookRotation(direction));
      _velocity = direction * _config.ProjectileSpeed;
      _age = 0f;
    }

    public void Construct (Action<ProjectileBase> release, WeaponConfig config) {
      _release = release;
      _config = config;
    }

    private void Release() {
      _release?.Invoke(this);
    }
  }
}