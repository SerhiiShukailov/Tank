using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tank.App.Project.Script.App.Services.Config {
  public class ConfigService : IConfigService {
    private const string CONFIGS_FOLDER = "Configs";

    private readonly Dictionary<Type, Object> _cache = new Dictionary<Type, Object>();

    public TConfig Get<TConfig>() where TConfig : class {
      Type type = typeof(TConfig);

      if(_cache.TryGetValue(type, out Object cached)) {
        return cached as TConfig;
      }

      Object [] found = Resources.LoadAll(CONFIGS_FOLDER, type);
      Object asset = found.Length > 0 ? found[0] : null;
      _cache[type] = asset;
      return asset as TConfig;
    }
  }
}