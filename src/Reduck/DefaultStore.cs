using System;

namespace Reduck
{
    public class DefaultStore : Store
    {
        public override void OnDispatch(State newState, string action)
        {
            foreach (var reducer in Reducers)
            {
                newState = reducer.Reduce(newState, action);       
            }
        }
    }
}