using NAudio.Dsp;
using NAudio.Wave;
using System;

namespace Synthesizer
{
    public class Oscillator : ISampleProvider
    {
        int _sampleRate;
        private readonly SampleGenerator sourceOSC;
        private readonly EnvelopeGenerator ADSREnv;
        public WaveFormat WaveFormat { get; }
        bool enableSubOsc;
        float _attack;
        float _decay;
        float sustain;
        float release;
        double NoteFreq;
        double _LFOFreq;
        double _LFOGain;
        double _subBassGain;
        float _panning;
        public bool EnableSubOsc
        {
            get
            {
                return enableSubOsc;
            }
            set
            {
                enableSubOsc = value;
                if (sourceOSC != null)
                {
                    sourceOSC.EnableSubOsc = value;
                }
            }
        } 
        public float AttackSeconds
        {
            get => _attack;
            set
            {
                _attack = value;
                ADSREnv.AttackRate = _attack * WaveFormat.SampleRate;
            }
        }    
        public float DecaySeconds
        {
            get => _decay;
            set
            {
                _decay = value;
                ADSREnv.DecayRate = _decay * WaveFormat.SampleRate;
            }
        }    
        public float SustainLevel
        {
            get => sustain;
            set
            {
                sustain = value;
                ADSREnv.SustainLevel = sustain;
            }
        }
        public float ReleaseSeconds
        {
            get => release;

            set
            {
                release = value;
                ADSREnv.ReleaseRate = release * WaveFormat.SampleRate;
            }
        }
        public double NoteFrequency
        {
            get => NoteFreq;
            set
            {
                NoteFreq = value;
                if (sourceOSC != null)
                {
                    sourceOSC.Frequency = NoteFreq;
                }
            }
        }
        public double LFOFrequency
        {
            get
            {
                return _LFOFreq;
            }
            set
            {
                _LFOFreq = value;
                sourceOSC.LFOFreq = value;
            }
        }
        
        public double LFOGain
        {
            get
            {
                return _LFOGain;
            }
            set
            {
                _LFOGain = value;
                sourceOSC.LFO_Vol = value;
            }
        }
        public double SubBassGain
        {
            get
            {
                return _subBassGain;
            }
            set
            {
                _subBassGain = value;
                sourceOSC.subBassGain = value;
            }
        }
        public float Panning
        {
            get
            {
                return _panning;
            }
            set
            {
                _panning = value;
                sourceOSC.Panning = value;
            }
        }
        public Oscillator(String waveType, float level, double freq, int sampleRate = 44100)
        {
            _sampleRate = sampleRate;
            var channels = 2;
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(_sampleRate, channels);
            ADSREnv = new EnvelopeGenerator();
            sourceOSC = new SampleGenerator(_sampleRate, channels)
            {
                Frequency = freq,
                Type = waveType,
                Gain = level,
                Panning = 1.0f
            };
            ADSREnv.Gate(true);
        }

        public void Stop() 
        {
            ADSREnv.Gate(false);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            if (ADSREnv.State == EnvelopeGenerator.EnvelopeState.Idle) { return 0; }
            var sampleCount = sourceOSC.Read(buffer, offset, count);
            for (var i = 0; i < sampleCount; i++)
            {
                buffer[offset++] *= ADSREnv.Process();
            }
            return sampleCount;
        }
    }
}
