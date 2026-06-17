using Cysharp.Threading.Tasks;

namespace Tank.GameSession.Project.Script.GameSession.StateMachine {
  public interface IGameState {
    UniTask EnterAsync();

    UniTask ExitAsync();
  }
}