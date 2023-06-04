using NAudio.Wave;
using System;

namespace Synthesizer
{
    public class SampleGenerator : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private const double TwoPi = 2 * Math.PI;
        private int SampleIndex;
        public WaveFormat WaveFormat => waveFormat;
        public double Frequency { get; set; }
        public double Gain { get; set; }
        public String Type { get; set; }
        public double LFOFreq { get; set; }
        public double LFO_Vol { get; set; }
        public bool EnableSubOsc { get; set; }
        public bool Stereo { get; set; }
        public double SubOscillaorFrequency { get; set; }
        public double subBassGain { get; set; }
        public float Panning { get; set; }

        public SampleGenerator(int sampleRate, int channels, double _LFOFreq = 0.0, double _LFOGain = 0.0)
        {
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
            Frequency = 440.0;
            Gain = 1;
            LFOFreq = _LFOFreq;
            LFO_Vol = _LFOGain;
        }

        private double LFO_Generator(int n)
        {
            var multiple = TwoPi * LFOFreq / waveFormat.SampleRate;
            if (LFO_Vol == 0.0)
            {
                return 0.0;
            }     
            return LFO_Vol * Math.Sin(n * multiple);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int outIndex = offset;
            double multiple = TwoPi * Frequency / waveFormat.SampleRate;
            double sampleValue;
            double temp;
            double SubBass_Sample;
            SubOscillaorFrequency = Frequency / 2;
            for (int sampleCount = 0; sampleCount < count / waveFormat.Channels; sampleCount++)
            {       
                var deltaTime = multiple * SampleIndex;
                SubBass_Sample = Math.Sin(SampleIndex * (TwoPi * SubOscillaorFrequency / waveFormat.SampleRate) + LFO_Generator(SampleIndex)) * subBassGain;
                switch (Type)
                {
                    case "Sine":

                        if (EnableSubOsc)
                        {

                            sampleValue = Gain * Math.Sin(deltaTime + (Gain * SubBass_Sample) + LFO_Generator(SampleIndex)) ;
                        }
                        else
                        {
                            sampleValue = Gain * Math.Sin(deltaTime + LFO_Generator(SampleIndex));
                        }

                        SampleIndex++;
                        break;


                    case "Square":
                        if (EnableSubOsc)
                        {
                            temp = Math.Sin(deltaTime - (Gain * SubBass_Sample) + LFO_Generator(SampleIndex));
                        }
                        else
                        {
                            temp = Math.Sin(deltaTime + LFO_Generator(SampleIndex));
                        }                    
                        sampleValue = (temp > 0 ? Gain : -Gain);
                        SampleIndex++;
                        break;

                    case "Triangle":
                        if (EnableSubOsc)
                        {
                            sampleValue = Math.Asin(Math.Sin(deltaTime + (Gain * SubBass_Sample) + LFO_Generator(SampleIndex))) * (2.0 / Math.PI) * Gain;
                        }
                        else
                        {
                            sampleValue = Math.Asin(Math.Sin(deltaTime + LFO_Generator(SampleIndex))) * (2.0 / Math.PI) * Gain;
                        }

                        SampleIndex++;
                        break;

                    case "SawTooth":
                        multiple = TwoPi * ((Frequency/2)/2) / waveFormat.SampleRate;
                        deltaTime = multiple * SampleIndex;
                        if (EnableSubOsc)
                        {
                            sampleValue = (((deltaTime - (Gain * SubBass_Sample) + LFO_Generator(SampleIndex)) % 2) - 1) * Gain;
                        }
                        else
                        {
                            sampleValue = (((deltaTime + LFO_Generator(SampleIndex)) % 2) - 1) * Gain;
                        }

                        SampleIndex++;
                        break;

                    default:
                        sampleValue = 0.0;
                        break;
                }
                for (int i = 0; i < waveFormat.Channels; i++)
                {
                    if (Panning > 0)
                    {
                        if (i == 0) { buffer[outIndex++] = (float)sampleValue * (1 - Panning); } //Left Channel
                        else { buffer[outIndex++] = (float)sampleValue; } //Right Channel
                    }
                    else if (Panning <= 0)
                    {
                        if (i == 0) { buffer[outIndex++] = (float)sampleValue; } //Left Channel
                        else { buffer[outIndex++] = (float)sampleValue * (1 - (Panning * -1)); } //Right Channel
                    }
                }
            }
            return count;
        }

    }
}
