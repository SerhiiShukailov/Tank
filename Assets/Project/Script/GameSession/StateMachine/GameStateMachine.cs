using Cysharp.Threading.Tasks;

namespace Tank.GameSession.Project.Script.GameSession.StateMachine {
  public class GameStateMachine {
    private IGameState _current;

    public async UniTask ChangeAsync (IGameState next) {
      if(_current != null) {
        await _current.ExitAsync();
      }

      _current = next;

      if(_current != null) {
        await _current.EnterAsync();
      }
    }
  }
}