using System;
using Tank.Contracts.Project.Script.Contracts.Score;

namespace Tank.Modules.UI.Project.Script.Modules.UI.Score {
  public class ScoreViewModel : IDisposable {
    private readonly IScore _score;

    public event Action<string> TextChanged;

    public ScoreViewModel (IScore score) {
      _score = score;
      _score.Changed += OnScoreChanged;
      OnScoreChanged(_score.Value);
    }

    public void Dispose() {
      _score.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged (int value) {
      Text = ScoreConst.SCORE_TEXT + value;
      TextChanged?.Invoke(Text);
    }

    public string Text { get; private set; }
  }
}