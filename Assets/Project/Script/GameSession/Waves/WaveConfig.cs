using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Waves {
  [CreateAssetMenu(menuName = "Tank/Battle/WaveConfig", fileName = "WaveConfig")]
  public class WaveConfig : ScriptableObject {
    [SerializeField]
    private Entry [] _waves;
    [SerializeField]
    private int _randomMinEnemies = 1;
    [SerializeField]
    private int _randomMaxEnemies = 3;

    public IReadOnlyList<Entry> Waves {
      get {
        return _waves;
      }
    }
    public int RandomMinEnemies {
      get {
        return _randomMinEnemies;
      }
    }
    public int RandomMaxEnemies {
      get {
        return _randomMaxEnemies;
      }
    }
    [Serializable]
    public struct Entry {
      public int EnemyCount;
      public int CombatCount;
    }
  }
}