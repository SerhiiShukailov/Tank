using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Tank.Modules.UI.Project.Script.Modules.UI.Round {
  public class RoundBannerView : MonoBehaviour, IRoundBanner {
    [SerializeField]
    private TMP_Text _label;

    private void Awake() {
      Hide();
    }

    public async UniTask Countdown() {
      await ShowStep(RoundBannerConst.COUNT_3, RoundBannerConst.STEP_DURATION);
      await ShowStep(RoundBannerConst.COUNT_2, RoundBannerConst.STEP_DURATION);
      await ShowStep(RoundBannerConst.COUNT_1, RoundBannerConst.STEP_DURATION);
      await ShowStep(RoundBannerConst.BATTLE, RoundBannerConst.STEP_DURATION);
      Hide();
    }

    public async UniTask Flash (string text) {
      await ShowStep(text, RoundBannerConst.FLASH_DURATION);
      Hide();
    }

    private async UniTask ShowStep (string text, float duration) {
      if(_label == null) {
        await UniTask.Delay((int)(duration * 1000), cancellationToken: this.GetCancellationTokenOnDestroy());
        return;
      }

      _label.gameObject.SetActive(true);
      _label.text = text;

      float elapsed = 0f;

      while(elapsed < duration) {
        float scale = Mathf.Lerp(RoundBannerConst.POP_SCALE, 1f, Mathf.Clamp01(elapsed / duration * RoundBannerConst.POP_SPEED));
        _label.transform.localScale = Vector3.one * scale;
        elapsed += Time.deltaTime;
        await UniTask.Yield(this.GetCancellationTokenOnDestroy());
      }
    }

    private void Hide() {
      if(_label != null) {
        _label.gameObject.SetActive(false);
      }
    }
  }
}