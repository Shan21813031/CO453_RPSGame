using System;

namespace SPSProject
{
    class Game
    {
        string compChoice;
        string playerChoice;
        string name;
        int ComputerScore = 0, PlayerScore = 0;
        Random randy;

        static void Main()
        {
            Game myGame = new Game();  // create new Game object
            myGame.play();             // call its play method
        }

        /// <summary>
        /// a new object is created and then it is called from the Main()
        /// </summary>
        /// 


        public Game()
        {
            randy = new Random();       // create new Random object
        }

        /// <summary>
        /// Randy is used as a constructor for a default random value to refer back to
        /// </summary>
        /// 


        public void play()
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
            }
            while (PlayerScore < 20 && ComputerScore < 20);
            finish();

            Console.ReadKey();   // wait for a key press
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

        public void showScore()
        {
            Console.WriteLine("Player Score: " + PlayerScore);
            Console.WriteLine("Computer Score: " + ComputerScore);
        }

        /// <summary>
        /// Player score and Computer Score and labelled
        /// </summary>

        public void finish()
        {
            Console.Clear();
            Console.WriteLine("Game Over !!!");
            Console.WriteLine("=============");
            Console.WriteLine("Player Score: " + PlayerScore);
            Console.WriteLine("Computer Score: " + ComputerScore);

            if (PlayerScore > ComputerScore)
            {
                drawThumbsUp();
            }
            if (PlayerScore < ComputerScore)
            {
                drawThumbsDown();
            }
            if (PlayerScore == ComputerScore)
            {
                drawSmile();
            }
        }

        /// <summary>
        /// The Console is cleared and it is displayed that the game is over. 3 if statements are used
        /// for the 3 different outcomes of either a loss, win or a draw with a corresponding "draw#####" method being
        /// called.
        /// </summary>

        private void setupScreen()
        {
            Console.Title = " The Great Scissors-Paper-Stone Game";
            Console.SetWindowSize(100, 36);
            Console.SetBufferSize(100, 36);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();  // clear screen in chosen colour
        }


        /// <summary>
        /// The Console that is displayed upon running the program is given the title "the Great
        /// Scissors Paper Stone Game" with the size of the window also being made. I've also chosen
        /// to use a Magenta Background with a Black foreground for a more appealing look
        /// </summary>
        /// 

        public void introduction()
        {
            Console.WriteLine("\tPlay the Scissors Paper Stone Game");
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
            num = randy.Next(3);  // pick a random number (0, 1 or 2)
            if (num == 0)
            {
                compChoice = "SCISSORS";
                drawScissors(10, 20);
            }
            if (num == 1)
            {
                compChoice = "PAPER";
                drawPaper(10, 20);
            }
            if (num == 2)
            {
                compChoice = "STONE";
                drawStone(10, 20);
            }



        }



        /// <summary>
        /// If statements are used to collect the choices made by the computer. A random number between 
        /// 0 and 2 is generated by the program and then stored into num. Depending on which is picked up
        /// by the If statements, the corresponding result calls the method to make a graphical image of
        /// the choice made by the computer and a choice is stored within the string compChoice.
        /// </summary>
        /// 


        private void printChoices()
        {
            Console.WriteLine("\n\t" + name + " picked " + playerChoice);
            Console.WriteLine("\tThe computer choice is " + compChoice);
        }

        /// <summary>
        /// The name of the user is displayed alongside with their choice and the computer choice which is 
        /// called using the compChoice string.
        /// </summary>
        /// 


        private void showResult()
        {
            if (playerChoice == compChoice)
            {
                Console.WriteLine("\n\tA DRAW!!");
                PlayerScore++;
                ComputerScore++;

            }
            if (playerChoice == "STONE" && compChoice == "SCISSORS")
            {
                Console.WriteLine("\n\t" + name + " WON! Because Stone Breaks Scissors");
                PlayerScore = PlayerScore + 2;
            }
            if (playerChoice == "SCISSORS" && compChoice == "PAPER")
            {
                Console.WriteLine("\n\t" + name + " WON! Scissors Cut Paper");
                PlayerScore = PlayerScore + 2;
            }
            if (playerChoice == "PAPER" && compChoice == "STONE")
            {
                Console.WriteLine("\n\t" + name + " WON! Because Paper Covers Stone");
                PlayerScore = PlayerScore + 2;
            }
            if (playerChoice == "PAPER" && compChoice == "SCISSORS")
            {
                Console.WriteLine("\n\tTHE COMPUTER WINS");
                ComputerScore = ComputerScore + 2;
            }
            if (playerChoice == "STONE" && compChoice == "PAPER")
            {
                Console.WriteLine("\n\tTHE COMPUTER WINS");
                ComputerScore = ComputerScore + 2;
            }
            if (playerChoice == "SCISSORS" && compChoice == "STONE")
            {
                Console.WriteLine("\n\tTHE COMPUTER WINS");
                ComputerScore = ComputerScore + 2;
            }

        }

        /// <summary>
        /// This above method checks the string values playerChoice and compChoice and subsequently
        /// displays a message saying whether or not the player has won whilst also increasing the 
        /// value of either ComputerScore or PlayerScore. If it is a win, the score is incremented by 2
        /// if it is a draw, both scores are incremented by 1.
        /// </summary>

        private void drawPlayerChoice()
        {
            if (playerChoice == "SCISSORS")
            {
                drawScissors(10, 5);
            }
            else if (playerChoice == "PAPER")
            {
                drawPaper(10, 5);
            }
            else if (playerChoice == "STONE")
            {
                drawStone(10, 5);
            }
        }

        /// <summary>
        /// The above calls the draw methods for each choice depending on what the player has chosen. If
        /// statements are used to implement this by picking up the string values of playerChoice.
        /// </summary>


        private void drawScissors(int x, int y)
        {
            Console.SetCursorPosition(x, y++);   // set start position then increment y to move down
            Console.Write("     \\            /");
            Console.SetCursorPosition(x, y++);
            Console.Write("      \\          /");
            Console.SetCursorPosition(x, y++);
            Console.Write("       \\        /");
            Console.SetCursorPosition(x, y++);
            Console.Write("        \\      /");
            Console.SetCursorPosition(x, y++);
            Console.Write("         \\    /");
            Console.SetCursorPosition(x, y++);
            Console.Write("          \\  /");
            Console.SetCursorPosition(x, y++);
            Console.Write("           **");
            Console.SetCursorPosition(x, y++);
            Console.Write("          /  \\");
            Console.SetCursorPosition(x, y++);
            Console.Write("    (----/    \\----)");
            Console.SetCursorPosition(x, y++);
            Console.Write("     \\  /      \\  /");
            Console.SetCursorPosition(x, y++);
            Console.Write("      ==        ==");
            Console.WriteLine("\n\n");
        }
        //**************************************************************
        private void drawStone(int x, int y)
        {
            Console.SetCursorPosition(x, y++);   // set start position then increment y to move down
            Console.Write("                 ___---___     ");
            Console.SetCursorPosition(x, y++);
            Console.Write("              .--         --.    ");
            Console.SetCursorPosition(x, y++);
            Console.Write("           ./   ()       .-. \\.   ");
            Console.SetCursorPosition(x, y++);
            Console.Write("           /   o    .   (   )  \\  ");
            Console.SetCursorPosition(x, y++);
            Console.Write("          / .            '-'    \\  ");
            Console.SetCursorPosition(x, y++);
            Console.Write("         /     ()   ()           \\ ");
            Console.SetCursorPosition(x, y++);
            Console.Write("        |    o           ()       | ");
            Console.SetCursorPosition(x, y++);
            Console.Write("        |      .--.           O   | ");
            Console.SetCursorPosition(x, y++);
            Console.Write("         \\ .  |    |              |  ");
            Console.SetCursorPosition(x, y++);
            Console.Write("          \\   `.__.'     o   .   /    ");
            Console.SetCursorPosition(x, y++);
            Console.Write("           `\\  o    ()         /'    ");
            Console.SetCursorPosition(x, y++);
            Console.Write("              `--___    ___--'    ");
            Console.SetCursorPosition(x, y++);
            Console.Write("                     ---         ");
            Console.WriteLine();
        }
        //************************************************************************
        private void drawPaper(int x, int y)
        {
            Console.SetCursorPosition(x, y++);    // set start position then increment y to move down
            Console.Write("      .--.------------------.");
            Console.SetCursorPosition(x, y++);
            Console.Write("     /      \\  \\ \\ \\ \\ \\ \\ \\ \\");
            Console.SetCursorPosition(x, y++);
            Console.Write("    /   OOO  \\                |");
            Console.SetCursorPosition(x, y++);
            Console.Write("   |   OOOO   || A N D R E X | |");
            Console.SetCursorPosition(x, y++);
            Console.Write("   |   OOOO   |                |");
            Console.SetCursorPosition(x, y++);
            Console.Write("    \\   OOO   /                /");
            Console.SetCursorPosition(x, y++);
            Console.Write("     \\      // / / / / / / / //");
            Console.SetCursorPosition(x, y++);
            Console.Write("       `--'-|| | | | | | | | |");
            Console.SetCursorPosition(x, y++);
            Console.Write("             \\                \\");
            Console.SetCursorPosition(x, y++);
            Console.Write("              \\                \\");
            Console.SetCursorPosition(x, y++);
            Console.Write("               \\                \\");
            Console.SetCursorPosition(x, y++);
            Console.Write("                \\ \\ \\ \\ \\ \\ \\ \\ \\\\");
            Console.SetCursorPosition(x, y++);
            Console.Write("                 \\________________\\");
            Console.WriteLine();
        }
        //************************************************************************
        private void drawSmile()
        {
            Console.WriteLine("\n                    .-\"\"\"\"-.-\"\"\"\"-. ");
            Console.WriteLine("               _.'`               `'._   ");
            Console.WriteLine("            .-'  __..,.___.___.,..__  '-.   ");
            Console.WriteLine("           '-.-;` |  |    |    |  | `;-.-'   ");
            Console.WriteLine("            \\'-\\_/\\__|    |    |__/\\_/-'/   ");
            Console.WriteLine("             \\, _     '---'---'     _ ,/   ");
            Console.WriteLine("              \\'./`'.--.--.--,--.'`\\.'/   ");
            Console.WriteLine("               \\ `'-;__|__|__|__;-'` /   ");
            Console.WriteLine("                '.                 .'   ");
            Console.WriteLine("                 `'-....---....-'`    ");
        }
        //*************************************
        private void drawThumbsUp()
        {
            Console.WriteLine();
            Console.WriteLine("       _ ");
            Console.WriteLine("      ( ((  ");
            Console.WriteLine("       \\ =\\   ");
            Console.WriteLine("      __\\_ `-\\   ");
            Console.WriteLine("     (____))(  \\-----  ");
            Console.WriteLine("     (____)) _    ");
            Console.WriteLine("     (____))   ");
            Console.WriteLine("     (____))____/-----  ");
            Console.WriteLine();
        }
        //*************************************
        private void drawThumbsDown()
        {
            Console.WriteLine();
            Console.WriteLine("       ______ ");
            Console.WriteLine("     ((____  \\-----  ");
            Console.WriteLine("     ((_____         ");
            Console.WriteLine("     ((_____      ");
            Console.WriteLine("     ((____   -----   ");
            Console.WriteLine("          /  /    ");
            Console.WriteLine("         (_((     ");
            Console.WriteLine();
        }
    }
}
