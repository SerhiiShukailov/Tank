using Tank.Contracts.Project.Script.Contracts.Data;
using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Score {
  [CreateAssetMenu(menuName = "Tank/Score/ScoreConfig", fileName = "ScoreConfig")]
  public class ScoreConfig : ScriptableObject {
    [SerializeField]
    private int _killReward;
    [SerializeField]
    private int _deathPenalty;

    public int RewardFor (Team team) {
      if(team == Team.Enemy) {
        return _killReward;
      }

      if(team == Team.Player) {
        return -_deathPenalty;
      }

      return 0;
    }
  }
}