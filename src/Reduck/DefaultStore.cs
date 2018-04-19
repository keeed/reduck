using System;
using System.Collections.Generic;

namespace Reduck
{
    public class DefaultStore : Store
    {
        public DefaultStore(List<IReducer> reducers, State state) : base(reducers, state)
        {
        }

        public override void OnDispatch(State newState, string action)
        {
            foreach (var reducer in Reducers)
            {
                newState = reducer.Reduce(newState, action);       
            }
        }
    }
}