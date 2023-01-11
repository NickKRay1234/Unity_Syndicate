using Infrastructure.Services;
using Infrastructure.States;
using Logic;
using Scripts.Infrastructure;
using Scripts.Services.Inputs;
using Services.Inputs;

namespace Infrastructure
{
  public class Game
  {
    public static IInputService InputService;
    public readonly GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
    }
  }
}