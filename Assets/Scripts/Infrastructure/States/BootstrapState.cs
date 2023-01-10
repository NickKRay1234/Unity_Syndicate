using Infrastructure.AssetManagment;
using Infrastructure.Factory;
using Infrastructure.Services;
using Scripts.Infrastructure;
using Scripts.Services.Inputs;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }
        
        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("Main");

        public void Update()
        {
        }

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();

            AllServices.Container.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.Single<IAssets>()));
        }

        public void Exit()
        {
        }
        
        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}