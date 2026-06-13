using UnityEngine;

namespace Tank.Modules.AI.Project.Script.Modules.AI.Configs {
  [CreateAssetMenu(menuName = "Tank/AI/AIConfig", fileName = "AIConfig")]
  public class AIConfig : ScriptableObject {
    [SerializeField]
    private float _viewRadius;
    [SerializeField]
    private float _patrolSpeed;
    [SerializeField]
    private float _directionChangeInterval;
    [SerializeField]
    private float _reverseDuration;

    public float ViewRadius {
      get {
        return _viewRadius;
      }
    }
    public float PatrolSpeed {
      get {
        return _patrolSpeed;
      }
    }
    public float DirectionChangeInterval {
      get {
        return _directionChangeInterval;
      }
    }
    public float ReverseDuration {
      get {
        return _reverseDuration;
      }
    }
  }
}