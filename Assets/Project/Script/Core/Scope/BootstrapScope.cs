using UnityEngine;
using VContainer;
using VContainer.Unity;
public sealed class BootstrapScope : LifetimeScope {
  protected override void Configure (IContainerBuilder builder) {
    Debug.LogWarning("BootstrapScope Configure");
  }
}