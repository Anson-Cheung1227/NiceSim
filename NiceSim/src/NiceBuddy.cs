
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
            Console.WriteLine(Health);
            if (Health <= 4) NextAction = BuddyActions.Hostile;
        }
        public override void Socialize()
        {
            if (NextAction == BuddyActions.Hostile)
            {
                Reputation--;
                if (NextBuddy.NextAction == BuddyActions.Nice)
                {
                    Health += 2;
                    Console.WriteLine("WIN");
                }
                else
                {
                    Console.WriteLine("NO WIN");
                }
            }
            else
            {
                Reputation++;
                if (NextBuddy.NextAction == BuddyActions.Nice)
                {
                    Health++;
                    Console.WriteLine("NICE");
                }
                else
                {
                    Console.WriteLine("EVIL");
                }
            }
        }
        public override void FindBuddy(List<Buddy> sortedRepList, List<Buddy> doneList)
        {
            Buddy target = sortedRepList[1];
            SetBuddy(target);
            target.SetBuddy(this);
            sortedRepList.Remove(this);
            sortedRepList.Remove(target);
            doneList.Add(this);
            doneList.Add(target);
        }
    }
}