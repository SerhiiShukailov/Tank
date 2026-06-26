using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore {
  public class TankController : ICommandPort {
    private readonly IMove _move;
    private readonly IRotate _rotate;
    private readonly IWeapon _weapon;

    public TankController (IMove move, IRotate rotate, IWeapon weapon) {
      _move = move;
      _rotate = rotate;
      _weapon = weapon;
    }

    public void Move (Vector2 direction) {
      _rotate.Rotate(direction.x);
      _move.Move(new Vector2(0f, direction.y));
    }
    

    public void Fire() {
      _weapon.Fire();
    }
  }
}