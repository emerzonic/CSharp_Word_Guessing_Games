using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CSharp_Guessing_game
{
    public class Game
    {
        private int _score;
        private Word _newWord;
        private char _guess;
        private readonly List<char> _lettersAlreadyGuessed;

        public Game()
        {
            this._score = 0;
            this._lettersAlreadyGuessed = new List<char>();
        }

        public void PlayGame()
        {
            SetNewWord();
            SetUpGame();
            TakePlayerGuess();
            CheckUserGuess();
            _newWord.TakeGuess(_guess);
            _newWord.DisplayCurrentWord();
            Console.ReadLine();
        }

        public string GetGeneratedWord()
        {   
            return WordList.GetRandomWord();
        }

        private void SetNewWord()
        {
            var word = GetGeneratedWord();
            _newWord = new Word(word);
        }

        private void SetUpGame()
        {
            _newWord.OrganizedWord();
            _newWord.DisplayCurrentWord();
        }

        private void TakePlayerGuess()
        {
            Console.WriteLine("Guess a letter");
            var input = Console.ReadKey().KeyChar;
            ValidateUserInput(input);
        }

        private void ValidateUserInput(char userInput)
        {
             if (!char.IsLetter(userInput))
            {
                Console.WriteLine($"{userInput} is not a valid guess.");
                TakePlayerGuess();
            }
             this._guess = char.ToLower(userInput);
        }

        private void CheckUserGuess()
        {
            if (_lettersAlreadyGuessed.Contains(_guess))
            {
                Console.WriteLine($"You have already guessed {_guess}. Try again.");
                Console.WriteLine($"Letters already guessed: {string.Join(",", _lettersAlreadyGuessed)}.");
                TakePlayerGuess();
            }
            _lettersAlreadyGuessed.Add(_guess);
        }


    }
}
