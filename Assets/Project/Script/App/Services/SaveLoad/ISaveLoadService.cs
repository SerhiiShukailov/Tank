namespace Tank.App.Project.Script.App.Services.SaveLoad {
  public interface ISaveLoadService {
    void Save<TData> (string key, TData data);

    TData Load<TData> (string key);

    bool Has (string key);
  }
}