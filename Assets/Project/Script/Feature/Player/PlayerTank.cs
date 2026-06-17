using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Feature.Project.Script.Feature.Player {
  public class PlayerTank {

    public PlayerTank (IEntity entity, ICommandPort commandPort, IHealth health) {
      Entity = entity;
      CommandPort = commandPort;
      Health = health;
      Root = entity.Transform.gameObject;
    }

    public IEntity Entity { get; }
    public ICommandPort CommandPort { get; }
    public IHealth Health { get; }
    public GameObject Root { get; }
  }
}