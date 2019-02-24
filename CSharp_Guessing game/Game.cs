using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Guessing_game
{
    public class Game
    {
        private int score;
        private Word newWord;
        private List<string> lettersAlreadyGuessed;

        public Game()
        {
            this.score = 0;
            this.lettersAlreadyGuessed = new List<string>();
        }


        public void GenerateWord()
        {
            var randomWord = WordList.GetRandomWord();
            Console.WriteLine(randomWord);
            Console.WriteLine("You got a new word!");
            Console.ReadLine();

        }                               
    }
}
