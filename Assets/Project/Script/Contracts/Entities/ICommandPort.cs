using UnityEngine;

namespace Tank.Contracts.Project.Script.Contracts.Entities {
  public interface ICommandPort {
    void Move (Vector2 direction);

    void Fire();
  }
}