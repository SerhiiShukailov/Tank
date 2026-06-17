using Tank.Contracts.Project.Script.Contracts.Data;
using UnityEngine;

namespace Tank.Contracts.Project.Script.Contracts.Entities {
  public interface IEntity {
    int Id { get; }
    Transform Transform { get; }
    Team Team { get; }
  }
}