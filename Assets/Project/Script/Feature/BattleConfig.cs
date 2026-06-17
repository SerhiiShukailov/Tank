using UnityEngine;

namespace Tank.Feature.Project.Script.Feature {
  [CreateAssetMenu(menuName = "Tank/Battle/BattleConfig", fileName = "BattleConfig")]
  public class BattleConfig : ScriptableObject {
    [SerializeField]
    private int _playerLives = 3;
    [SerializeField]
    private float _respawnDelay = 1f;

    public int PlayerLives {
      get {
        return _playerLives;
      }
    }
    public float RespawnDelay {
      get {
        return _respawnDelay;
      }
    }
  }
}
