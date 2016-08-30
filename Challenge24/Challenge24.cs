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
        static List<FootballMatch> ResultsList = new List<FootballMatch>()
        {
            new FootballMatch("West Brom", 0, "Middlesbrough", 0),
            new FootballMatch("Man City", 3, "West Ham", 1),
            new FootballMatch("Tottenham", 1, "Liverpool", 1),
            new FootballMatch("Chelsea", 3, "Burnley", 0),
            new FootballMatch("Crystal Palace", 1, "Bournemouth", 1),
            new FootballMatch("Everton", 1, "Stoke", 1),
            new FootballMatch("Leicester", 2, "Swansea", 1),
            new FootballMatch("Southampton", 1, "Sunderland", 1),
            new FootballMatch("Watford", 1, "Arsenal", 3),
            new FootballMatch("Hull", 0, "Man Utd", 1),
            new FootballMatch("Sunderland", 1, "Middlesbrough", 2),
            new FootballMatch("West Ham", 1, "Bournemouth", 0),
            new FootballMatch("Stoke", 1, "Man City", 4),
            new FootballMatch("Burnley", 2, "Liverpool", 0),
            new FootballMatch("Swansea", 0, "Hull", 2),
            new FootballMatch("Tottenham", 1, "Crystal Palace", 0),
            new FootballMatch("Watford", 1, "Chelsea", 2),
            new FootballMatch("West Brom", 1, "Everton", 2),
            new FootballMatch("Leicester", 0, "Arsenal", 0),
            new FootballMatch("Man Utd", 2, "Southampton", 0),
            new FootballMatch("Chelsea", 2, "West Ham", 1)
        };

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.WriteLine("Press [A] to add a result, [S] to search for results by team.");

            switch (char.ToLower(Console.ReadKey().KeyChar)) {
                case 'a':
                    AddResult();
                    break;
                case 's':
                    Console.Write("\nEnter team name to search for: ");
                    string name = Console.ReadLine();
                    Console.WriteLine(PrintResult(name));
                    break;
                default:
                    Run();
                    break;
            }
            Run();
        }

        static void AddResult()
        {
            Console.Write("\nHome team: ");
            string hometeam = Console.ReadLine();
            Console.Write("\nAway team: ");
            string awayteam = Console.ReadLine();
            int hometeamscore = UserInteraction("Home team scored: ");
            int awayteamscore = UserInteraction("Away team scored: ");
            ResultsList.Add(new FootballMatch(hometeam, hometeamscore, awayteam, awayteamscore));
            Console.WriteLine(PrintResult(ResultsList.Count - 1));
        }

        static string PrintResult(int i)
        {
            return string.Format("Results: {0} {1} - {2} {3}", ResultsList[i].HomeTeam, ResultsList[i].HtScore,
                ResultsList[i].AtScore, ResultsList[i].AwayTeam);
        }

        static string PrintResult(string team)
        {
            var returnstring = new StringBuilder();
            foreach (var result in ResultsList.Where(result =>
            string.Equals(result.HomeTeam, team, StringComparison.CurrentCultureIgnoreCase) ||
            string.Equals(result.AwayTeam, team, StringComparison.CurrentCultureIgnoreCase))) {
                returnstring.AppendLine(string.Format("Result: {0} {1} - {2} {3}", result.HomeTeam, result.HtScore,
                    result.AtScore, result.AwayTeam));
            }
            return returnstring.ToString();
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
        public FootballMatch(string hometeam, int htScore, string awayteam, int atScore)
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
        public readonly string HomeTeam;

        /// <summary>
        /// Gets the away team.
        /// </summary>
        /// <value>The away team.</value>
        public readonly string AwayTeam;

        /// <summary>
        /// Gets the home team score.
        /// </summary>
        /// <value>The home team score.</value>
        public readonly int HtScore;

        /// <summary>
        /// Gets the away team score.
        /// </summary>
        /// <value>The away team score.</value>
        public readonly int AtScore;
    }
}
