using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement.Model {
  public interface IMovementModel {
    void SetMoveInput (Vector2 direction);

    void SetRotateInput (float angle);

    Vector3 CalculateVelocity (Transform transform);

    Vector3 CalculateAngularVelocity();
  }
}