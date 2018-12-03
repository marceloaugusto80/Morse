using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Morse.Test
{
    public class MorseDictionary_Test
    {
        [Theory]
        [InlineData('#')]
        [InlineData('@')]
        [InlineData('/')]
        [InlineData('}')]
        [InlineData('=')]
        public void GetSignalString_returns_empty_string_when_char_not_found(char input)
        {
            MorseDictionary dic = new MorseDictionary('.', '_');

            var actual = dic.GetMorse(input);

            Assert.Equal(actual, string.Empty);

        }

        [Theory]
        [InlineData("..........")]
        [InlineData(".__..___")]
        [InlineData("._._._._")]
        [InlineData("_________")]
        public void GetCharacter_returns_null_char_when_input_not_found(string input)
        {
            MorseDictionary dic = new MorseDictionary('.', '_');

            var actual = dic.GetCharacter(input);

            Assert.Equal('\0', actual);

        }
    }
}
