using TMPro;
using UnityEngine;
using VContainer;

namespace Tank.Modules.UI.Project.Script.Modules.UI.Score {
  public class ScoreView : MonoBehaviour {
    [SerializeField]
    private TMP_Text _label;

    private ScoreViewModel _viewModel;

    private void OnDestroy() {
      if(_viewModel != null) {
        _viewModel.TextChanged -= OnTextChanged;
      }
    }

    [Inject]
    public void Construct (ScoreViewModel viewModel) {
      _viewModel = viewModel;
      _viewModel.TextChanged += OnTextChanged;
      OnTextChanged(_viewModel.Text);
    }

    private void OnTextChanged (string text) {
      if(_label != null) {
        _label.text = text;
      }
    }
  }
}