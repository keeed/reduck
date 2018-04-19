using System;
using System.Collections.Generic;

namespace Reduck
{
    public class StoreBuilder 
    {
        protected List<IReducer> Reducers = new List<IReducer>();
        protected State InitialState = new State();

        public virtual StoreBuilder SetInitialState(State state)
        {
            InitialState = state;
            return this;
        }

        public virtual StoreBuilder AddReducer(IReducer reducer)
        {
            Reducers.Add(reducer);
            return this;
        }

        public virtual Store Build()
        {
            return new DefaultStore(Reducers, InitialState);
        }
    }
}