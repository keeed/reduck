using System;

namespace Reduck
{
    public interface IReducer
    {
        State Apply(State previousState, Action action);
    }
}