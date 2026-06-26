using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Modules.Movement.Project.Script.Modules.Movement.Configs;
using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement {
  [RequireComponent(typeof(Rigidbody))]
  public class MovementController : MonoBehaviour, IMove, IRotate {
    [SerializeField]
    private MovementConfig _config;

    private Rigidbody _rigidbody;
    private float _throttle;
    private float _steer;

    private void Awake() {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
      if(_config == null) {
        return;
      }

      _rigidbody.velocity = CalculateMoveVelocity();
      _rigidbody.angularVelocity = CalculateRotateVelocity();
    }

    public void Move (Vector2 direction) {
      _throttle = direction.y;
    }

    public void Rotate (float angle) {
      _steer = angle;
    }

    private Vector3 CalculateMoveVelocity() {
      return transform.forward * (_throttle * _config.MoveSpeed);
    }

    private Vector3 CalculateRotateVelocity() {
      return new Vector3(0f, CalculateAngularSpeed(), 0f);
    }

    private float CalculateAngularSpeed() {
      if(IsNotRotating()) {
        return 0f;
      }

      if(IsNotMoving()) {
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

    private float CalculateRotationDirectionByMovement() {
      return _throttle > 0 ? 1 : -1;
    }
  }
}