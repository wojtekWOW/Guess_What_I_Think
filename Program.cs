using System;
using System.Net;
using System.Linq;
using System.Security.Cryptography;

namespace Guess_What_I_Think
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int maxNumber = 100;
            int minNumber = 0;
            int guessMin = 0;
            int guessMax = maxNumber / 2;         
            int numberOfGuesses = 0;
            string response;

            //Introduction statement
            Console.WriteLine("I'm going to guess a number you think!");
            Console.WriteLine($"Think about a number from {minNumber} to {maxNumber} .");

            //Ask questions about the number until there are only 2 numbers left 
            while (guessMin  != guessMax)
            {
                //Increase number of guesses
                numberOfGuesses++;
                //Ask user if the number is in current range
                Console.WriteLine($"Is the number you think about between {guessMin} and {guessMax} ?");
                response = Console.ReadLine();
                //Check if first letter is y ot Y
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    //Programs knows  that number is in current range so sets new maximum number
                    maxNumber = guessMax;
                    //Program sets the new guess max in the middle of current range
                    guessMax = (int)Math.Ceiling(guessMax - (guessMax-guessMin)/ 2f);
                }
                else if (response?.ToLower().FirstOrDefault() == 'n')
                {
                    //Programs knows  that number is above current range so sets new minimum number
                    guessMin = guessMax + 1;
                    //Program sets the new guess max in the middle of above range
                    guessMax = maxNumber- (int)Math.Ceiling((maxNumber-guessMax)/2f);
                }
                else
                {
                    // Ask to type correct answer
                    Console.WriteLine("I will ask again. Please type 'yes' or 'no' ");
                    numberOfGuesses--;
                }
                //check if current range has only 2 values
                if (guessMin + 1 == maxNumber)
                    break;
            }
            Console.WriteLine($"Is your number {guessMin}");
            response = Console.ReadLine();
            if (response?.ToLower().FirstOrDefault() == 'y')
            {
                Console.WriteLine($"Your number  is {guessMin} ! I guessed in {numberOfGuesses} try");
            }
            else
            {
                Console.WriteLine($"Your number  is {maxNumber} ! I guessed in {numberOfGuesses} try");
            }
        }
    }
}
