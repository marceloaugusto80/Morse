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
}
