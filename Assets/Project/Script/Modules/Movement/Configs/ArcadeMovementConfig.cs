using Tank.Modules.Movement.Project.Script.Modules.Movement.Model;
using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement.Configs {
  [CreateAssetMenu(menuName = "Tank/Movement/ArcadeMovementConfig", fileName = "ArcadeMovementConfig")]
  public class ArcadeMovementConfig : MovementConfig {
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private float _turnRadius;

    public override IMovementModel CreateModel() {
      return new ArcadeMovementModel(this);
    }

    public float MoveSpeed {
      get {
        return _moveSpeed;
      }
    }
    public float RotateSpeed {
      get {
        return _rotateSpeed;
      }
    }
    public float TurnRadius {
      get {
        return _turnRadius;
      }
    }
  }
}