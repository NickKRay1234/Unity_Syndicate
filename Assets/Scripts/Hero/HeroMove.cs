using Infrastructure;
using Infrastructure.Services;
using Scripts;
using Scripts.Services.Inputs;
using Services.Inputs;
using UnityEngine;

namespace Hero
{
  public class HeroMove : MonoBehaviour
  {
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;
    private IInputService _input;

    private void Awake()
    {
      _input = AllServices.Container.Single<IInputService>();
      _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
      Vector3 movementVector = Vector3.zero;

      if (_input.Axis.sqrMagnitude > Constants.Epsilon)
      {
        movementVector = Camera.main.transform.TransformDirection(_input.Axis);
        movementVector.y = 0;
        movementVector.Normalize();

        transform.forward = movementVector;
      }

      movementVector += Physics.gravity;

      _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
    }
  }
}