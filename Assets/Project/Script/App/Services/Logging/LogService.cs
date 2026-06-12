using UnityEngine;

namespace Tank.App.Project.Script.App.Services.Logging {
  public class LogService : ILogService {
    public void Log (string message) {
      Debug.Log(message);
    }

    public void Warning (string message) {
      Debug.LogWarning(message);
    }

    public void Error (string message) {
      Debug.LogError(message);
    }
  }
}