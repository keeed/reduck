using System;
using System.Collections.Generic;

namespace Reduck
{
    public class DefaultStore : Store
    {
        public DefaultStore(List<IReducer> reducers, State state) : base(reducers, state)
        {
        }

        public override State OnDispatch(Action action)
        {
            foreach (var reducer in Reducers)
            {
                _nextState = reducer.Apply(_nextState, action);       
            }
            
            return _nextState;
        }
    }
}