using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore.Configs {
  [CreateAssetMenu(menuName = "Tank/TankCore/TankConfig", fileName = "TankConfig")]
  public class TankConfig : ScriptableObject {
    [SerializeField]
    private float _maxHealth;

    public float MaxHealth {
      get {
        return _maxHealth;
      }
    }
  }
}