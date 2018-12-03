using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Morse.Test
{
    public class SignalBuilder_Test
    {
        [Fact]
        public void Build_returns_IEnumerable_of_Signals()
        {
            var expected = new Signal[]
            {
                new Signal(000, 010), new Signal(020, 030),
                new Signal(060, 090), new Signal(100, 130),
                new Signal(200, 210), new Signal(220, 230)  // ".. __|.."
                 
            };
                

            SignalBuilder b = new SignalBuilder(10);
            b.Dot().Dot().EndLetter().Dash().Dash().EndWord().Dot().Dot();
            var actual = b.Build();

            actual.Should().BeEquivalentTo(expected);

            
        }
    }
}
