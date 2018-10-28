using System;
using System.Collections.Generic;

namespace Reduck
{
    public abstract class Store
    {
        protected Queue<State> _stateHistory = new Queue<State>();
        protected State _previousState;
        protected State _nextState;

        public Store(
            List<IReducer> reducers, 
            State initialState,
            int stateHistoryLimit = 20)
        {
            Reducers = reducers ?? throw new ArgumentNullException(nameof(reducers));

            if (initialState == null)
            {
                throw new ArgumentNullException(nameof(initialState));
            }
            _stateHistory.Enqueue(initialState);
            _previousState = initialState;

            StateHistoryLimit = stateHistoryLimit;
        }

        public List<IReducer> Reducers { get; }
        public int StateHistoryLimit { get; }

        public void Dispatch(Action action)
        {
            _nextState = _previousState;
            State newState = OnDispatch(action);

            if (_nextState != _previousState)
            {
                addStateToHistory(newState);
            }
            _nextState = null;
        }

        public abstract State OnDispatch(Action action);

        protected void addStateToHistory(State state) 
        {
            if (_stateHistory.Count >= StateHistoryLimit) 
            {
                _stateHistory.Dequeue();
            } 
            _stateHistory.Enqueue(state);
            _previousState = state;
        }
    }
}