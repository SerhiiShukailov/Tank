namespace Tank.App.Project.Script.App.Services.Logging {
  public interface ILogService {
    void Log (string message);

    void Warning (string message);

    void Error (string message);
  }
}