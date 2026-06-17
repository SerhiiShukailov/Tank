using Tank.App.Project.Script.App.Services.SaveLoad;
using Tank.Contracts.Project.Script.Contracts.Score;

namespace Tank.Feature.Project.Script.Feature {
  public class BattlePersistence : ISavable {
    private readonly IScore _score;
    private readonly ISaveLoadService _saveLoad;

    public BattlePersistence (IScore score, ISaveLoadService saveLoad) {
      _score = score;
      _saveLoad = saveLoad;
    }

    public void Save() {
      _saveLoad.Save(SaveConstant.SAVE_KEY_BATTLE, new BattleSnapshot {
        Score = _score.Value
      });
    }

    public void Load() {
      BattleSnapshot snapshot = _saveLoad.Load<BattleSnapshot>(SaveConstant.SAVE_KEY_BATTLE);

      if(snapshot != null) {
        _score.Set(snapshot.Score);
      }
    }
  }
}