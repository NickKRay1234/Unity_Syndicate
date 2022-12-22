using UnityEngine;

namespace Scripts.Services.Inputs
{
  public class MobileInputService : InputService
  {
    public override Vector2 Axis => SimpleInputAxis();
  }
}