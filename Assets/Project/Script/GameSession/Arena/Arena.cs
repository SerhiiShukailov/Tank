using Tank.Contracts.Project.Script.Contracts.Field;
using UnityEngine;

namespace Tank.GameSession.Project.Script.GameSession.Arena {
  public class Arena : MonoBehaviour, IField {
    [SerializeField]
    private ArenaConfig _config;
    [SerializeField]
    private GameObject _wallPrefab;

    private void Awake() {
      BuildWalls();
    }


    public Vector3 RandomBorderPoint() {
      Bounds b = Area;
      float margin = _config.SpawnMargin;
      float minX = b.min.x + margin;
      float maxX = b.max.x - margin;
      float minZ = b.min.z + margin;
      float maxZ = b.max.z - margin;

      float x,
        z;

      if(Random.value < 0.5f) {
        x = Random.value < 0.5f ? minX : maxX;
        z = Random.Range(minZ, maxZ);
      } else {
        x = Random.Range(minX, maxX);
        z = Random.value < 0.5f ? minZ : maxZ;
      }

      return new Vector3(x, transform.position.y, z);
    }

    public Vector3 RandomCornerPoint() {
      Bounds b = Area;
      float margin = _config.SpawnMargin;
      float x = Random.value < 0.5f ? b.min.x + margin : b.max.x - margin;
      float z = Random.value < 0.5f ? b.min.z + margin : b.max.z - margin;
      return new Vector3(x, transform.position.y, z);
    }

    private void BuildWalls() {
      if(_wallPrefab == null) {
        return;
      }

      Bounds b = Area;
      Vector3 c = b.center;
      float thickness = _config.WallThickness;
      float height = _config.WallHeight;
      float half = thickness * 0.5f;
      float width = b.size.x + thickness * 2f;
      float depth = b.size.z + thickness * 2f;

      SpawnWall(new Vector3(c.x, c.y, b.max.z + half), new Vector3(width, height, thickness));
      SpawnWall(new Vector3(c.x, c.y, b.min.z - half), new Vector3(width, height, thickness));
      SpawnWall(new Vector3(b.max.x + half, c.y, c.z), new Vector3(thickness, height, depth));
      SpawnWall(new Vector3(b.min.x - half, c.y, c.z), new Vector3(thickness, height, depth));
    }

    private void SpawnWall (Vector3 position, Vector3 scale) {
      GameObject wall = Instantiate(_wallPrefab, position, Quaternion.identity, transform);
      wall.transform.localScale = scale;
    }

    public Bounds Area {
      get {
        return new Bounds(transform.position, _config.Size);
      }
    }
  }
}