using Tank.Modules.Movement.Project.Script.Modules.Movement.Model;
using UnityEngine;

namespace Tank.Modules.Movement.Project.Script.Modules.Movement.Configs {
  [CreateAssetMenu(menuName = "Tank/Movement/MovementConfig", fileName = "MovementConfig")]
  public abstract class MovementConfig : ScriptableObject {
    public abstract IMovementModel CreateModel();
  }
}