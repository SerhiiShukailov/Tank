using System;

namespace Tank.Contracts.Project.Script.Contracts.Score {
  public interface IScore {
    event Action<int> Changed;

    void Add (int amount);

    void Set (int value);

    int Value { get; }
  }
}