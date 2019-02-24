using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Guessing_game
{
    public class Word
    {
        private string CurrentWord { get; set; }
        private Letter[] Letters { get; set; }
        private bool IsWordGuessed { get; set; }
        private int GuessTracker { get; set; }
        private int NumberOfAttempts { get; set; }
        private string DisplayWord { get; set; }

        public Word(string word)
        {
            CurrentWord = word;
            Letters = new Letter[this.CurrentWord.Length];
            IsWordGuessed = false;
            GuessTracker = 0;
            NumberOfAttempts = 0;
            DisplayWord = "";
        }

        public void OrganizedWord()
        {
            GetLettersFromWord();
            SetAttempts();
        }

        private void GetLettersFromWord()
        {
            var charArray = CurrentWord.ToCharArray();
            var position = 0;
            foreach (var letter in charArray)
            {
                var newLetter = new Letter(letter);
                Letters.SetValue(newLetter, position);
                position++;
            }
        }

        private void SetAttempts()
        {
            NumberOfAttempts = CurrentWord.Length * 3;
            Console.WriteLine($"You have {NumberOfAttempts} fail attempts to make on this word.");
        }

        public void DisplayCurrentWord()
        {
            var tempString = new StringBuilder();
            foreach (var letter in Letters)
            {
                var character = " " + letter.GetLetterOrPlaceHolder();
                tempString.Append(character);
            }

            DisplayWord = tempString.ToString();
            Console.WriteLine(DisplayWord);
            Console.ReadLine();
        }

        public void CheckWordStatus()
        {
            if (!DisplayWord.Contains("_"))
            {
                IsWordGuessed = true;
                Console.WriteLine("You guessed it right");
            }
        }

        private void CheckGuessStatus()
        {

        }


    }
}
