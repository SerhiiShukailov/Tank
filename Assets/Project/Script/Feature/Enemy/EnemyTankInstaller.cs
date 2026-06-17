using VContainer;
using VContainer.Unity;

namespace Tank.Feature.Project.Script.Feature.Enemy {
  public class EnemyTankInstaller : IInstaller {
    public void Install (IContainerBuilder builder) {
      builder.Register<EnemyTankFactory>(Lifetime.Singleton);
    }
  }
}