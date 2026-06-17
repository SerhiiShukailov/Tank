using System;
using Tank.App.Project.Script.App.Communication;
using Tank.Contracts.Project.Script.Contracts.Events;
using Tank.Contracts.Project.Script.Contracts.Lives;
using Tank.Contracts.Project.Script.Contracts.Score;
using Tank.GameSession.Project.Script.GameSession.GameRules.Abstractions;
using Tank.GameSession.Project.Script.GameSession.Score;
using Tank.GameSession.Project.Script.GameSession.Waves;
using VContainer.Unity;

namespace Tank.GameSession.Project.Script.GameSession.GameRules {
  public class GameRules : IGameRules, IStartable, IDisposable {
    private readonly IEventBus _events;
    private readonly IScore _score;
    private readonly ScoreConfig _config;
    private readonly ILives _lives;
    private readonly IBattleField _field;
    private IDisposable _subscription;

    public GameRules (IEventBus events, IScore score, ScoreConfig config, ILives lives, IBattleField field) {
      _events = events;
      _score = score;
      _config = config;
      _lives = lives;
      _field = field;
    }

    public void Start() {
      _subscription = _events.Subscribe<TankDestroyedEvent>(OnTankDestroyed);
    }

    public void Dispose() {
      _subscription?.Dispose();
    }

    private void OnTankDestroyed (TankDestroyedEvent destroyed) {
      _score.Add(_config.RewardFor(destroyed.Team));
    }

    public bool IsGameOver {
      get {
        return _lives.Value <= 0;
      }
    }

    public bool IsWaveCleared {
      get {
        return _field.AliveEnemies == 0;
      }
    }
  }
}