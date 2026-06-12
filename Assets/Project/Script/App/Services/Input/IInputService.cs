using UnityEngine;

namespace Tank.App.Project.Script.App.Services.Input {
  public interface IInputService {
    Vector2 Move { get; }
    bool FirePressed { get; }
  }
}