using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Morse
{
    /// <summary>
    /// Creates a sequence of Signals based on provided dashes and dots.
    /// </summary>
    public class SignalBuilder
    {

        public long DotDuration { get; }
        private const char DOT = '.';
        private const char DASH = '_';
        private const char CHAR_SEPARATOR = ' ';
        private const char WORD_SEPARATOR = '|';

        private readonly List<char> charList;

        public SignalBuilder(long dotDuration)
        {
            DotDuration = dotDuration;
            charList = new List<char>();
        
        }

        public SignalBuilder Dash()
        {
            charList.Add(DASH);
            return this;
        }

        public SignalBuilder Dot()
        {
            charList.Add(DOT);
            return this;
        }

        public SignalBuilder EndLetter()
        {
            charList.Add(CHAR_SEPARATOR);
            return this;
        }

        public SignalBuilder EndWord()
        {
            charList.Add(WORD_SEPARATOR);
            return this;
        }

        public IEnumerable<Signal> Build()
        {
            string morseChars = new string(charList.ToArray());

            long currentTime = 0L;

            for (int i = 0; i < morseChars.Length; i++)
            {
                char currChar = morseChars[i];

                if (currChar == WORD_SEPARATOR)
                {
                    currentTime += DotDuration * 7;
                }
                else if(currChar == CHAR_SEPARATOR)
                {
                    currentTime += DotDuration * 3;
                }
                else
                {
                    long duration;

                    if(currChar == DOT)
                    {
                        duration = DotDuration;
                    }
                    else if(currChar == DASH)
                    {
                        duration = DotDuration * 3;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Character {currChar} is invalid.");
                    }

                    long on = currentTime;
                    currentTime += duration;

                    bool hasNext = i < morseChars.Length - 1;
                    bool nextIsWhiteSpace = hasNext && (morseChars[i + 1] == WORD_SEPARATOR || morseChars[i + 1] == CHAR_SEPARATOR);

                    if (!nextIsWhiteSpace)
                    {
                        currentTime += DotDuration;
                    }


                    yield return new Signal(on, on + duration);
                }
            }

        }

    }
}
