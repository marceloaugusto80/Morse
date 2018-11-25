using System.Collections.Generic;

namespace Morse.Base
{
    internal static class MorseRules
    {
        public const char DAH = '_';
        public const char DIH = '.';
        public const char SILENCE = ' ';

        public const int SPACE_RATIO = 7;
        public const int DASH_RATIO = 3;
        public const int DOT_RATIO = 1;


        public static readonly IDictionary<string, char> Dictionary;

        private delegate string Concat(params char[] args);
        private static readonly Concat c;

        static MorseRules()
        {
            c = string.Concat;
            Dictionary = new Dictionary<string, char>()
            {
                { c(DIH, DAH),              'a' },
                { c(DAH, DIH, DIH, DIH),    'b' },
                { c(DAH, DIH, DAH, DIH),    'c' },
                { c(DAH, DIH, DIH),         'd' },
                { c(DIH),                   'e' },
                { c(DIH, DIH, DAH, DIH),    'f' },
                { c(DAH, DAH, DIH),         'g' },
                { c(DIH, DIH, DIH, DIH),    'h' },
                { c(DIH, DIH),              'i' },
                { c(DIH, DAH, DAH, DAH),    'j' },
                { c(DAH, DIH, DAH),         'k' },
                { c(DIH, DAH, DIH, DIH),    'l' },
                { c(DAH, DAH),              'm' },
                { c(DAH, DIH),              'n' },
                { c(DAH, DAH, DAH),         'o' },
                { c(DIH, DAH, DAH, DIH),    'p' },
                { c(DAH, DAH, DIH, DAH),    'q' },
                { c(DIH, DAH, DIH),         'r' },
                { c(DIH, DIH, DIH),         's' },
                { c(DAH),                   't' },
                { c(DIH, DIH, DAH),         'u' },
                { c(DIH, DIH, DIH, DAH),    'v' },
                { c(DIH, DAH, DAH),         'w' },
                { c(DAH, DIH, DIH, DAH),    'x' },
                { c(DAH, DIH, DAH, DAH),    'y' },
                { c(DAH, DAH, DIH, DIH),    'z' },

                { c(DIH, DAH, DAH, DAH, DAH),   '1' },
                { c(DIH, DIH, DAH, DAH, DAH),   '2' },
                { c(DIH, DIH, DIH, DAH, DAH),   '3' },
                { c(DIH, DIH, DIH, DIH, DAH),   '4' },
                { c(DIH, DIH, DIH, DIH, DIH),   '5' },
                { c(DAH, DIH, DIH, DIH, DIH),   '6' },
                { c(DAH, DAH, DIH, DIH, DIH),   '7' },
                { c(DAH, DAH, DAH, DIH, DIH),   '8' },
                { c(DAH, DAH, DAH, DAH, DIH),   '9' },
                { c(DAH, DAH, DAH, DAH, DAH),   '0' }
            };
        }
    }
}
