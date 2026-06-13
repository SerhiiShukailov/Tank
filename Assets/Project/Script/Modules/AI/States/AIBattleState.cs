using Tank.Modules.AI.Project.Script.Modules.AI.Abstractions;
using UnityEngine;

namespace Tank.Modules.AI.Project.Script.Modules.AI.States {
  public class AIBattleState : IAIState {
    private const float STEER_SENSITIVITY = 30f;
    private const float FIRE_ANGLE = 12f;

    private readonly AIContext _context;

    public AIBattleState (AIContext context) {
      _context = context;
    }

    public void Enter() {}

    public void Tick (float deltaTime) {
      if(!_context.Target.TryGetTarget(out Vector3 target)) {
        return;
      }

      Vector3 toTarget = target - _context.Body.position;
      float desired = Mathf.Atan2(toTarget.x, toTarget.z) * Mathf.Rad2Deg;
      float delta = Mathf.DeltaAngle(_context.Body.eulerAngles.y, desired);
      float steer = Mathf.Clamp(delta / STEER_SENSITIVITY, -1f, 1f);

      _context.Command.Move(new Vector2(steer, 0f));

      if(Mathf.Abs(delta) <= FIRE_ANGLE) {
        _context.Command.Fire();
      }
    }

    public void Exit() {}
  }
}