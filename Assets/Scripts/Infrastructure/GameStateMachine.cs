using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;
        public IState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader)
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            IState state = _states[typeof(TState)];
            _currentState = state;
            state.Enter();
        }
    }
}