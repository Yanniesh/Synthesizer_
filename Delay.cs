using NAudio.Wave;
using System;

namespace Synthesizer
{
    public class Delay : ISampleProvider
    {
        private readonly ISampleProvider _source;
        private float DelayTimeIndex = 0.0f;
        private float delayLengthIdx;
        private float ProcessedDelay;
        private float resamplePos;
        private int resamplePosIntPart;
        private float DelayReSamplePos;
        private int position;
        private float[] DelayBuffer = new float[600000];

        public WaveFormat WaveFormat => _source.WaveFormat;
        private bool resample;
        public bool Switch
        {
            get => resample;
            set
            {
                resample = value;
                SetSlide();
            }
        }
        private double delay;
        public double Length
        {
            get => delay;
            set
            {
                delay = value;
                DelayTimeIndex = 0;
                SetSlide();
            }
        }
        private float feedback;
        public float Feedback
        {
            get => feedback;
            set
            {
                feedback = value;
                SetSlide();
            }
        }
        private float mix;
        public float Mix
        {
            get => mix;
            set
            {
                mix = value;
                SetSlide();
            }
        }
        private float wet;
        public float WetGain
        {
            get => wet;
            set
            {
                wet = value;
                SetSlide();
            }
        }
        private float dry;
        public float DryGain
        {
            get => dry;
            set
            {
                dry = value;
                SetSlide();
            }
        }
        public Delay(ISampleProvider source)
        {           
            _source = source;
            Switch = true;
            DelayTimeIndex = 0;         
            SetSlide();
        }
        public int Read(float[] buffer, int offset, int count)
        {
            var read = _source.Read(buffer, offset, count);
            for (var i = 0; i < read; i++)
            {
                buffer[offset + i] = Process(buffer[offset + i]);
            }
            return read;
        }

        private float Process(float input)
        {
            var DelayTimeIndexTemp = (int)DelayTimeIndex;
            var output = DelayBuffer[DelayTimeIndexTemp];
            DelayBuffer[DelayTimeIndexTemp + 0] = Math.Min(Math.Max((input * Mix) + (output * Feedback), -4), 4);
            if ((DelayTimeIndex += 1) >= delayLengthIdx)
            {
                DelayTimeIndex = 0;
            }
            return (input * DryGain) + (output * WetGain);
        }
        private void SetSlide()
        {
            ProcessedDelay = delayLengthIdx;
            delayLengthIdx = (float)Math.Min((Length * WaveFormat.SampleRate) / 1000, DelayBuffer.Length);

            if (ProcessedDelay != delayLengthIdx)
            {
                if (Switch && (ProcessedDelay > delayLengthIdx))
                {
                    resamplePos = 0;
                    resamplePosIntPart = 0;
                    DelayReSamplePos = ProcessedDelay / delayLengthIdx;

                    for (var i = 0; i < delayLengthIdx; i++)
                    {
                        position = ((int)resamplePos) * 2;
                        DelayBuffer[resamplePosIntPart] = DelayBuffer[position];
                        DelayBuffer[resamplePosIntPart + 1] = DelayBuffer[position + 1];
                        resamplePosIntPart += 2;
                        resamplePos += DelayReSamplePos;
                    }

                    DelayTimeIndex = DelayReSamplePos != 0.0f
                        ? DelayTimeIndex / DelayReSamplePos
                        : DelayTimeIndex;
                    DelayTimeIndex = (DelayTimeIndex < 0) ? 0 : (int)DelayTimeIndex;
                }
                else
                {
                    if (Switch && (ProcessedDelay < delayLengthIdx))
                    {
                        DelayReSamplePos = ProcessedDelay / delayLengthIdx;
                        resamplePos = ProcessedDelay;
                        resamplePosIntPart = ((int)delayLengthIdx) * 2;

                        for (var i = 0; i < (int)delayLengthIdx; i++)
                        {
                            resamplePos -= DelayReSamplePos;
                            resamplePosIntPart -= 2;

                            position = Math.Abs(((int)resamplePos) * 2);
                            DelayBuffer[resamplePosIntPart] = DelayBuffer[position];
                            DelayBuffer[resamplePosIntPart + 1] = DelayBuffer[position + 1];
                        }
                        DelayTimeIndex = DelayReSamplePos != 0.0f
                            ? DelayTimeIndex / DelayReSamplePos
                            : DelayTimeIndex;
                        DelayTimeIndex = (DelayTimeIndex < 0) ? 0 : (int)DelayTimeIndex;
                    }
                    else
                    {
                        if (Switch && (DelayTimeIndex >= delayLengthIdx))
                        {
                            DelayTimeIndex = 0;
                        }
                    }
                }
            }
        }
    }
}
