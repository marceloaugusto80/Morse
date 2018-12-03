using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morse
{
    public class MorseTranslator
    {
        private readonly MorseDictionary _morseDic;

        public char Dot { get; }
        public char Dash { get; }
        public char MorseLetterSeparator { get; }
        public char MorseWordSeparator { get; }

        public MorseTranslator(char dot, char dash, char morseLetterSeparator, char morseWordSeparator)
        {
            Dot = dot;
            Dash = dash;
            MorseLetterSeparator = morseLetterSeparator;
            MorseWordSeparator = morseWordSeparator;

            _morseDic = new MorseDictionary(dot, dash);
        }


        public string TranslateToMorse(string txt)
        {
            IEnumerable<string> words = txt.Split(' ').Select(x => ConvertWordToMorse(x));
            return string.Join(MorseWordSeparator.ToString(), words);
        }

        public string TranslateToText(string morseString)
        {
            IEnumerable<string> morseWords = morseString.Split(MorseWordSeparator);
            IEnumerable<string> words = morseWords.Select(word => ConvertMorseToWord(word));
            return string.Join(" ", words);
        }

        private string ConvertWordToMorse(string word)
        {
            IEnumerable<string> morse = word.Select(c => _morseDic.GetMorse(c));
            return string.Join(MorseLetterSeparator.ToString(), morse);
        }

        private string ConvertMorseToWord(string morseWord)
        {
            if (morseWord == string.Empty) return string.Empty; // avoid returning \0 char because each counts as +1 in string length and fucks up comparisons
            var word = morseWord.Split(MorseLetterSeparator).Select(letter => _morseDic.GetCharacter(letter));
            return new string(word.ToArray());
        }
    }
}
