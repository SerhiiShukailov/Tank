using System;
using Tank.App.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.App.Project.Script.App.Services.Input {
  public class InputService : IInputService, IDisposable {
    private readonly TankControls _controls;

    public event Action FirePressed;

    public InputService() {
      _controls = new TankControls();
      _controls.Player.Fire.performed += OnFirePerformed;
      _controls.Player.Enable();
    }

    public void Dispose() {
      _controls.Player.Fire.performed -= OnFirePerformed;
      _controls.Player.Disable();
      _controls.Dispose();
    }

    private void OnFirePerformed (InputAction.CallbackContext context) {
      FirePressed?.Invoke();
    }

    public Vector2 Move {
      get {
        return _controls.Player.Move.ReadValue<Vector2>();
      }
    }
  }
}