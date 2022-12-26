using System;
using System.Globalization;

namespace Election.APP
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the amount of the votes:");
            List<Election> votes = new List<Election>();
            Election vote;
            int amoutVote = 1;
            amoutVote = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < amoutVote + 1; i++)
            {
                Console.WriteLine($" Inform the name of the candidate to vote nº{i}:");
                string candidateName = Console.ReadLine().ToUpper();
                vote = new Election { CandidateName = candidateName };
                if (!votes.Exists(v => v.CandidateName == vote.CandidateName))
                    votes.Add(vote);
                else
                    votes.FirstOrDefault(v => v.CandidateName.ToUpper() == vote.CandidateName.ToUpper()).AmountVote++;
            }
            Console.WriteLine($"The highest number of votes is: {ElectionWinner(votes)}");
        }

        public static string ElectionWinner(List<Election> votes)
        {
            return votes.Where(v => v.AmountVote == votes.Max(c => c.AmountVote))
                        .OrderBy(v => v.CandidateName)
                        .FirstOrDefault().CandidateName
                        .ToString();
        }
    }
}
