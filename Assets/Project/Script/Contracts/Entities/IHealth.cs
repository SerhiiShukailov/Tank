using System;

namespace Tank.Contracts.Project.Script.Contracts.Entities {
  public interface IHealth {

    event Action<float> Changed;
    event Action Died;
    float Current { get; }
    float Max { get; }
    bool IsAlive { get; }
  }
}