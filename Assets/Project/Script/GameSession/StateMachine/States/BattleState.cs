using Cysharp.Threading.Tasks;
using Tank.GameSession.Project.Script.GameSession.GameRules.Abstractions;

namespace Tank.GameSession.Project.Script.GameSession.StateMachine.States {
  public class BattleState : IGameState {
    private readonly IGameRules _rules;

    public BattleState (IGameRules rules) {
      _rules = rules;
    }

    public async UniTask EnterAsync() {
      await UniTask.WaitUntil(() => _rules.IsWaveCleared || _rules.IsGameOver);
    }

    public UniTask ExitAsync() {
      return UniTask.CompletedTask;
    }
  }
}
