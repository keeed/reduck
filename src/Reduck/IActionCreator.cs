namespace Reduck
{
    public interface IActionCreator<A, AP>
        where A : Action
        where AP : ActionParameters
    {
        A CreateAction(AP actionParameters);
    }
}