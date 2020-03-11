using System;

namespace SPSProject
{
    /// <summary>
    /// This class has methods for playing the classic Rock Paper Scissors game.
    /// Author: Shan Ahmed
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This creates a new game object.
        /// And calls the game method.
        /// </summary>
        public static void Main()
        {
            RPSGame myGame = new RPSGame();  
            myGame.Play();            
        }


    }
}
