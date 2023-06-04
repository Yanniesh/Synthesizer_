using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Synthesizer
{
    public class PianoKeys
    {
        public List<string> KeysLettersArray = new List<string>();
        public List<float> NotesFrequencies = new List<float>();
        public List<PianoKey> ListOfKeys =  new List<PianoKey>();
        const double DefaultPitchForA = 27.50;
        int NumOfOctaves = 5;
        public PianoKeys()
        {
            addkeysLetters();
            addNoteFrequnecies();
            makeKeyList();
        }
        public void makeKeyList()
        {
            for (int i = 0; i < KeysLettersArray.Count(); i++)
            {
                ListOfKeys.Add(new PianoKey(i,KeysLettersArray[i], NotesFrequencies[i]));
            }
        }
        public void addkeysLetters()
        {
            for (int i = 1; i <= NumOfOctaves; i++)
            {
                KeysLettersArray.Add("C" + i);
                KeysLettersArray.Add("C#" + i);
                KeysLettersArray.Add("D" + i);
                KeysLettersArray.Add("D#" + i);
                KeysLettersArray.Add("E" + i);
                KeysLettersArray.Add("F" + i);
                KeysLettersArray.Add("F#" + i);
                KeysLettersArray.Add("G" + i);
                KeysLettersArray.Add("G#" + i);
                KeysLettersArray.Add("A" + i);
                KeysLettersArray.Add("A#" + i);
                KeysLettersArray.Add("B" + i);
            }
            KeysLettersArray.Add("C" + (NumOfOctaves +1));

        }
        public void addNoteFrequnecies()
        {
            double OctaveFreq = DefaultPitchForA;
            for (int i = 3; i <= NumOfOctaves * 12 + 3; i++)
            {
                Convert.ToDouble(i);
                double factor = Math.Pow(2, (i % 12) / 12.0);
                if(factor == 1)
                {
                    OctaveFreq = OctaveFreq * 2;
                }
                double NoteFreq = OctaveFreq * factor;
                NoteFreq = Math.Round(NoteFreq, 2);
                NotesFrequencies.Add((float)NoteFreq);                
            }
        }
    }
}
