using System;
using System.Linq;

namespace NiceSim
{
    class Program
    {
        static List<Buddy> buddies = new List<Buddy>();
        static int rounds = 0;
        static int n, b;
        static int Nice = 0;
        static int Bad = 0;
        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            Init();
            rounds = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < rounds; ++i)
            {
                while (true)
                {
                    bool sorted = false;
                    for (int e = 0; e < buddies.Count-1; ++e)
                    {
                        if (buddies[e+1].Reputation > buddies[e].Reputation)
                        {
                            Buddy temp = buddies[e];
                            buddies[e] = buddies[e+1];
                            buddies[e+1] = temp;
                            sorted = true;
                        }
                    }
                    if (sorted == false) break;
                }
                foreach (Buddy buddy in buddies)
                {
                    buddy.SetAction();
                }
                for (int e = 0; e < buddies.Count-1; e += 2)
                {
                    if (buddies[e].NextAction == BuddyActions.Hostile && buddies[e+1].NextAction == BuddyActions.Hostile)
                    {
                        Console.WriteLine("NO WIN");
                        buddies[e].Reputation--;
                        buddies[e+1].Reputation--;
                    }
                    else if (buddies[e].NextAction == BuddyActions.Nice && buddies[e+1].NextAction == BuddyActions.Nice)
                    {
                        buddies[e].Health++;
                        buddies[e+1].Health++;
                        buddies[e].Reputation++;
                        buddies[e+1].Reputation++;
                        Console.WriteLine("WIN");
                    }
                    else 
                    {
                        Console.WriteLine("EVIL");
                        if (buddies[e].NextAction == BuddyActions.Hostile)
                        {
                            buddies[e].Health += 2;
                            buddies[e].Reputation--;
                            buddies[e+1].Reputation++;
                        }
                        else
                        {
                            buddies[e+1].Health += 2;
                            buddies[e+1].Reputation--;
                            buddies[e].Reputation++;
                        }
                    }
                }
                for (int e = 0; e < buddies.Count; ++e)
                {
                    buddies[e].Health--;
                    Console.WriteLine(buddies[e].Health);
                    if (buddies[e].Health == 0)
                    {
                        buddies.RemoveAt(e);
                        e--;
                    }
                }
                Nice = 0;
                Bad = 0;
                foreach(Buddy buddy in buddies)
                {
                    if (buddy.Type == "Nice") Nice++;
                    if (buddy.Type == "Bad") Bad++;
                }
                Console.WriteLine("Day " + i);
                Console.WriteLine("Nice: " + Nice);
                Console.WriteLine("Bad: " + Bad);
                Console.WriteLine();
            }
        }
        static void Init()
        {
            for (int i = 0; i < n; ++i)
            {
                buddies.Add(new NiceBuddy());
            }
            for (int i = 0; i < b; ++i)
            {
                buddies.Add(new BadBuddy());
            }
            Buddy[] temp = buddies.ToArray();
            Random.Shared.Shuffle(temp);
            buddies = temp.ToList();
        }
    }
}
