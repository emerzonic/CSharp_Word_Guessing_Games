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
            _score = 0;
            _lettersAlreadyGuessed = new List<char>();
        }

        public void StartGame()
        {
            SetNewWord();
            SetUpGame();
            PlayGame();
        }

        private void PlayGame()
        {
            TakePlayerGuess();
            CheckUserGuess();
            _newWord.TakeGuess(_guess);
            _newWord.GetFeedBack();
            _newWord.DisplayCurrentWord();
            CheckGameStatus();
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
                Console.WriteLine($"\n{userInput} is not a valid guess.");
                TakePlayerGuess();
            }
             this._guess = char.ToLower(userInput);
        }

        private void CheckUserGuess()
        {
            if (_lettersAlreadyGuessed.Contains(_guess))
            {
                Console.WriteLine($"\nYou have already guessed {_guess}. Try again.");
                var test = string.Join(",", _lettersAlreadyGuessed);
                Console.WriteLine($"Letters already guessed: {string.Join(",", _lettersAlreadyGuessed)}.");
                TakePlayerGuess();
            }
            _lettersAlreadyGuessed.Add(_guess);
        }

        private void CheckGameStatus()
        {
            if (_newWord.IsWordGuessed)
            {
                _score++;
                Console.WriteLine($"Your score is {_score}");
                _lettersAlreadyGuessed.Clear();
                StartGame();
            }
            else
            {
                if (_newWord.NumberOfAttempts <= 0)
                {
                    Console.WriteLine($"GAME OVER \n The word was {_newWord.CurrentWord}");
                    ResetGame();
                }
                else
                    PlayGame();
            }
        }

        private void ResetGame()
        {
            Console.WriteLine("Would you like to play again? y/n");
            var response = Console.ReadKey().KeyChar;
            if (char.ToLower(response).Equals('y'))
            {
                _lettersAlreadyGuessed.Clear();
                StartGame();
            }
            else
                Environment.Exit(0);
        }
    }
}
