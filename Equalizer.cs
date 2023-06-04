using NAudio.Dsp;
using NAudio.Wave;


namespace Synthesizer
{
    class Equalizer: ISampleProvider
    {
        public WaveFormat WaveFormat => _source.WaveFormat;
        private readonly ISampleProvider _source;
        private readonly BiQuadFilter EQFiltr;

        public enum EQType
        {
            LowShelf,
            HighShelf,
            LowPass,
            HighPass,
            Peaking
        }
        public Equalizer(ISampleProvider source, int Freq, float q,float dbGain, EQType type)
        {
            _source = source;
            switch (type)
            {
                case (EQType.HighPass): EQFiltr = BiQuadFilter.HighPassFilter(source.WaveFormat.SampleRate, Freq, q); break;
                case (EQType.LowPass): EQFiltr = BiQuadFilter.LowPassFilter(source.WaveFormat.SampleRate, Freq, q); break;
                case (EQType.HighShelf): EQFiltr = BiQuadFilter.HighShelf(source.WaveFormat.SampleRate, Freq, q, dbGain); break;
                case (EQType.LowShelf): EQFiltr = BiQuadFilter.LowShelf(source.WaveFormat.SampleRate, Freq, q, dbGain); break;
                case (EQType.Peaking): EQFiltr = BiQuadFilter.PeakingEQ(source.WaveFormat.SampleRate, Freq, q, dbGain); break;
                default: break;
            }
            
        }
        public int Read(float[] buffer, int offset, int count)
        {
            var samples = _source.Read(buffer, offset, count);

            for (int i = 0; i < samples; i++)
            {
                buffer[offset + i] = EQFiltr.Transform(buffer[offset + i]);
            }

            return samples;
        }
    }
}
