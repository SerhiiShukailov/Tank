using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Arena {
  [CreateAssetMenu(menuName = "Tank/Arena/ArenaConfig", fileName = "ArenaConfig")]
  public class ArenaConfig : ScriptableObject {
    [SerializeField]
    private Vector3 _size;
    [SerializeField]
    private float _wallHeight;
    [SerializeField]
    private float _wallThickness;
    [SerializeField]
    private float _spawnMargin;

    public Vector3 Size {
      get {
        return _size;
      }
    }
    public float WallHeight {
      get {
        return _wallHeight;
      }
    }
    public float WallThickness {
      get {
        return _wallThickness;
      }
    }
    public float SpawnMargin {
      get {
        return _spawnMargin;
      }
    }
  }
}