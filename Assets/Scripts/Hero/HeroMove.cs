using Data;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Services.Inputs;
using Infrastructure.Services.PersistentProgress.PersistentProgressService;
using Scripts;
using Scripts.Services.Inputs;
using Services.Inputs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero
{
  public class HeroMove : MonoBehaviour, ISavedProgress
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

    public void UpdateProgress(PlayerProgress progress)
    {
      progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
    }

    private static string CurrentLevel()
    {
      return SceneManager.GetActiveScene().name;
    }

    private void Warp(Vector3Data to)
    {
      _characterController.enabled = false;
      transform.position = to.AsUnityVector();
      _characterController.enabled = true;
    }
    
    

    public void LoadProgress(PlayerProgress progress)
    {
      if (CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
      {
        Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
        if (savedPosition != null)
          Warp(to: savedPosition);
      }
    }
  }
}