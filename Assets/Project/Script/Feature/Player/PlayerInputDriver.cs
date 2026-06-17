using Tank.App.Project.Script.App.Services.Input;
using Tank.Contracts.Project.Script.Contracts.Entities;
using UnityEngine;
using VContainer;

namespace Tank.Feature.Project.Script.Feature.Player {
  public class PlayerInputDriver : MonoBehaviour {
    private IInputService _input;
    private ICommandPort _command;

    private void Start() {
      _input.FirePressed += InputOnFirePressed;
    }

    private void Update() {
      if(_input == null || _command == null) {
        return;
      }

      _command.Move(_input.Move);
    }

    private void OnDestroy() {
      _input.FirePressed -= InputOnFirePressed;
    }

    [Inject]
    public void Construct (IInputService input, ICommandPort command) {
      _input = input;
      _command = command;
    }

    private void InputOnFirePressed() {
      _command.Fire();
    }
  }
}