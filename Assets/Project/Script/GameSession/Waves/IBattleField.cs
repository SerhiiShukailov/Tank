namespace Tank.GameSession.Project.Script.GameSession.Waves {
  public interface IBattleField {

    void ResetGame();

    void SpawnPlayer();

    void SpawnWave (Wave wave);

    int AliveEnemies { get; }
  }
}