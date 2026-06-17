using System;

namespace Tank.Contracts.Project.Script.Contracts.Lives {
  public interface ILives {
    event Action<int> Changed;

    void Set (int value);

    int Value { get; }
  }
}
