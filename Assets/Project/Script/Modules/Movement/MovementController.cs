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

      _rigidbody.velocity = transform.forward * (_throttle * _config.MoveSpeed);
      _rigidbody.angularVelocity = new Vector3(0f, _steer * _config.RotateSpeed * Mathf.Deg2Rad, 0f);
    }

    public void Move (Vector2 direction, float deltaTime) {
      _throttle = direction.y;
    }

    public void Rotate (float angle, float deltaTime) {
      _steer = angle;
    }
  }
}