namespace Tank.App.Project.Script.App.Services.Config {
  public interface IConfigService {
    TConfig Get<TConfig>() where TConfig : class;
  }
}