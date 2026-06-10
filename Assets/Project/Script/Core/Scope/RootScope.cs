using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Core {
  public class RootScope : LifetimeScope {
    protected override void Configure (IContainerBuilder builder) {
      Debug.LogWarning("RootScope Configureq");
    }
  }
}