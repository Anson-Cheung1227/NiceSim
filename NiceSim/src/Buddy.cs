namespace NiceSim
{
    public abstract class Buddy
    {
        public string Type;
        public int Reputation = 0;
        public int Health {get; protected set;} = 5;
        public BuddyActions NextAction;
        protected Buddy NextBuddy;
        public abstract void SetAction();
        public void SetBuddy(Buddy buddy)
        {
            NextBuddy = buddy;
        }
        public abstract void FindBuddy(List<Buddy> sortedRepList, List<Buddy> doneList);
        public abstract void Socialize();
        public void DayPassed()
        {
            Health--;
        }
    }
}
