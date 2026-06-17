using Tank.App.Project.Script.App.Communication;
using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using Tank.Contracts.Project.Script.Contracts.Events;
using Tank.Contracts.Project.Script.Contracts.Field;
using Tank.Modules.AI.Project.Script.Modules.AI;
using Tank.Modules.AI.Project.Script.Modules.AI.Behaviours;
using Tank.Modules.AI.Project.Script.Modules.AI.Configs;
using Tank.Modules.TankCore.Project.Script.Modules.TankCore;
using Tank.Modules.TankCore.Project.Script.Modules.TankCore.Configs;
using UnityEngine;

namespace Tank.Feature.Project.Script.Feature.Enemy {
  public class EnemyTankFactory {
    private readonly TankEntity _prefab;
    private readonly IField _field;
    private readonly AIConfig _aiConfig;
    private readonly TankAppearanceConfig _appearance;
    private readonly ITargetProvider _target;
    private readonly IEventBus _events;
    private int _nextId = 1;

    public EnemyTankFactory (TankEntity prefab, IField field, AIConfig aiConfig, TankAppearanceConfig appearance, ITargetProvider target, IEventBus events) {
      _prefab = prefab;
      _field = field;
      _aiConfig = aiConfig;
      _appearance = appearance;
      _target = target;
      _events = events;
    }

    public EnemyTank Create (Vector3 position, Quaternion rotation, bool combat) {
      TankEntity entity = Object.Instantiate(_prefab, position, rotation);
      entity.Configure(_nextId++, Team.Enemy);

      TankAppearance appearance = entity.GetComponent<TankAppearance>();

      if(appearance != null) {
        appearance.Apply(_appearance.EnemyMaterial(combat));
      }

      IMove move = entity.GetComponent<IMove>();
      IRotate rotate = entity.GetComponent<IRotate>();
      IWeapon weapon = entity.GetComponent<IWeapon>();
      IHealth health = entity.GetComponent<IHealth>();
      TankController commandPort = new TankController(move, rotate, weapon);
      AIContext context = new AIContext(commandPort, _field, _aiConfig, entity.transform, _target);
      IAIBehaviour behaviour = combat ? new CombatBehaviour(context) : new PatrolBehaviour(context);

      entity.gameObject.AddComponent<AIController>().Initialize(behaviour);

      int id = entity.Id;
      health.Died += () => _events.Publish(new TankDestroyedEvent(id, Team.Enemy));

      return new EnemyTank(entity, behaviour, health);
    }
  }
}