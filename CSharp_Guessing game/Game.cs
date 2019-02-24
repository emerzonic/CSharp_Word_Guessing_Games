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

        public void StartGame()
        {
            SetNewWord();
            SetUpGame();

        }

        public string GetGeneratedWord()
        {   
            return WordList.GetRandomWord();
        }

        private void SetNewWord()
        {
            var word = GetGeneratedWord();
            newWord = new Word(word);
        }

        private void SetUpGame()
        {
            newWord.OrganizedWord();
            newWord.DisplayCurrentWord();
        }

        private void TakePlayerGuess()
        {
            Console.WriteLine("Guess a letter");

        }
    }
}
