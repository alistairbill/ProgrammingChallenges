/* Challenge 10
 *
 * Make a game of rock, paper, scissors against the computer.
 *
 * Extension
 *  - Make sure the user enters a valid entry
 *  - Add a loop structure to play several times and keep a running score
 *  - Make an enumerated variable type to store choices
 */

using System;

namespace Challenge10
{
    class Challenge10
    {
        enum Choice
        {
            Rock,
            Paper,
            Scissors
        }

        static Choice UserChoice, ComputerChoice;
        static int Score;
        static Random RandInt = new Random();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) {
                Game();
            }
            Console.WriteLine("\nYour final score was " + Score);
        }

        static void Game()
        {
            UserSelect();
            ComputerSelect();
            Console.WriteLine("You chose {0} ~ Computer chooses {1}", UserChoice, ComputerChoice);
            if (UserChoice == ComputerChoice) {
                Draw();
            } else if ((UserChoice == Choice.Rock && ComputerChoice == Choice.Scissors)
                  || (UserChoice == Choice.Paper) && (ComputerChoice == Choice.Rock)
                  || (UserChoice == Choice.Scissors && ComputerChoice == Choice.Paper)) {
                Win();
            } else {
                Lose();
            }
        }

        static void UserSelect()
        {
            Console.Write("\n\nRock, paper or scissors? ");
            var readLine = Console.ReadLine();
            if (readLine != null) {
                switch (readLine.ToLower()) {
                    case "rock":
                        UserChoice = Choice.Rock;
                        break;
                    case "paper":
                        UserChoice = Choice.Paper;
                        break;
                    case "scissors":
                        UserChoice = Choice.Scissors;
                        break;
                    default:
                        UserSelect();
                        break;
                }
            } else {
                UserSelect();
            }
        }

        static void ComputerSelect()
        {
            int random = RandInt.Next(1, 4);
            switch (random) {
                case 1:
                    ComputerChoice = Choice.Rock;
                    break;
                case 2:
                    ComputerChoice = Choice.Paper;
                    break;
                case 3:
                    ComputerChoice = Choice.Scissors;
                    break;
            }
        }

        static void Win()
        {
            Score++;
            Console.Write("You won! Score: " + Score);
        }

        static void Draw()
        {
            Console.Write("You drew! Score: " + Score);
        }

        static void Lose()
        {
            Score--;
            Console.Write("You lost. Score: " + Score);
        }
    }
}
