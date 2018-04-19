using System;
using System.Collections.Generic;

namespace Reduck
{
    public abstract class Store
    {
        private static Store StoreInstance;

        protected List<IReducer> Reducers = new List<IReducer>();
        protected State State { get; }

        public static Store Instance 
        {
            get
            {
                if (StoreInstance == null) 
                {
                    return new DefaultStore();
                }
                return StoreInstance;
            }
        }

        public static void Dispatch(State newState, string action)
        {
            StoreInstance.OnDispatch(newState, action);
        }

        public abstract void OnDispatch(State newState, string action);
    }
}