using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        public IExitableState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader)
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            IState state = GetState<TState>();
            _currentState = state;
            state.Enter();
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            return _states[typeof(TState)] as TState;

        public void Enter<TState, TPayload>(TPayload payload) where TState : IState
        {
            _currentState?.Exit();
            IState state = _states[typeof(TState)];
            _currentState = state;
            state.Enter(payload);
        }

    }
}