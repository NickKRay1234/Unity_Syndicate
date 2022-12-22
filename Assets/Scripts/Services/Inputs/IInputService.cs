using UnityEngine;

namespace Scripts.Services.Inputs
{
  public interface IInputService
  {
    Vector2 Axis { get; }

    bool IsAttackButtonUp();   
  }
}