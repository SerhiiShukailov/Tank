using Tank.Contracts.Project.Script.Contracts.Capabilities;
using UnityEngine;

namespace Tank.Feature.Project.Script.Feature {
  public class PlayerTargetProvider : ITargetProvider {
    private Transform _target;

    public bool TryGetTarget (out Vector3 position) {
      if(_target != null) {
        position = _target.position;
        return true;
      }

      position = Vector3.zero;
      return false;
    }

    public void SetTarget (Transform target) {
      _target = target;
    }

    public void ClearTarget() {
      _target = null;
    }
  }
}