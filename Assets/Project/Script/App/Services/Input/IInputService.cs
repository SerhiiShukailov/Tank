using System;
using UnityEngine;

namespace Tank.App.Project.Script.App.Services.Input {
  public interface IInputService {
    event Action FirePressed;
    Vector2 Move { get; }
  }
}