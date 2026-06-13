using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement.Configs {
  [CreateAssetMenu(menuName = "Tank/Movement/MovementConfig", fileName = "MovementConfig")]
  public class MovementConfig : ScriptableObject {
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private float _turnRadius;

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