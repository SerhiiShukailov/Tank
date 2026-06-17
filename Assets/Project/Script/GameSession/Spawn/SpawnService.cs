using System.Collections.Generic;
using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Field;
using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Spawn {
  public class SpawnService : ISpawnService {
    private const float MIN_SPACING = 4f;
    private const int MAX_ATTEMPTS = 16;

    private readonly IField _field;

    public SpawnService (IField field) {
      _field = field;
    }

    public Vector3 ResolveSpawnPoint (Team team, IReadOnlyList<Vector3> occupied) {
      Vector3 candidate = Pick(team);

      for(int attempt = 0; attempt < MAX_ATTEMPTS; attempt++) {
        candidate = Pick(team);

        if(IsFree(candidate, occupied)) {
          break;
        }
      }

      return candidate;
    }

    private Vector3 Pick (Team team) {
      return team == Team.Player ? _field.RandomCornerPoint() : _field.RandomBorderPoint();
    }

    private bool IsFree (Vector3 point, IReadOnlyList<Vector3> occupied) {
      for(int i = 0; i < occupied.Count; i++) {
        if((occupied[i] - point).sqrMagnitude < MIN_SPACING * MIN_SPACING) {
          return false;
        }
      }

      return true;
    }
  }
}