using System;
using System.Collections.Generic;

namespace Reduck
{
    public abstract class Store
    {
        private static Store StoreInstance;

        public Store(List<IReducer> reducers, State state)
        {
            Reducers = reducers ?? throw new ArgumentNullException(nameof(reducers));
            State = state ?? throw new ArgumentNullException(nameof(state));
        }

        public static Store Instance 
        {
            get
            {
                if (StoreInstance == null) 
                {
                    return new DefaultStore(
                        new List<IReducer>(),
                        new State()
                    );
                }
                return StoreInstance;
            }
        }

        public List<IReducer> Reducers { get; }
        public State State { get; }

        public static void Dispatch(State newState, string action)
        {
            StoreInstance.OnDispatch(newState, action);
        }

        public abstract void OnDispatch(State newState, string action);
    }
}