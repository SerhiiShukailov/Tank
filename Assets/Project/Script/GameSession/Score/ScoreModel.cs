using System;
using Tank.Contracts.Project.Script.Contracts.Score;

namespace Tank.GameSession.Project.Script.GameSession.Score {
  public class ScoreModel : IScore {
    public event Action<int> Changed;

    public void Add (int amount) {
      Value += amount;
      Changed?.Invoke(Value);
    }

    public void Set (int value) {
      Value = value;
      Changed?.Invoke(Value);
    }

    public int Value { get; private set; }
  }
}