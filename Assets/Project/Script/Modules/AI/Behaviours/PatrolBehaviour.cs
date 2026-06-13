using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Collisions;
using Tank.Modules.AI.Project.Script.Modules.AI.States;

namespace Tank.Modules.AI.Project.Script.Modules.AI.Behaviours {
  public class PatrolBehaviour : IAIBehaviour, IHitReceiver {
    private readonly AIPatrolState _patrol;

    public PatrolBehaviour (AIContext context) {
      _patrol = new AIPatrolState(context);
      _patrol.Enter();
    }

    public void Tick (float deltaTime) {
      _patrol.Tick(deltaTime);
    }

    public void OnHit (in HitInfo hit) {
      _patrol.Bounce();
    }
  }
}