using Tank.Contracts.Project.Script.Contracts.Capabilities;
using Tank.Contracts.Project.Script.Contracts.Entities;
using Tank.Contracts.Project.Script.Contracts.Field;
using Tank.Modules.AI.Project.Script.Modules.AI.Configs;
using UnityEngine;

namespace Tank.Modules.AI.Project.Script.Modules.AI {
  public class AIContext {

    public AIContext (ICommandPort command, IField field, AIConfig config, Transform body, ITargetProvider target) {
      Command = command;
      Field = field;
      Config = config;
      Body = body;
      Target = target;
    }

    public ICommandPort Command { get; }
    public IField Field { get; }
    public AIConfig Config { get; }
    public Transform Body { get; }
    public ITargetProvider Target { get; }
  }
}