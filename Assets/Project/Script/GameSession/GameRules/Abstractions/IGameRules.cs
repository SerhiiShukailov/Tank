namespace Tank.GameSession.Project.Script.GameSession.GameRules.Abstractions {
  public interface IGameRules {
    bool IsGameOver { get; }

    bool IsWaveCleared { get; }
  }
}
