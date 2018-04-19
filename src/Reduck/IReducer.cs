using System;

namespace Reduck
{
    public interface IReducer
    {
        State Reduce(State state, string action);
    }
}