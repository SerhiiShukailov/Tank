using Tank.Contracts.Project.Script.Contracts.Data;
using UnityEngine;

namespace Tank.Contracts.Project.Script.Contracts.Collisions {
  public readonly struct HitInfo {
    public readonly HitKind OtherKind;
    public readonly Team OtherTeam;
    public readonly Transform Other;
    public readonly Vector3 Point;
    public readonly Vector3 Normal;

    public HitInfo (HitKind otherKind, Team otherTeam, Transform other, Vector3 point, Vector3 normal) {
      OtherKind = otherKind;
      OtherTeam = otherTeam;
      Other = other;
      Point = point;
      Normal = normal;
    }
  }
}