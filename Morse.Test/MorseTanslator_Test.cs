using System;
using Xunit;
using FluentAssertions;


namespace Morse.Test
{
    public class MorseTranslator_Test
    {
        [Theory]
        [InlineData("hello", ".... . ._.. ._.. ___")]
        [InlineData(" hello ", "|.... . ._.. ._.. ___|")]
        [InlineData("hi there", ".... ..|_ .... . ._. .")]
        [InlineData(" hi there ", "|.... ..|_ .... . ._. .|")]
        [InlineData("the quick brown fox jumps over the lazy dog", "_ .... .|__._ .._ .. _._. _._|_... ._. ___ .__ _.|.._. ___ _.._|.___ .._ __ .__. ...|___ ..._ . ._.|_ .... .|._.. ._ __.. _.__|_.. ___ __.")]
        public void TranslateMorse_returns_morse_chars(string input, string expected)
        {
            MorseTranslator trans = new MorseTranslator('.', '_', ' ', '|');
            var actual = trans.TranslateToMorse(input);
            actual.Should().Be(expected);
        }


        [Theory]
        [InlineData(".... . ._.. ._.. ___", "hello")]
        [InlineData("|.... . ._.. ._.. ___|", " hello ")]
        [InlineData(".... ..|_ .... . ._. .", "hi there")]
        [InlineData("|.... ..|_ .... . ._. .|", " hi there ")]
        [InlineData("_ .... .|__._ .._ .. _._. _._|_... ._. ___ .__ _.|.._. ___ _.._|.___ .._ __ .__. ...|___ ..._ . ._.|_ .... .|._.. ._ __.. _.__|_.. ___ __.", "the quick brown fox jumps over the lazy dog")]
        public void TranslateText_returns_text(string input, string expected)
        {
            MorseTranslator trans = new MorseTranslator('.', '_', ' ', '|');
            var actual = trans.TranslateToText(input);
            actual.Length.Should().Be(expected.Length);
            actual.Should().Be(expected);
        }


    }
}
