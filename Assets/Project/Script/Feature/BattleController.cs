using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Tank.App.Project.Script.App.Communication;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Events;
using Tank.Contracts.Project.Script.Contracts.Lives;
using Tank.Feature.Project.Script.Feature.Enemy;
using Tank.Feature.Project.Script.Feature.Player;
using Tank.GameSession.Project.Script.GameSession.Spawn;
using Tank.GameSession.Project.Script.GameSession.Waves;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Tank.Feature.Project.Script.Feature {
  public class BattleController : IBattleField, IStartable, IDisposable {
    private readonly PlayerTankFactory _playerFactory;
    private readonly EnemyTankFactory _enemyFactory;
    private readonly ISpawnService _spawn;
    private readonly PlayerTargetProvider _playerTarget;
    private readonly IEventBus _events;
    private readonly BattleConfig _config;
    private readonly ILives _lives;
    private readonly Dictionary<int, GameObject> _tanks = new Dictionary<int, GameObject>();

    private IDisposable _subscription;

    public BattleController (
      PlayerTankFactory playerFactory, EnemyTankFactory enemyFactory, ISpawnService spawn, PlayerTargetProvider playerTarget, IEventBus events, BattleConfig config, ILives lives) {
      _playerFactory = playerFactory;
      _enemyFactory = enemyFactory;
      _spawn = spawn;
      _playerTarget = playerTarget;
      _events = events;
      _config = config;
      _lives = lives;
    }

    public void Start() {
      _subscription = _events.Subscribe<TankDestroyedEvent>(OnTankDestroyed);
    }

    public void ResetGame() {
      foreach(GameObject go in _tanks.Values) {
        if(go != null) {
          Object.Destroy(go);
        }
      }

      _tanks.Clear();
      _playerTarget.ClearTarget();
      AliveEnemies = 0;
      _lives.Set(_config.PlayerLives);
    }

    public void SpawnPlayer() {
      Vector3 pos = _spawn.ResolveSpawnPoint(Team.Player, Occupied());
      PlayerTank tank = _playerFactory.Create(pos, Quaternion.identity);
      _playerTarget.SetTarget(tank.Root.transform);
      _tanks[tank.Entity.Id] = tank.Root;
    }

    public void SpawnWave (Wave wave) {
      for(int i = 0; i < wave.EnemyCount; i++) {
        Vector3 pos = _spawn.ResolveSpawnPoint(Team.Enemy, Occupied());
        EnemyTank tank = _enemyFactory.Create(pos, Quaternion.identity, i < wave.CombatCount);
        _tanks[tank.Entity.Id] = tank.Root;
        AliveEnemies++;
      }
    }

    public void Dispose() {
      _subscription?.Dispose();
    }

    private void OnTankDestroyed (TankDestroyedEvent destroyed) {
      if(_tanks.TryGetValue(destroyed.EntityId, out GameObject go)) {
        _tanks.Remove(destroyed.EntityId);

        if(go != null) {
          Object.Destroy(go);
        }
      }

      if(destroyed.Team == Team.Enemy) {
        AliveEnemies--;
        return;
      }

      _playerTarget.ClearTarget();
      _lives.Set(_lives.Value - 1);

      if(_lives.Value > 0) {
        RespawnPlayerAsync().Forget();
      }
    }

    private async UniTaskVoid RespawnPlayerAsync() {
      await UniTask.Delay(TimeSpan.FromSeconds(_config.RespawnDelay));

      if(_lives.Value > 0) {
        SpawnPlayer();
      }
    }

    private List<Vector3> Occupied() {
      List<Vector3> points = new List<Vector3>(_tanks.Count);

      foreach(GameObject go in _tanks.Values) {
        if(go != null) {
          points.Add(go.transform.position);
        }
      }

      return points;
    }

    public int AliveEnemies { get; private set; }
  }
}