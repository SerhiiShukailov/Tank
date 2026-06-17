using System.Collections.Generic;
using Tank.Contracts.Project.Script.Contracts.Data;
using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Spawn {
  public interface ISpawnService {
    Vector3 ResolveSpawnPoint (Team team, IReadOnlyList<Vector3> occupied);
  }
}