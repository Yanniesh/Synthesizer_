using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace Synthesizer
{
    public class Synthesizer
    {
        public List<Oscillator> oscillatorsList = new List<Oscillator>();
        private double volume = 1;
        private string WaveType = "Sine";      
        public void PlayNote(double NoteFrequency)
        {
            Oscillator tempOsc = new Oscillator();
            tempOsc.SetFrequency(NoteFrequency);
            if (!oscillatorsList.Any(x=> x._oscillator.Frequency == NoteFrequency))
            {
                tempOsc.SetVolume(volume);
                tempOsc.SetWaveType(WaveType);
                oscillatorsList.Add(tempOsc);
                tempOsc.Run();
            }           
            
        }
        public void StopNote(double NoteFrequency)
        {
            if (oscillatorsList.Any(x => x._oscillator.Frequency == NoteFrequency)) {
                var SelectedOsc = oscillatorsList.Find(x => x._oscillator.Frequency == NoteFrequency);
                SelectedOsc.Stop();
                oscillatorsList.Remove(SelectedOsc);
            }          
        }

        public void SetVolume(double _volume)
        {
            volume = _volume;
        }
        public void SetWaveType(String _waveType)
        {
            WaveType = _waveType;
        }
    }
}
