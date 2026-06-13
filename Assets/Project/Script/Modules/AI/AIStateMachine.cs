using Tank.Modules.AI.Project.Script.Modules.AI.Abstractions;

namespace Tank.Modules.AI.Project.Script.Modules.AI {
  public class AIStateMachine {
    private IAIState _current;

    public void Change (IAIState next) {
      _current?.Exit();
      _current = next;
      _current?.Enter();
    }

    public void Tick (float deltaTime) {
      _current?.Tick(deltaTime);
    }
  }
}