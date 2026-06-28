using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Modules.Movement.Project.Script.Modules.Movement.Configs;
using Tank.Modules.Movement.Project.Script.Modules.Movement.Model;
using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement {
  [RequireComponent(typeof(Rigidbody))]
  public class MovementController : MonoBehaviour, IMove, IRotate {
    [SerializeField]
    private MovementConfig _config;

    private Rigidbody _rigidbody;
    private IMovementModel _movementModel;

    private void Awake() {
      _rigidbody = GetComponent<Rigidbody>();
      _movementModel = _config.CreateModel();
    }

    private void FixedUpdate() {
      _rigidbody.velocity = _movementModel.CalculateVelocity(transform);
      _rigidbody.angularVelocity = _movementModel.CalculateAngularVelocity();
    }

    public void Move (Vector2 direction) {
      _movementModel.SetMoveInput(direction);
    }

    public void Rotate (float angle) {
      _movementModel.SetRotateInput(angle);
    }
  }
}