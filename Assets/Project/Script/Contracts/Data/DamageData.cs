using UnityEngine;

namespace Tank.Contracts.Project.Script.Contracts.Data {
  public readonly struct DamageData {
    public readonly float Amount;
    public readonly Team Source;
    public readonly Vector3 Point;

    public DamageData (float amount, Team source, Vector3 point) {
      Amount = amount;
      Source = source;
      Point = point;
    }
  }
}