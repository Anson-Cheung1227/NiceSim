namespace NiceSim
{
    public class BadBuddy : Buddy
    {
        public BadBuddy() : base()
        {
            Type = "Bad";
        }
        public override void SetAction()
        {
            NextAction = BuddyActions.Hostile;
        }
    }
}