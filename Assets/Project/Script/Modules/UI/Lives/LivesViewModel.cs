using System;
using Tank.Contracts.Project.Script.Contracts.Lives;

namespace Tank.Modules.UI.Project.Script.Modules.UI.Lives {
  public class LivesViewModel : IDisposable {
    private readonly ILives _lives;

    public event Action<string> TextChanged;

    public LivesViewModel (ILives lives) {
      _lives = lives;
      _lives.Changed += OnLivesChanged;
      OnLivesChanged(_lives.Value);
    }

    public void Dispose() {
      _lives.Changed -= OnLivesChanged;
    }

    private void OnLivesChanged (int value) {
      Text = LivesConst.LIVES_TEXT + value;
      TextChanged?.Invoke(Text);
    }

    public string Text { get; private set; }
  }
}
