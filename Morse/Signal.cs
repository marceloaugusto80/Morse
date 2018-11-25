using System;
using System.Collections.Generic;
using System.Linq;

namespace Morse
{



    public class Signal
    {
        public long OnTimeStamp { get; set; }
        public long OffTimeStamp { get; set; }
        public long Duration { get; private set; }

        public Signal(long onTimeStamp = 0, long offTimeStamp = 0)
        {
            OnTimeStamp = onTimeStamp;
            OffTimeStamp = offTimeStamp;
            Duration = OffTimeStamp - OnTimeStamp;
        }

        public override string ToString()
        {
            return $"{OnTimeStamp} - {OffTimeStamp} : {Duration}";
        }
    }

    public class SignalBuilder
    {
        private List<Signal> _signals;

        public SignalBuilder()
        {
            _signals = new List<Signal>(32);
        }

        public SignalBuilder Add(long onTimeStamp, long offTimeStamp)
        {
            _signals.Add(new Signal(onTimeStamp, offTimeStamp));
            return this;
        }

        public SignalBuilder Add(params long[] alternateOnOfTimestamps)
        {
            if (alternateOnOfTimestamps.Length % 2 != 0)
                throw new ArgumentException("Alternate timestamps should be even.");

            for (int i = 0; i < alternateOnOfTimestamps.Length; i += 2)
            {
                _signals.Add(new Signal(alternateOnOfTimestamps[i], alternateOnOfTimestamps[i + 1]));
            }

            return this;
        }

        public IEnumerable<Signal> Build()
        {
            return _signals;
        }
    }
}
