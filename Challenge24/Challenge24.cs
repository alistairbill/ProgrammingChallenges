/* Challenge 24
 *
 * Create a program with the following record structure:
 * Structure Results
 * 		HomeTeam as string
 * 		HomeTeamScore as integer
 * 		AwayTeam as string
 * 		AwayTeamScore as integer
 * End Structure
 *
 * Make an array of 20 Results
 *
 * Create a program with a menu whose options are
 * 		1. Add a result
 * 		2. Search for all results for a team
 *
 * Write the code to carry out these two things.
 *
 * If option 1 is selected:
 * 		- collect the result and add it to the end
 * 		  of the results array
 *
 * If option 2 is selected:
 * 		- Collect team name
 * 		- Display all the results that includes
 * 		  that team in either the home or away team
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge24
{
    class Challenge24
    {
        public static List<FootballMatch> ResultsList = new List<FootballMatch>();

        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("Press [A] to add a result, [S] to search for results by team.");

            switch (char.ToLower(Console.ReadKey().KeyChar)) {
                case 'a':
                    AddResult();
                    break;
                case 's':
                    Console.Write("Enter team name to search for: ");
                    String name = Console.ReadLine();
                    Console.WriteLine(PrintResult(name));
                    break;
                default:
                    Run();
                    break;
            }
            Run();
        }

        public static void AddResult()
        {
            Console.Write("\nHome team: ");
            String hometeam = Console.ReadLine();
            Console.Write("\nAway team: ");
            String awayteam = Console.ReadLine();
            int hometeamscore = UserInteraction("Home team scored: ");
            int awayteamscore = UserInteraction("Away team scored: ");
            ResultsList.Add(new FootballMatch(hometeam, hometeamscore, awayteam, awayteamscore));
            Console.WriteLine(PrintResult(ResultsList.Count - 1));
        }

        public static string PrintResult(int i)
        {
            return string.Format("Results: {0} {1} - {2} {3}", ResultsList[i].HomeTeam, ResultsList[i].HtScore,
                ResultsList[i].AtScore, ResultsList[i].AwayTeam);
        }

        public static string PrintResult(String team)
        {
            var returnString = new StringBuilder();
            foreach (var result in ResultsList.Where(result => 
            String.Equals(result.HomeTeam, team, StringComparison.CurrentCultureIgnoreCase) || 
            String.Equals(result.AwayTeam, team, StringComparison.CurrentCultureIgnoreCase)))
            {
                returnString.AppendLine(string.Format("Result: {0} {1} - {2} {3}", result.HomeTeam, result.HtScore,
                    result.AtScore, result.AwayTeam));
            }
            return returnString.ToString();
        }

        static int UserInteraction(string prompt)
        {
            int providedvalue;
            bool isnumber;
            do {
                Console.Write("\n" + prompt);
                isnumber = int.TryParse(Console.ReadLine(), out providedvalue);
                if (!isnumber) {
                    Console.WriteLine("That's not a number");
                }
            } while (!isnumber);
            return providedvalue;
        }
    }

    class FootballMatch
    {
        /// <summary>
        /// Initializes a new instance of the FootballMatch class.
        /// </summary>
        /// <param name="hometeam">Home team.</param>
        /// <param name="htScore">Home team score.</param>
        /// <param name="awayteam">Away team.</param>
        /// <param name="atScore">Away team score.</param>
        public FootballMatch(String hometeam, int htScore, String awayteam, int atScore)
        {
            HomeTeam = hometeam;
            AwayTeam = awayteam;
            HtScore = htScore;
            AtScore = atScore;
        }

        /// <summary>
        /// Gets the home team.
        /// </summary>
        /// <value>The home team.</value>
        public String HomeTeam { get; private set; }

        /// <summary>
        /// Gets the away team.
        /// </summary>
        /// <value>The away team.</value>
        public String AwayTeam { get; private set; }

        /// <summary>
        /// Gets the home team score.
        /// </summary>
        /// <value>The home team score.</value>
        public int HtScore { get; private set; }

        /// <summary>
        /// Gets the away team score.
        /// </summary>
        /// <value>The away team score.</value>
        public int AtScore { get; private set; }
    }
}
