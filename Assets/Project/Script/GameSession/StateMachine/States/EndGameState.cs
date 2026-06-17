using Cysharp.Threading.Tasks;
using Tank.Modules.UI.Project.Script.Modules.UI.Round;

namespace Tank.GameSession.Project.Script.GameSession.StateMachine.States {
  public class EndGameState : IGameState {
    private readonly IRoundBanner _banner;

    public EndGameState (IRoundBanner banner) {
      _banner = banner;
    }

    public async UniTask EnterAsync() {
      await _banner.Flash(RoundBannerConst.GAME_OVER);
    }

    public UniTask ExitAsync() {
      return UniTask.CompletedTask;
    }
  }
}