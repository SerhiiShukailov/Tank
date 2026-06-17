using System;
using Tank.Contracts.Project.Script.Contracts.Lives;

namespace Tank.GameSession.Project.Script.GameSession.Lives {
  public class LivesModel : ILives {

    public event Action<int> Changed;

    public void Set (int value) {
      Value = value;
      Changed?.Invoke(Value);
    }

    public int Value { get; private set; }
  }
}
