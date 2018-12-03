using System.Collections.Generic;

namespace Morse
{
    public class MorseDictionary
    {
        private readonly IDictionary<string, char> _signalCharMap;
        private readonly IDictionary<char, string> _charSignalMap;


        public MorseDictionary(char dotChar = '.', char dashChar = '_')
        {
            char dih = dotChar;
            char dah = dashChar;

            _signalCharMap = new Dictionary<string, char>()
            {
                { string.Concat(dih, dah),              'a' },
                { string.Concat(dah, dih, dih, dih),    'b' },
                { string.Concat(dah, dih, dah, dih),    'c' },
                { string.Concat(dah, dih, dih),         'd' },
                { string.Concat(dih),                   'e' },
                { string.Concat(dih, dih, dah, dih),    'f' },
                { string.Concat(dah, dah, dih),         'g' },
                { string.Concat(dih, dih, dih, dih),    'h' },
                { string.Concat(dih, dih),              'i' },
                { string.Concat(dih, dah, dah, dah),    'j' },
                { string.Concat(dah, dih, dah),         'k' },
                { string.Concat(dih, dah, dih, dih),    'l' },
                { string.Concat(dah, dah),              'm' },
                { string.Concat(dah, dih),              'n' },
                { string.Concat(dah, dah, dah),         'o' },
                { string.Concat(dih, dah, dah, dih),    'p' },
                { string.Concat(dah, dah, dih, dah),    'q' },
                { string.Concat(dih, dah, dih),         'r' },
                { string.Concat(dih, dih, dih),         's' },
                { string.Concat(dah),                   't' },
                { string.Concat(dih, dih, dah),         'u' },
                { string.Concat(dih, dih, dih, dah),    'v' },
                { string.Concat(dih, dah, dah),         'w' },
                { string.Concat(dah, dih, dih, dah),    'x' },
                { string.Concat(dah, dih, dah, dah),    'y' },
                { string.Concat(dah, dah, dih, dih),    'z' },
                 
                { string.Concat(dih, dah, dah, dah, dah),   '1' },
                { string.Concat(dih, dih, dah, dah, dah),   '2' },
                { string.Concat(dih, dih, dih, dah, dah),   '3' },
                { string.Concat(dih, dih, dih, dih, dah),   '4' },
                { string.Concat(dih, dih, dih, dih, dih),   '5' },
                { string.Concat(dah, dih, dih, dih, dih),   '6' },
                { string.Concat(dah, dah, dih, dih, dih),   '7' },
                { string.Concat(dah, dah, dah, dih, dih),   '8' },
                { string.Concat(dah, dah, dah, dah, dih),   '9' },
                { string.Concat(dah, dah, dah, dah, dah),   '0' }
            };

            _charSignalMap = new Dictionary<char, string>()
            {
                { 'a', string.Concat(dih, dah)           },
                { 'b', string.Concat(dah, dih, dih, dih) },
                { 'c', string.Concat(dah, dih, dah, dih) },
                { 'd', string.Concat(dah, dih, dih)      },
                { 'e', string.Concat(dih)                },
                { 'f', string.Concat(dih, dih, dah, dih) },
                { 'g', string.Concat(dah, dah, dih)      },
                { 'h', string.Concat(dih, dih, dih, dih) },
                { 'i', string.Concat(dih, dih)           },
                { 'j', string.Concat(dih, dah, dah, dah) },
                { 'k', string.Concat(dah, dih, dah)      },
                { 'l', string.Concat(dih, dah, dih, dih) },
                { 'm', string.Concat(dah, dah)           },
                { 'n', string.Concat(dah, dih)           },
                { 'o', string.Concat(dah, dah, dah)      },
                { 'p', string.Concat(dih, dah, dah, dih) },
                { 'q', string.Concat(dah, dah, dih, dah) },
                { 'r', string.Concat(dih, dah, dih)      },
                { 's', string.Concat(dih, dih, dih)      },
                { 't', string.Concat(dah)                },
                { 'u', string.Concat(dih, dih, dah)      },
                { 'v', string.Concat(dih, dih, dih, dah) },
                { 'w', string.Concat(dih, dah, dah)      },
                { 'x', string.Concat(dah, dih, dih, dah) },
                { 'y', string.Concat(dah, dih, dah, dah) },
                { 'z', string.Concat(dah, dah, dih, dih) },

                { '1', string.Concat(dih, dah, dah, dah, dah) },
                { '2', string.Concat(dih, dih, dah, dah, dah) },
                { '3', string.Concat(dih, dih, dih, dah, dah) },
                { '4', string.Concat(dih, dih, dih, dih, dah) },
                { '5', string.Concat(dih, dih, dih, dih, dih) },
                { '6', string.Concat(dah, dih, dih, dih, dih) },
                { '7', string.Concat(dah, dah, dih, dih, dih) },
                { '8', string.Concat(dah, dah, dah, dih, dih) },
                { '9', string.Concat(dah, dah, dah, dah, dih) },
                { '0', string.Concat(dah, dah, dah, dah, dah) }
            };
        }

        public string GetMorse(char character)
        {
            
            if (!_charSignalMap.TryGetValue(char.ToLower(character), out string result))
                return string.Empty;

            return result;
        }

        public char GetCharacter(string morse)
        {
            if (!_signalCharMap.TryGetValue(morse, out char result))
                return '\0';
            return result;
        }
    }
}
