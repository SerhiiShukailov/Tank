using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Tank.App.Project.Script.App.Services.SaveLoad {
  public class SaveLoadRunner : MonoBehaviour {
    private IReadOnlyList<ISavable> _savables;
    private bool _saved;

    private void Start() {
      if(_savables == null) {
        return;
      }

      for(int i = 0; i < _savables.Count; i++) {
        _savables[i].Load();
      }
    }

    private void OnDestroy() {
      SaveAll();
    }

    [Inject]
    public void Construct (IReadOnlyList<ISavable> savables) {
      _savables = savables;
    }

    private void OnApplicationQuit() {
      SaveAll();
    }

    private void SaveAll() {
      if(_saved || _savables == null) {
        return;
      }

      _saved = true;

      for(int i = 0; i < _savables.Count; i++) {
        _savables[i].Save();
      }
    }
  }
}