using Tank.Modules.AI.Project.Script.Modules.AI.Abstractions;
using UnityEngine;

namespace Tank.Modules.AI.Project.Script.Modules.AI.States {
  public class AIPatrolState : IAIState {
    private const float STEER_SENSITIVITY = 30f;
    private const float STUCK_CHECK_INTERVAL = 0.4f;
    private const float MIN_PROGRESS_SQR = 0.25f;

    private readonly AIContext _context;
    private float _heading;
    private float _timer;
    private float _reverseTimer;
    private float _stuckTimer;
    private Vector3 _lastProgressPosition;

    public AIPatrolState (AIContext context) {
      _context = context;
    }

    public void Enter() {
      _lastProgressPosition = _context.Body.position;
      _stuckTimer = 0f;
      HeadToCenter();
    }

    public void Tick (float deltaTime) {
      float steer = SteerToHeading();

      if(_reverseTimer > 0f) {
        _reverseTimer -= deltaTime;
        _context.Command.Move(new Vector2(steer, -1f));
        return;
      }

      if(IsStuck(deltaTime)) {
        Bounce();
        return;
      }

      _timer += deltaTime;

      if(_timer >= _context.Config.DirectionChangeInterval) {
        ForceTurn();
      }

      _context.Command.Move(new Vector2(steer, 1f));
    }

    public void Exit() {}

    public void ForceTurn() {
      _heading = Random.Range(0f, 360f);
      _timer = 0f;
    }

    public void Bounce() {
      _heading = _context.Body.eulerAngles.y + 180f;
      _reverseTimer = _context.Config.ReverseDuration;
      _timer = 0f;
    }

    private bool IsStuck (float deltaTime) {
      _stuckTimer += deltaTime;

      if(_stuckTimer < STUCK_CHECK_INTERVAL) {
        return false;
      }

      _stuckTimer = 0f;
      Vector3 position = _context.Body.position;
      bool stuck = (position - _lastProgressPosition).sqrMagnitude < MIN_PROGRESS_SQR;
      _lastProgressPosition = position;
      return stuck;
    }

    private void HeadToCenter() {
      Vector3 toCenter = _context.Field.Area.center - _context.Body.position;
      _heading = Mathf.Atan2(toCenter.x, toCenter.z) * Mathf.Rad2Deg;
      _timer = 0f;
    }

    private float SteerToHeading() {
      float delta = Mathf.DeltaAngle(_context.Body.eulerAngles.y, _heading);
      return Mathf.Clamp(delta / STEER_SENSITIVITY, -1f, 1f);
    }
  }
}