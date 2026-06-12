using Tank.App.Project.Script.App.Communication;
using Tank.App.Project.Script.App.Services.Config;
using Tank.App.Project.Script.App.Services.Input;
using Tank.App.Project.Script.App.Services.Logging;
using Tank.App.Project.Script.App.Services.SaveLoad;
using Tank.App.Services;
using VContainer;
using VContainer.Unity;

namespace Tank.App.Project.Script.App {
  public class AppScope : LifetimeScope {
    protected override void Configure (IContainerBuilder builder) {
      builder.Register<ILogService, LogService>(Lifetime.Singleton);
      builder.Register<IEventBus, EventBus>(Lifetime.Singleton);
      builder.Register<IInputService, InputService>(Lifetime.Singleton);
      builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
      builder.Register<IConfigService, ConfigService>(Lifetime.Singleton);
    }
  }
}