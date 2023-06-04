using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer
{
    public class PianoKey
    {
        public int Index;
        public string NoteName;
        public float frequency;
        public PianoKey(int _index, string _noteName, float _frequency)
        {
            Index = _index;
            NoteName = _noteName;
            frequency = _frequency;
        }
    }
}
