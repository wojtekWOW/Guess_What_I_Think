using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Guess_What_I_Think
{
    /// <summary>
    /// Guess number what user thinks
    /// </summary>
    public class GuessNumber
    {

        #region Public Properties
        /// <summary>
        /// The largest number we ask user to think between 0 and this number 
        /// </summary>
        public int maxNumber { get; set; } 

        /// <summary>
        /// The smallest number user can guess
        /// </summary>
        public int minNumber { get; private set; }

        /// <summary>
        /// Minimum of current range 
        /// </summary>
        public int guessMin { get; private set; }

        /// <summary>
        /// Maximum of current range
        /// </summary>
        public int guessMax { get; private set; }

        /// <summary>
        /// Number of guesses done by program
        /// </summary>
        public int numberOfGuesses { get; private set; }

        /// <summary>
        /// User response to a question if his/her number is in given range
        /// </summary>
        public string response { get; private set; }
        #endregion

        #region cstor

        ///<summary>
        ///Default constructor
        ///</summary>
        public GuessNumber()
        {
            //set default max number
            this.maxNumber = 100;
            
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Introduction statement, ask user to think about a number in given range
        /// </summary>
        /// 
        public void InformUser()
        {
            
            Console.WriteLine("I'm going to guess a number you think!");
            Console.WriteLine($"Think about a number from {this.minNumber} to {this.maxNumber} .");
        }

        /// <summary>
        /// Function asking if guessed number is in current range
        /// </summary>

        public void DiscoverNumber()
        {
            //Initialize variables
            guessMin = 0;
            guessMax = maxNumber / 2;
            numberOfGuesses = 0;


            //Ask questions about the number until there are only 2 numbers left 
            while (this.guessMin != this.guessMax)
            {
                //Increase number of guesses
                this.numberOfGuesses++;
                //Ask user if the number is in current range
                Console.WriteLine($"Is the number you think about between {this.guessMin} and {this.guessMax} ?");
                response = Console.ReadLine();
                //Check if first letter is y ot Y
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    //Programs knows  that number is in current range so sets new maximum number
                    maxNumber = this.guessMax;
                    //Program sets the new guess max in the middle of current range
                    guessMax = (int)Math.Ceiling(this.guessMax - (this.guessMax - this.guessMin) / 2f);
                }
                else if (response?.ToLower().FirstOrDefault() == 'n')
                {
                    //Programs knows  that number is above current range so sets new minimum number
                    this.guessMin = this.guessMax + 1;
                    //Program sets the new guess max in the middle of above range
                    this.guessMax = this.maxNumber - (int)Math.Floor((this.maxNumber - this.guessMax) / 2f);
                }
                else
                {
                    // Ask to type correct answer
                    Console.WriteLine("I will ask again. Please type 'yes' or 'no' ");
                    this.numberOfGuesses--;
                }
                //check if current range has only 2 values
                if (this.guessMin + 1 == this.maxNumber)
                    break;
            }
            Console.WriteLine($"Is your number {this.guessMin}");
            response = Console.ReadLine();

        }
        
        /// <summary>
        /// Anounces the number
        /// </summary>
        public void WriteGuessedNumber()
        {
            if (response?.ToLower().FirstOrDefault() == 'y')
            {
                Console.WriteLine($"Your number  is {this.guessMin} ! I guessed in {this.numberOfGuesses} try");
            }
            else
            {
                Console.WriteLine($"Your number  is {this.maxNumber} ! I guessed in {this.numberOfGuesses} try");
            }
        }

        #endregion
    };
}
