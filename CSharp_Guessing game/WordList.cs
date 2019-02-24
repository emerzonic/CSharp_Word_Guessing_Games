using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp_Guessing_game
{
    public class WordList
    {
        private static readonly Random RandomObject = new Random();
        private static readonly string[] Words =
        {
            "cat",
            "rat",
            "mat",
        };

        public static string GetRandomWord()
        {
            var randomNumber = RandomObject.Next(Words.Length);
            var randomWord = Words[randomNumber];
            Console.WriteLine("You got a new word!");
            return randomWord;
        }

    }
}
