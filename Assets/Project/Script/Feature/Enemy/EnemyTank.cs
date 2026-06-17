using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Feature.Project.Script.Feature.Enemy {
  public class EnemyTank {

    public EnemyTank (IEntity entity, IAIBehaviour behaviour, IHealth health) {
      Entity = entity;
      Behaviour = behaviour;
      Health = health;
      Root = entity.Transform.gameObject;
    }

    public IEntity Entity { get; }
    public IAIBehaviour Behaviour { get; }
    public IHealth Health { get; }
    public GameObject Root { get; }
  }
}