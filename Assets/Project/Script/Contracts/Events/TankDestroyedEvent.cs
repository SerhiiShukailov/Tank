using Tank.Contracts.Project.Script.Contracts.Data;

namespace Tank.Contracts.Project.Script.Contracts.Events {
  public readonly struct TankDestroyedEvent {
    public readonly int EntityId;
    public readonly Team Team;

    public TankDestroyedEvent (int entityId, Team team) {
      EntityId = entityId;
      Team = team;
    }
  }
}