namespace Tank.GameSession.Project.Script.GameSession.Waves {
  public readonly struct Wave {
    public readonly int EnemyCount;
    public readonly int CombatCount;

    public Wave (int enemyCount, int combatCount) {
      EnemyCount = enemyCount;
      CombatCount = combatCount;
    }
  }
}