using Cysharp.Threading.Tasks;
using Tank.GameSession.Project.Script.GameSession.Waves;
using Tank.Modules.UI.Project.Script.Modules.UI.Round;

namespace Tank.GameSession.Project.Script.GameSession.StateMachine.States {
  public class PrepareState : IGameState {
    private readonly GameSessionContext _context;
    private readonly IBattleField _field;
    private readonly IRoundBanner _banner;
    private readonly WaveSequence _sequence;

    public PrepareState (GameSessionContext context, IBattleField field, IRoundBanner banner, WaveSequence sequence) {
      _context = context;
      _field = field;
      _banner = banner;
      _sequence = sequence;
    }

    public async UniTask EnterAsync() {
      await _banner.Countdown();
      _field.SpawnWave(_sequence.Get(_context.Wave));
    }

    public UniTask ExitAsync() {
      return UniTask.CompletedTask;
    }
  }
}