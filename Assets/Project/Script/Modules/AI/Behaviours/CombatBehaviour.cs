using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Collisions;
using Tank.Modules.AI.Project.Script.Modules.AI.Abstractions;
using Tank.Modules.AI.Project.Script.Modules.AI.States;
using UnityEngine;

namespace Tank.Modules.AI.Project.Script.Modules.AI.Behaviours {
  public class CombatBehaviour : IAIBehaviour, IHitReceiver {
    private readonly AIContext _context;
    private readonly AIStateMachine _machine = new AIStateMachine();
    private readonly AIPatrolState _patrol;
    private readonly AIBattleState _battle;
    private IAIState _active;

    public CombatBehaviour (AIContext context) {
      _context = context;
      _patrol = new AIPatrolState(context);
      _battle = new AIBattleState(context);
      SetState(_patrol);
    }

    public void Tick (float deltaTime) {
      SetState(InRange() ? _battle : _patrol);
      _machine.Tick(deltaTime);
    }

    public void OnHit (in HitInfo hit) {
      _patrol.Bounce();
    }

    private bool InRange() {
      if(!_context.Target.TryGetTarget(out Vector3 target)) {
        return false;
      }

      float range = _context.Config.ViewRadius;
      return (target - _context.Body.position).sqrMagnitude <= range * range;
    }

    private void SetState (IAIState state) {
      if(_active == state) {
        return;
      }

      _active = state;
      _machine.Change(state);
    }
  }
}