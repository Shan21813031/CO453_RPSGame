using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPSProject;

namespace SPSProject
{
    /// <summary>
    /// This class has methods for playing the classic Rock Paper Scissors game.
    /// Author: Shan Ahmed
    /// </summary>

    public class RPSGame
    {

        private string computerChoice;
        private string playerChoice;
        private string name;
        public int ComputerScore = 0, PlayerScore = 0;
        private Random randomGenerator;

        public RPSGame()
        {
            randomGenerator = new Random();       // create new Random object
        }

        /// <summary>
        /// Randy is used as a constructor for a default random value to refer back to
        /// </summary>
        /// 
        public void Play()
        {
            setupScreen();
            introduction();

            do
            {
                getPlayerChoice();
                getComputerChoice();

                drawPlayerChoice();
                printChoices();

                showResult();
                showScore();

                System.Threading.Thread.Sleep(5000);

            } while (PlayerScore < 20 && ComputerScore < 20);

            finish();

            Console.ReadKey();   
        }

        /// <summary>
        /// The setup screen develops the colour and then the introduction is called to explain what the game. 
        /// Ive used a do while loop to accomodate the 3rd outcome of this possible game which is a draw.
        /// The loop runs and the check is completed at the end of the loop which allows for the possibility
        /// of a draw. In the loop, the player choice is retrieved, then the computer choice, the choices are printed
        /// the result of a win or a loss is displayed and then the overall score.
        /// After the loop is finished, the finish method is called which says the game has ended and displays 
        /// a suitable message.
        /// </summary>
        private void showScore()
        {
            Console.WriteLine("Player Score: " + PlayerScore);
            Console.WriteLine("Computer Score: " + ComputerScore);
        }

        /// <summary>
        /// Player score and Computer Score and labelled
        /// </summary>

        private void finish()
        {
            Console.Clear();
            Console.WriteLine("Program Over !!!");
            Console.WriteLine("=============");
            Console.WriteLine("Player Score: " + PlayerScore);
            Console.WriteLine("Computer Score: " + ComputerScore);

            if (PlayerScore > ComputerScore)
            {
                DrawImages.drawThumbsUp();
            }
            if (PlayerScore < ComputerScore)
            {
                DrawImages.drawThumbsDown();
            }
            if (PlayerScore == ComputerScore)
            {
                DrawImages.drawSmile();
            }
        }

        /// <summary>
        /// The Console is cleared and it is displayed that the game is over. 3 if statements are used
        /// for the 3 different outcomes of either a loss, win or a draw with a corresponding "draw#####" method being
        /// called.
        /// </summary>
        private void setupScreen()
        {
            Console.Title = " The Great Scissors-Paper-Stone Program";
            Console.SetWindowSize(100, 36);
            Console.SetBufferSize(100, 36);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();  // clear screen in chosen colour
        }


        /// <summary>
        /// The Console that is displayed upon running the program is given the title "the Great
        /// Scissors Paper Stone Program" with the size of the window also being made. I've also chosen
        /// to use a Magenta Background with a Black foreground for a more appealing look
        /// </summary>
        /// 
        private void introduction()
        {
            Console.WriteLine("\tPlay the Scissors Paper Stone Program");
            Console.WriteLine("\t==================================");
            Console.WriteLine("Enter player name: ");
            name = Console.ReadLine();
        }

        /// <summary>
        /// Player is asked to enter their name, the name is the stored into a string made within the Class
        /// </summary>
        private void getPlayerChoice()
        {
            Console.WriteLine("\n\tWhat is your choice, " + name + " ?");
            Console.Write("\tScissors Paper or Stone : ");
            playerChoice = Console.ReadLine();
            playerChoice = playerChoice.ToUpper();
        }

        /// <summary>
        /// This gets the player choice and saves it within the playerChoice string. Whether or not the user
        /// types in lowercase or uppercase, the players choice is made uppercase using .ToUpper
        /// </summary>
        /// 
        private void getComputerChoice()
        {
            int num;
            num = randomGenerator.Next(3);  // pick a random number (0, 1 or 2)
            if (num == 0)
            {
                computerChoice = "SCISSORS";
                DrawImages.drawScissors(10, 20);
            }
            if (num == 1)
            {
                computerChoice = "PAPER";
                DrawImages.drawPaper(10, 20);
            }
            if (num == 2)
            {
                computerChoice = "STONE";
                DrawImages.drawStone(10, 20);
            }
        }

        /// <summary>
        /// If statements are used to collect the choices made by the computer. A random number between 
        /// 0 and 2 is generated by the program and then stored into num. Depending on which is picked up
        /// by the If statements, the corresponding result calls the method to make a graphical image of
        /// the choice made by the computer and a choice is stored within the string computerChoice.
        /// </summary>
        /// 
        private void printChoices()
        {
            Console.WriteLine("\n\t" + name + " picked " + playerChoice);
            Console.WriteLine("\tThe computer choice is " + computerChoice);
        }

        /// <summary>
        /// The name of the user is displayed alongside with their choice and the computer choice which is 
        /// called using the computerChoice string.
        /// </summary>
        /// 
        private void showResult()
        {
            if (playerChoice == computerChoice)
            {
                Console.WriteLine("\n\tA DRAW!!");
                PlayerScore++;
                ComputerScore++;

            }
            if (playerChoice == "STONE" && computerChoice == "SCISSORS")
            {
                Console.WriteLine("\n\t" + name + " WON! Because Stone Breaks Scissors");
                PlayerScore = PlayerScore + 2;
            }
            if (playerChoice == "SCISSORS" && computerChoice == "PAPER")
            {
                Console.WriteLine("\n\t" + name + " WON! Scissors Cut Paper");
                PlayerScore = PlayerScore + 2;
            }
            if (playerChoice == "PAPER" && computerChoice == "STONE")
            {
                Console.WriteLine("\n\t" + name + " WON! Because Paper Covers Stone");
                PlayerScore = PlayerScore + 2;
            }
            if (playerChoice == "PAPER" && computerChoice == "SCISSORS")
            {
                Console.WriteLine("\n\tTHE COMPUTER WINS");
                ComputerScore = ComputerScore + 2;
            }
            if (playerChoice == "STONE" && computerChoice == "PAPER")
            {
                Console.WriteLine("\n\tTHE COMPUTER WINS");
                ComputerScore = ComputerScore + 2;
            }
            if (playerChoice == "SCISSORS" && computerChoice == "STONE")
            {
                Console.WriteLine("\n\tTHE COMPUTER WINS");
                ComputerScore = ComputerScore + 2;
            }

        }

        /// <summary>
        /// This above method checks the string values playerChoice and computerChoice and subsequently
        /// displays a message saying whether or not the player has won whilst also increasing the 
        /// value of either ComputerScore or PlayerScore. If it is a win, the score is incremented by 2
        /// if it is a draw, both scores are incremented by 1.
        /// </summary>
        private void drawPlayerChoice()
        {
            if (playerChoice == "SCISSORS")
            {
                DrawImages.drawScissors(10, 5);
            }
            else if (playerChoice == "PAPER")
            {
                DrawImages.drawPaper(10, 5);
            }
            else if (playerChoice == "STONE")
            {
                DrawImages.drawStone(10, 5);
            }
        }

        
        //**************************************************************
        
    }
}
