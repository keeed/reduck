namespace Reduck
{
    public abstract class Action
    {
        public Action(ActionType actionType) 
        {
            ActionType = actionType;
        }

        public ActionType ActionType { get; }
    }
}