using System.IO;
using UnityEngine;

namespace Tank.App.Project.Script.App.Services.SaveLoad {
  public class SaveLoadService : ISaveLoadService {

    private static string PathFor (string key) {
      return Path.Combine(Application.persistentDataPath, key + SaveConstant.SAVE_KEY_JSON);
    }

    public void Save<TData> (string key, TData data) {
      File.WriteAllText(PathFor(key), JsonUtility.ToJson(data, true));
    }

    public TData Load<TData> (string key) {
      string path = PathFor(key);
      return File.Exists(path) ? JsonUtility.FromJson<TData>(File.ReadAllText(path)) : default;
    }

    public bool Has (string key) {
      return File.Exists(PathFor(key));
    }
  }
}