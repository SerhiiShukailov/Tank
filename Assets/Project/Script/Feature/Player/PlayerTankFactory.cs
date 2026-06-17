using Tank.App.Project.Script.App.Communication;
using Tank.App.Project.Script.App.Services.Input;
using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using Tank.Contracts.Project.Script.Contracts.Events;
using Tank.Modules.TankCore.Project.Script.Modules.TankCore;
using Tank.Modules.TankCore.Project.Script.Modules.TankCore.Configs;
using UnityEngine;

namespace Tank.Feature.Project.Script.Feature.Player {
  public class PlayerTankFactory {
    private readonly TankEntity _prefab;
    private readonly IInputService _input;
    private readonly TankAppearanceConfig _appearance;
    private readonly IEventBus _events;

    public PlayerTankFactory (TankEntity prefab, IInputService input, TankAppearanceConfig appearance, IEventBus events) {
      _prefab = prefab;
      _input = input;
      _appearance = appearance;
      _events = events;
    }

    public PlayerTank Create (Vector3 position, Quaternion rotation) {
      TankEntity entity = Object.Instantiate(_prefab, position, rotation);
      entity.Configure(0, Team.Player);

      TankAppearance appearance = entity.GetComponent<TankAppearance>();

      if(appearance != null) {
        appearance.Apply(_appearance.For(Team.Player));
      }

      IMove move = entity.GetComponent<IMove>();
      IRotate rotate = entity.GetComponent<IRotate>();
      IWeapon weapon = entity.GetComponent<IWeapon>();
      IHealth health = entity.GetComponent<IHealth>();
      TankController commandPort = new TankController(move, rotate, weapon);

      PlayerInputDriver driver = entity.gameObject.AddComponent<PlayerInputDriver>();
      driver.Construct(_input, commandPort);

      health.Died += () => _events.Publish(new TankDestroyedEvent(0, Team.Player));

      return new PlayerTank(entity, commandPort, health);
    }
  }
}