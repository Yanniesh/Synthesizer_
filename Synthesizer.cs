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
        public List<Oscillator> oscillatorsList2 = new List<Oscillator>();
        private double volume = 0.3;
        private string WaveType = "Sine";
        private double volume2 = 0.2;
        private string WaveType2 = "SawTooth";
        public bool Oscilllator2TurnON = false;
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
            if (Oscilllator2TurnON)
            {
                Oscillator tempOsc2 = new Oscillator();
                tempOsc2.SetFrequency(NoteFrequency);
                if (!oscillatorsList2.Any(x => x._oscillator.Frequency == NoteFrequency))
                {
                    tempOsc2.SetVolume(volume2);
                    tempOsc2.SetWaveType(WaveType2);
                    oscillatorsList2.Add(tempOsc2);
                    tempOsc2.Run();
                }
            }

        }
        public void StopNote(double NoteFrequency)
        {
            if (oscillatorsList.Any(x => x._oscillator.Frequency == NoteFrequency)) {
                var SelectedOsc = oscillatorsList.Find(x => x._oscillator.Frequency == NoteFrequency);
                SelectedOsc.Stop();
                oscillatorsList.Remove(SelectedOsc);
            }
            if (Oscilllator2TurnON)
            {
                if (oscillatorsList2.Any(x => x._oscillator.Frequency == NoteFrequency))
                {
                    var SelectedOsc = oscillatorsList2.Find(x => x._oscillator.Frequency == NoteFrequency);
                    SelectedOsc.Stop();
                    oscillatorsList2.Remove(SelectedOsc);
                }
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

        public void SetVolume2(double _volume)
        {
            volume2 = _volume;
        }
        public void SetWaveType2(String _waveType)
        {
            WaveType2 = _waveType;
        }
    }
}
