using VContainer;
using VContainer.Unity;

namespace Tank.Feature.Project.Script.Feature.Player {
  public class PlayerTankInstaller : IInstaller {
    public void Install (IContainerBuilder builder) {
      builder.Register<PlayerTankFactory>(Lifetime.Singleton);
    }
  }
}