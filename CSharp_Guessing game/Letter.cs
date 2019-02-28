namespace CSharp_Guessing_game
{
    public class Letter
    {
        public char CurrentLetter { get; set; }
        public char LetterPlaceHolder { get; set; }
        public bool IsLetterGuessed { get; set; }

        public Letter(char letter)
        {
            CurrentLetter = letter;
            LetterPlaceHolder = '_';
            IsLetterGuessed = false;
        }

        public char GetLetterOrPlaceHolder()
        {
            return IsLetterGuessed ? CurrentLetter: LetterPlaceHolder;
        }

        public void CheckGuess(char guess)
        {
            if (CurrentLetter.Equals(guess))
                IsLetterGuessed = true;
        }
   
    }
}