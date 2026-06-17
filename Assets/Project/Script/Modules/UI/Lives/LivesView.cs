using TMPro;
using UnityEngine;
using VContainer;

namespace Tank.Modules.UI.Project.Script.Modules.UI.Lives {
  public class LivesView : MonoBehaviour {
    [SerializeField]
    private TMP_Text _label;

    private LivesViewModel _viewModel;

    private void OnDestroy() {
      if(_viewModel != null) {
        _viewModel.TextChanged -= OnTextChanged;
      }
    }

    [Inject]
    public void Construct (LivesViewModel viewModel) {
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
