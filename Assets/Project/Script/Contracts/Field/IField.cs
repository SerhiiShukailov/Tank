using UnityEngine;

namespace Tank.Contracts.Project.Script.Contracts.Field {
  public interface IField {
    Vector3 RandomBorderPoint();
    Vector3 RandomCornerPoint();
    Bounds Area { get; }
  }
}