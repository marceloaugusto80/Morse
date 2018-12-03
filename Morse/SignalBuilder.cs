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

        List<char> _chars;
        IDictionary<char, long> _charDurationMap;


        public SignalBuilder(long dotDuration)
        {
            DotDuration = dotDuration;
          
            _chars = new List<char>();

            _charDurationMap = new Dictionary<char, long>
            {
                { DOT, dotDuration },
                { DASH, dotDuration * 3 },
                { CHAR_SEPARATOR, dotDuration },
                { WORD_SEPARATOR, dotDuration * 7 }
            };
        }


        public SignalBuilder Dash()
        {
            _chars.Add(DASH);
            return this;
        }

        public SignalBuilder Dot()
        {
            _chars.Add(DOT);
            return this;
        }

        public SignalBuilder EndLetter()
        {
            _chars.Add(CHAR_SEPARATOR);
            return this;
        }

        public SignalBuilder EndWord()
        {
            _chars.Add(WORD_SEPARATOR);
            return this;
        }

        public IEnumerable<Signal> Build()
        {
            string morseChars = new string(_chars.ToArray());

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
                    long duration = 0L;

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
                    bool nextIsWhiteSpace = hasNext ? morseChars[i + 1] == WORD_SEPARATOR || morseChars[i + 1] == CHAR_SEPARATOR : false;

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
