using System;
using Xunit;
using FluentAssertions;
using Morse.Base;

namespace Morse.Test
{
    public class SignalTranslator_Test
    {
        [Fact]
        public void Translate_returns_correct_characters()
        {
            var signals = new SignalBuilder()
                .Add(10,  20,   30, 60)   
                .Add(130, 160,  170, 180,   190, 200,   210, 220).Build();
            SignalTranslator transl = new SignalTranslator();
            var actual = transl.Translate(signals);


            var expected = "a b".ToCharArray();

            actual.Should().BeEquivalentTo(expected);


            
        }
    }
}
