using Tank.App.Project.Script.App.Communication;
using Tank.App.Project.Script.App.Services.Config;
using Tank.App.Project.Script.App.Services.Input;
using Tank.App.Project.Script.App.Services.SaveLoad;
using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Field;
using Tank.Contracts.Project.Script.Contracts.Lives;
using Tank.Contracts.Project.Script.Contracts.Score;
using Tank.Feature.Project.Script.Feature.Enemy;
using Tank.Feature.Project.Script.Feature.Player;
using Tank.GameSession.Project.Script.GameSession.GameRules.Abstractions;
using Tank.GameSession.Project.Script.GameSession.Lives;
using Tank.GameSession.Project.Script.GameSession.Score;
using Tank.GameSession.Project.Script.GameSession.Spawn;
using Tank.GameSession.Project.Script.GameSession.StateMachine;
using Tank.GameSession.Project.Script.GameSession.StateMachine.States;
using Tank.GameSession.Project.Script.GameSession.Waves;
using Tank.Modules.AI.Project.Script.Modules.AI.Configs;
using Tank.Modules.TankCore.Project.Script.Modules.TankCore;
using Tank.Modules.TankCore.Project.Script.Modules.TankCore.Configs;
using Tank.Modules.UI.Project.Script.Modules.UI.Lives;
using Tank.Modules.UI.Project.Script.Modules.UI.Round;
using Tank.Modules.UI.Project.Script.Modules.UI.Score;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ArenaComponent = Tank.GameSession.Project.Script.GameSession.Arena.Arena;
using GameRulesService = Tank.GameSession.Project.Script.GameSession.GameRules.GameRules;

namespace Tank.Feature.Project.Script.Feature {
  public class GameRoot : LifetimeScope {
    [SerializeField]
    private TankEntity _tankPrefab;

    protected override void Configure (IContainerBuilder builder) {
      RegisterService(builder);
      RegisterConfig(builder);
      RegisterPrefab(builder);
      RegisterMetaComponent(builder);
      CreateTanksInstaller(builder);
      RegisterGameFlow(builder);
    }

    private void RegisterService (IContainerBuilder builder) {
      builder.Register<IInputService, InputService>(Lifetime.Singleton);
      builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
      builder.RegisterComponentInHierarchy<ArenaComponent>().As<IField>();
      builder.Register<ISpawnService, SpawnService>(Lifetime.Singleton);
      builder.Register<PlayerTargetProvider>(Lifetime.Singleton).AsSelf().As<ITargetProvider>();
    }

    private void RegisterConfig (IContainerBuilder builder) {
      ConfigService configs = new ConfigService();
      builder.RegisterInstance<IConfigService>(configs);
      builder.RegisterInstance(configs.Get<AIConfig>());
      builder.RegisterInstance(configs.Get<TankAppearanceConfig>());
      builder.RegisterInstance(configs.Get<ScoreConfig>());
      builder.RegisterInstance(configs.Get<BattleConfig>());
      builder.RegisterInstance(configs.Get<WaveConfig>());
    }

    private void RegisterPrefab (IContainerBuilder builder) {
      builder.RegisterInstance(_tankPrefab);
    }

    private void RegisterMetaComponent (IContainerBuilder builder) {
      builder.Register<IEventBus, EventBus>(Lifetime.Singleton);
      builder.Register<IScore, ScoreModel>(Lifetime.Singleton);
      builder.Register<ScoreViewModel>(Lifetime.Singleton);
      builder.RegisterComponentInHierarchy<ScoreView>();
      builder.Register<ILives, LivesModel>(Lifetime.Singleton);
      builder.Register<LivesViewModel>(Lifetime.Singleton);
      builder.RegisterComponentInHierarchy<LivesView>();
      builder.RegisterComponentInHierarchy<RoundBannerView>().As<IRoundBanner>();
    }

    private void CreateTanksInstaller (IContainerBuilder builder) {
      new PlayerTankInstaller().Install(builder);
      new EnemyTankInstaller().Install(builder);
    }

    private void RegisterGameFlow (IContainerBuilder builder) {
      builder.Register<WaveSequence>(Lifetime.Singleton);
      builder.Register<GameSessionContext>(Lifetime.Singleton);
      builder.Register<GameStateMachine>(Lifetime.Singleton);
      builder.Register<PrepareState>(Lifetime.Singleton);
      builder.Register<BattleState>(Lifetime.Singleton);
      builder.Register<EndGameState>(Lifetime.Singleton);

      builder.RegisterEntryPoint<GameRulesService>().As<IGameRules>();
      builder.RegisterEntryPoint<BattleController>().As<IBattleField>();
      builder.RegisterEntryPoint<GameFlow>();
      builder.Register<BattlePersistence>(Lifetime.Singleton).As<ISavable>();
      builder.RegisterComponentInHierarchy<SaveLoadRunner>();
    }
  }
}