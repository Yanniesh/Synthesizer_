using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Synthesizer
{
    public class Oscillator
    {
        public SignalGenerator _oscillator = null;
        public WaveOutEvent outputEvent;
        bool isPlaying = false;
        public Oscillator() {
            _oscillator = new SignalGenerator(44100, 2);
        }
        public void SetFrequency(double keyFreq)
        {
            _oscillator.Frequency = keyFreq;

        }
        public void SetVolume(double volume)
        {
            _oscillator.Gain = volume;
        }
        public void SetWaveType(String type)
        {
            switch (type)
            {
                case "Sine": _oscillator.Type = SignalGeneratorType.Sin; break;
                case "SawTooth": _oscillator.Type = SignalGeneratorType.SawTooth; break;
                case "Square": _oscillator.Type = SignalGeneratorType.Square; break;
                case "Triangle": _oscillator.Type = SignalGeneratorType.Triangle; break;
                /*case "Sweep": _oscillator.Type = SignalGeneratorType.Sweep; _oscillator.SweepLengthSecs = 2; _oscillator.FrequencyEnd = 2000;  break;*/
            }
        }

        public ISampleProvider runOscillator()
        {
            return _oscillator;
        }
        public void PlaySound()
        {
            outputEvent = new WaveOutEvent();
            outputEvent.Init(runOscillator());
            outputEvent.Play();

        }

        public void Run()
        {
            if (!isPlaying)
            {
                isPlaying = true;
                PlaySound();
            }
        }
        public void Stop()
        {
            outputEvent.Dispose();
            isPlaying = false;
            Console.WriteLine(outputEvent.PlaybackState);
        }
    }
}
