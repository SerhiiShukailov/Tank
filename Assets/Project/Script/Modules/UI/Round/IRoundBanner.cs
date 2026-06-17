using Cysharp.Threading.Tasks;

namespace Tank.Modules.UI.Project.Script.Modules.UI.Round {
  public interface IRoundBanner {
    UniTask Countdown();

    UniTask Flash (string text);
  }
}