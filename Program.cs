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
            var GuessNumber = new GuessNumber();

            GuessNumber.maxNumber = 200;

            GuessNumber.InformUser();

            GuessNumber.DiscoverNumber();

            GuessNumber.WriteGuessedNumber();
        }
    }
}
