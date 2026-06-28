using Tank.Modules.Movement.Project.Script.Modules.Movement.Configs;
using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement.Model {
  public class ArcadeMovementModel : IMovementModel {
    private readonly ArcadeMovementConfig _config;

    private float _throttle;
    private float _steer;

    public ArcadeMovementModel (ArcadeMovementConfig config) {
      _config = config;
    }

    public void SetMoveInput (Vector2 direction) {
      _throttle = direction.y;
    }

    public void SetRotateInput (float angle) {
      _steer = angle;
    }

    public Vector3 CalculateVelocity (Transform transform) {
      return transform.forward * (_throttle * _config.MoveSpeed);
    }

    public Vector3 CalculateAngularVelocity() {
      return new Vector3(0f, CalculateAngularSpeed(), 0f);
    }

    private float CalculateAngularSpeed() {
      if(IsNotRotating()) {
        return 0f;
      }

      if(IsNotMoving() || IsTurnRadiusZero()) {
        return _steer * _config.RotateSpeed * Mathf.Deg2Rad;
      }

      float moveSpeed = Mathf.Abs(_throttle * _config.MoveSpeed);
      float angularSpeed = moveSpeed / _config.TurnRadius;

      return _steer * angularSpeed * CalculateRotationDirectionByMovement();
    }

    private bool IsNotRotating() {
      return Mathf.Approximately(_steer, 0f);
    }

    private bool IsNotMoving() {
      return Mathf.Approximately(_throttle, 0f);
    }

    private bool IsTurnRadiusZero() {
      return Mathf.Approximately(_config.TurnRadius, 0f);
    }

    private float CalculateRotationDirectionByMovement() {
      return _throttle > 0 ? 1 : -1;
    }
  }
}