using Infrastructure;
using UnityEngine;

namespace Scripts.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(this);
      _game.StateMachine.Enter<BootstrapState>();
      DontDestroyOnLoad(this);
    }
    
    private void Update()
    {
      //_game.StateMachine.CurrentState.Update();
    }
  }
}