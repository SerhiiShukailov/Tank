using Tank.Contracts.Project.Script.Contracts.Data;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore {
  public class TankEntity : MonoBehaviour, IEntity {
    [SerializeField]
    private int _id;
    [SerializeField]
    private Team _team;

    public void Configure (int id, Team team) {
      _id = id;
      _team = team;
    }

    public int Id {
      get {
        return _id;
      }
    }
    public Transform Transform {
      get {
        return transform;
      }
    }
    public Team Team {
      get {
        return _team;
      }
    }
  }
}