using System;
using Xunit;
using FluentAssertions;
using Morse;

namespace Morse.Test
{
    public class SignalBuilder_Test
    {
        [Fact]
        public void Add_returns_signals_with_on_off_timestamps()
        {
            var signals = new Signal[]
            {
                new Signal(10, 20),
                new Signal(30, 40),
                new Signal(40, 90)
            };

            SignalBuilder builder = new SignalBuilder();
            foreach (var s in signals)
            {
                builder.Add(s.OnTimeStamp, s.OffTimeStamp);
            }

            var actual = builder.Build();
            var expected = signals;

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void Add_returns_signals_with_variadic_timestamps()
        {
            var signals = new Signal[]
            {
                new Signal(10, 20),
                new Signal(30, 40),
                new Signal(40, 90)
            };

            SignalBuilder builder = new SignalBuilder();
            builder.Add(10, 20, 30, 40, 40, 90);

            var actual = builder.Build();
            var expected = signals;

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void Add_with_variadic_timestamps_throws_without_last_off_timestamp()
        {
            
            SignalBuilder builder = new SignalBuilder();

            Action action = () =>
            {
                builder.Add(10, 20,   30, 40,   40, 90,   100);

            };

            action.Should().Throw<ArgumentException>();

        }
    }
}
