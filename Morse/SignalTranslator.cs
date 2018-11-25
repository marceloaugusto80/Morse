using Morse.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Morse
{
    public class SignalTranslator
    {
        public SignalTranslator()
        {
            
        }

        public IEnumerable<char> Translate(IEnumerable<Signal> signals)
        {
            Signal[] signalArr = signals.ToArray();

            long averageDuration = CalculateAverageUnitDuration(signalArr);

            int a = 0;
            int b = 1;

            List<char> letters = new List<char>();

            List<char> signBuffer = new List<char>(5);

            while(b < signalArr.Length)
            {
                Signal curr = signalArr[a];
                Signal next = signalArr[b];


                if (curr.Duration >= averageDuration * 3)
                {
                    // is a dash
                    signBuffer.Add(MorseRules.DAH);
                }
                else if (curr.Duration <= averageDuration)
                {
                    // is a dot
                    signBuffer.Add(MorseRules.DIH);
                }


                long intervalToNext = next.OnTimeStamp - curr.OffTimeStamp;

                if (intervalToNext >= averageDuration * 7)
                {
                    // word end
                    string dihDahResult = new string(signBuffer.ToArray());
                    letters.Add(MorseRules.Dictionary[dihDahResult]);
                    signBuffer.Clear();
                    letters.Add(' ');
                }
                else if (intervalToNext >= averageDuration * 3)
                {
                    // letter end
                    string dihDahResult = new string(signBuffer.ToArray());
                    letters.Add(MorseRules.Dictionary[dihDahResult]);
                    signBuffer.Clear();
                }

                a++;
                b++;

            }

            if(signBuffer.Count > 0)
            {
                string res = new string(signBuffer.ToArray());
                letters.Add(MorseRules.Dictionary[res]);
            }

            return letters;
        }

        private long CalculateAverageUnitDuration(IEnumerable<Signal> signals)
        {
            return signals.Min(x => x.Duration);
        }

        private IEnumerable<char> TranslateToTernary(IEnumerable<Signal> signals)
        {
            long timeUnit = CalculateAverageUnitDuration(signals);

            long spaceDuration = timeUnit * 7,
                 dahDuration = timeUnit * 3,
                 dihDuration = timeUnit;


            foreach (var s in signals)
            {
                if (s.Duration == 0) continue;

                if (s.Duration >= spaceDuration) yield return MorseRules.SILENCE;

                if (s.Duration >= dahDuration) yield return MorseRules.DAH;

                yield return MorseRules.DIH;
            }

        }

    }
}
