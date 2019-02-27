using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Guessing_game
{
    public class Word
    {
        public string CurrentWord { get; set; }
        private Letter[] Letters { get; set; }
        public bool IsWordGuessed { get; set; }
        private int GuessTracker { get; set; }
        public int NumberOfAttempts { get; set; }
        private string DisplayWord { get; set; }
        private int WordTracker { get; set; }

        public Word(string word)
        {
            CurrentWord = word;
            Letters = new Letter[this.CurrentWord.Length];
            IsWordGuessed = false;
            GuessTracker = 0;
            NumberOfAttempts = 0;
            DisplayWord = "";
            WordTracker = 0;
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
            //Console.ReadLine();
        }

        public void CheckWhetherWordIsGuessed()
        {
            if (!DisplayWord.Contains("_"))
            {
                IsWordGuessed = true;
                Console.WriteLine("You guessed it right");
            }
        }

        public void TakeGuess(char guess)
        {
            foreach (var letter in Letters)
            {
                letter.CheckGuess(guess);
            }
        }

        internal void GetFeedBack()
        {
         
            foreach(Letter letter in Letters)
            {
                if (!letter.GetLetterOrPlaceHolder().Equals('_'))
                {
                    WordTracker++;
                }
            }
            CompareWord();
        }

        private void CompareWord()
        {
            if (GuessTracker != WordTracker)
            {
                GetCorrectFeedBack();
            }
            else
            {
                GetIncorrectFeedBack();
            }
            GetRemainingLetters();
        }

        private void GetCorrectFeedBack()
        {
            Console.WriteLine("\nCORRECT!");
           // Console.ReadLine();
        }

        private void GetIncorrectFeedBack()
        {
            NumberOfAttempts--;
            Console.WriteLine("\nINCORRECT!");
            //Console.ReadLine();
            var attemptText = GetSingularOrPluralText(NumberOfAttempts,"attempt");
            Console.WriteLine($"You have {NumberOfAttempts} {attemptText} remaining.");
            //Console.ReadLine();
        }

        private void GetRemainingLetters()
        {
            int remainingLetters = CurrentWord.Length - WordTracker;
            string lettersText = GetSingularOrPluralText(remainingLetters, "letter");
            Console.WriteLine($"You have {remainingLetters} {lettersText} more to guess.");
            //Console.ReadLine();
        }

        private string GetSingularOrPluralText(int number, string word)
        {
            return number >= 2 ? word + "s" : word;
    
        }



    }
}
