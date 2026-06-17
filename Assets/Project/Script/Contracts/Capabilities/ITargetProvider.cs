using UnityEngine;

namespace Tank.Contracts.Project.Script.Contracts.Capabilities {
  public interface ITargetProvider {
    bool TryGetTarget (out Vector3 position);
  }
}