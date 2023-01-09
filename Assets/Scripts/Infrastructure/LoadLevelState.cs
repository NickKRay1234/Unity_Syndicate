using Scripts.Infrastructure;

namespace Infrastructure
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName);
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }
    }
}