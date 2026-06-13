using Tank.Contracts.Project.Script.Contracts.Data;
using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore.Configs {
  [CreateAssetMenu(menuName = "Tank/TankCore/AppearanceConfig", fileName = "TankAppearanceConfig")]
  public class TankAppearanceConfig : ScriptableObject {
    [SerializeField]
    private Material _playerMaterial;
    [SerializeField]
    private Material _enemyMaterial;
    [SerializeField]
    private Material _combatEnemyMaterial;

    public Material For (Team team) {
      return team == Team.Player ? _playerMaterial : _enemyMaterial;
    }

    public Material EnemyMaterial (bool combat) {
      return combat && _combatEnemyMaterial != null ? _combatEnemyMaterial : _enemyMaterial;
    }
  }
}
