namespace NiceSim
{
    public class NiceBuddy : Buddy
    {
        public NiceBuddy() : base()
        {
            Type = "Nice";
        }
        public override void SetAction()
        {
            NextAction = BuddyActions.Nice;
        }
    }
}