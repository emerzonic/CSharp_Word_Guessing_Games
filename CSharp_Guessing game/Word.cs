using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Guessing_game
{
    public class Word
    {
        private string CurrentWord { get; set; }
        private Letter[] Letters { get; set; }
        private bool IsWorldGuessed { get; set; }
        private int GuessTracker { get; set; }
        private int NumberOfAttempts { get; set; }
        public Word(string word)
        {
            CurrentWord = word;
            Letters = new Letter[this.CurrentWord.Length];
            IsWorldGuessed = false;
            GuessTracker = 0;
            NumberOfAttempts = 0;
        }



        public void GetLettersFromWord()
        {
            var tempArray = CurrentWord.ToCharArray();
            const int position = 0;
            foreach (var letter in tempArray)
            {
                var newLetter = new Letter(letter);
                Letters.SetValue(letter, position);
            }
        }
       
    }
}
