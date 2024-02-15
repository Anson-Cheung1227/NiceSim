namespace NiceSim
{
    public abstract class Buddy
    {
        public string Type;
        public int Reputation = 0;
        public int Health = 5;
        public BuddyActions NextAction;
        public abstract void SetAction();
    }
}
