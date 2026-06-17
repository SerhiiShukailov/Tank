using Cysharp.Threading.Tasks;
using Tank.Contracts.Project.Script.Contracts.Score;
using Tank.GameSession.Project.Script.GameSession.GameRules.Abstractions;
using Tank.GameSession.Project.Script.GameSession.StateMachine.States;
using Tank.GameSession.Project.Script.GameSession.Waves;
using Tank.Modules.UI.Project.Script.Modules.UI.Round;
using VContainer.Unity;

namespace Tank.GameSession.Project.Script.GameSession.StateMachine {
  public class GameFlow : IStartable {
    private readonly GameStateMachine _machine;
    private readonly GameSessionContext _context;
    private readonly IBattleField _field;
    private readonly IGameRules _rules;
    private readonly IScore _score;
    private readonly IRoundBanner _banner;
    private readonly PrepareState _prepare;
    private readonly BattleState _battle;
    private readonly EndGameState _endGame;

    public GameFlow (
      GameStateMachine machine, GameSessionContext context, IBattleField field, IGameRules rules, IScore score, IRoundBanner banner, PrepareState prepare, BattleState battle,
      EndGameState endGame) {
      _machine = machine;
      _context = context;
      _field = field;
      _rules = rules;
      _score = score;
      _banner = banner;
      _prepare = prepare;
      _battle = battle;
      _endGame = endGame;
    }

    public void Start() {
      RunAsync().Forget();
    }

    private async UniTaskVoid RunAsync() {
      while(true) {
        _field.ResetGame();
        _field.SpawnPlayer();
        _context.Wave = 1;

        while(!_rules.IsGameOver) {
          await _machine.ChangeAsync(_prepare);
          await _machine.ChangeAsync(_battle);

          if(_rules.IsGameOver) {
            break;
          }

          await _banner.Flash(string.Format(RoundBannerConst.WAVE_CLEARED_FORMAT, _context.Wave));
          _context.Wave++;
        }

        await _machine.ChangeAsync(_endGame);
        _score.Set(0);
      }
    }
  }
}