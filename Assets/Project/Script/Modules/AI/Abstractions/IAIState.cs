namespace Tank.Modules.AI.Project.Script.Modules.AI.Abstractions {
  public interface IAIState {
    void Enter();

    void Tick (float deltaTime);

    void Exit();
  }
}