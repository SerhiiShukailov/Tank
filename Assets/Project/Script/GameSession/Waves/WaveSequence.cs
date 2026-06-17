using System.Collections.Generic;
using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Waves {
  public class WaveSequence {
    private readonly WaveConfig _config;

    public WaveSequence (WaveConfig config) {
      _config = config;
    }

    public Wave Get (int waveNumber) {
      int index = waveNumber - 1;
      IReadOnlyList<WaveConfig.Entry> waves = _config.Waves;

      if(waves != null && index >= 0 && index < waves.Count) {
        WaveConfig.Entry entry = waves[index];
        return new Wave(entry.EnemyCount, entry.CombatCount);
      }

      int count = Random.Range(_config.RandomMinEnemies, _config.RandomMaxEnemies + 1);
      int combat = Random.Range(0, count + 1);
      return new Wave(count, combat);
    }
  }
}