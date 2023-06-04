using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace Synthesizer
{
    class SynthMixer
    {
        private float masterVolume = 0.4f;
        //OSC
        public bool Oscilllator2TurnON = false;
        public String Voice = "0";
        private String WaveType1;
        private String WaveType2;
        private float Volume1 = 0.4f;
        private float Volume2 = 0.4f;
        //ADSR
        private float Attack = 1;
        private float Attack2 = 1;
        private float Decay = 1;
        private float Decay2 = 1;
        private float Sustain = 0.5f;
        private float Sustain2  = 0.5f;
        private float Release = 1;
        private float Release2 = 1;
        //LFO
        private bool EnableLFO = false;
        private bool EnableLFO2 = false;    
        private float lfoGain = 0.0f;
        private float lfoFreq = 5;
        private float lfoGain2 = 0.1f;
        private float lfoFreq2 = 5;
        //SubbBass
        private bool SubBass = false;
        private bool SubBass2 = false;
        public float subBassGain = 0.0f;
        public float subBassGain2 = 0.0f;
        //EQ
        private int EQ_Frequency = 20000;
        private float EQ_q = 0.5f;
        private float EQ_Gain = 0.5f;
        private bool EQ_Enabled = false;      
        private Equalizer.EQType EQ_Type = Equalizer.EQType.HighShelf;
        //Panning
        private float panning = 0.0f;
        private float panning2 = 0.0f;
        //Delay
        private float Mix = 0.0f;
        private float Dry = 1.0f;
        private float Feedback = 0.0f;
        private float Length = 0.0f;
        private float Wet = 0.0f;    
        private MixingSampleProvider _mixer;
        private Delay _delay;
        private Equalizer _EQ;
        private Oscillator[,] oscillatorsArray = new Oscillator[2, 61];
        private IWavePlayer _player;
        public SynthMixer()
        {
            Make();
        }
        public void Make()
        {
            var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 2);
            _mixer = new MixingSampleProvider(waveFormat);
            _mixer.ReadFully = true;
            _delay = new Delay(_mixer);
            SetDelay();
        }
        public void SetMasterVolume(float _masterVolume)
        {
            masterVolume = _masterVolume;
        }
        public void PlayNote(int IndexOfNote, float NoteFrequency, float velocity = 1.0f)
        {
            if (oscillatorsArray[0, IndexOfNote] is null)
            {
                oscillatorsArray[0, IndexOfNote] = new Oscillator(WaveType1, Volume1 * masterVolume * velocity, NoteFrequency, _mixer.WaveFormat.SampleRate)
                {
                    NoteFrequency = NoteFrequency,
                    AttackSeconds = Attack,
                    DecaySeconds = Decay,
                    SustainLevel = Sustain,
                    ReleaseSeconds = Release,
                    LFOFrequency = lfoFreq,
                    LFOGain = EnableLFO ? lfoGain : 0.0,
                    EnableSubOsc = SubBass,
                    SubBassGain = subBassGain,
                    Panning = panning
                };
                _mixer.AddMixerInput(oscillatorsArray[0, IndexOfNote]);
                if (Oscilllator2TurnON)
                {
                    oscillatorsArray[1, IndexOfNote] = new Oscillator(WaveType2, Volume2 * masterVolume * velocity, NoteFrequency, _mixer.WaveFormat.SampleRate)
                    {
                        NoteFrequency = setVoicing(NoteFrequency),
                        AttackSeconds = Attack2,
                        DecaySeconds = Decay2,
                        SustainLevel = Sustain2,
                        ReleaseSeconds = Release2,
                        LFOFrequency = lfoFreq2,
                        LFOGain = EnableLFO2 ? lfoGain2 : 0.0,
                        EnableSubOsc = SubBass2,
                        SubBassGain = subBassGain2,
                        Panning = panning2
                    };
                    _mixer.AddMixerInput(oscillatorsArray[1, IndexOfNote]);     
                }           
            }
        }

        public void StopNote(int keyValue)
        {
            if (oscillatorsArray[0, keyValue] != null)
            {
                oscillatorsArray[0, keyValue].Stop();
                oscillatorsArray[0, keyValue] = null;
            }
            if (oscillatorsArray[1, keyValue] != null)
            {
                oscillatorsArray[1, keyValue].Stop();
                oscillatorsArray[1, keyValue] = null;
            }
                
                
        }

        public void SetPlayer()
        {
            if (_player == null)
            {
                var waveOutEvent = new WaveOutEvent
                {
                    NumberOfBuffers = 2,
                    DesiredLatency = 100,
                };
                _player = waveOutEvent;
                if (EQ_Enabled)
                {
                    _EQ = new Equalizer(_mixer, EQ_Frequency, EQ_q, EQ_Gain, EQ_Type);
                    _delay = new Delay(_EQ);
                    SetDelay();
                    _player.Init(new SampleToWaveProvider(_delay));
                }
                else
                {
                    _player.Init(new SampleToWaveProvider(_delay));
                }               
                _player.Play();
            }
        }

        public void Reset_Player()
        {
            if (_player != null)
            {
                _player.Dispose();
                _player = null;
                SetPlayer();
            }
        }
        public void SetVolume(float vol)
        {
            Volume1 = vol;
        }
        public void SetVolume2(float vol)
        {
            Volume2 = vol;
        }
        public void SetWaveType(String _waveType)
        {
            WaveType1 = _waveType;
        }
        public void SetWaveType2(String _waveType)
        {
            WaveType2 = _waveType;
        }
        public void SetAttack1(float _attack)
        {
            Attack = _attack;
        }
        public void SetAttack2(float _attack)
        {
            Attack2 = _attack;
        }
        public void SetDecay1(float _decay)
        {
            Decay = _decay;
        }
        public void SetDecay2(float _decay)
        {
            Decay2 = _decay;
        }
        public void SetSustain(float _sustain)
        {
            Sustain = _sustain;
        }
        public void SetSustain2(float _sustain)
        {
            Sustain2 = _sustain;
        }
        public void SetRelease(float _release)
        {
            Release = _release;
        }
        public void SetRelease2(float _release)
        {
            Release2 = _release;
        }
        public void TurnSubBass(bool _subBass)
        {
            SubBass = _subBass;
        }
        public void TurnSubBass2(bool _subBass)
        {
            SubBass2 = _subBass;
        }
        public void setLFOGain(float val)
        {
            lfoGain = val;
        }
        public void setLFOFreq(float val)
        {
            lfoFreq = val;
        }
        public void setLFOGain2(float val)
        {
            lfoGain2 = val;
        }
        public void setLFOFreq2(float val)
        {
            lfoFreq2 = val;
        }
        public void setLFO(bool val)
        {
            EnableLFO = val;
        }
        public void setLFO2(bool val)
        {
            EnableLFO2 = val;
        }
        
        public void SetEQType(String val)
        {
            switch (val)
            {
                case "Low-Shelf": EQ_Type = Equalizer.EQType.LowShelf;  break;
                case "High-Shelf": EQ_Type = Equalizer.EQType.HighShelf; break;
                case "Low-Pass": EQ_Type = Equalizer.EQType.LowPass; break;
                case "High-Pass": EQ_Type = Equalizer.EQType.HighPass; break;
                case "Peaking": EQ_Type = Equalizer.EQType.Peaking; break;
                default: break;
            }
            Reset_Player();
        }
        public void SetVoice(String val)
        {
            Voice = val;
        }
        public float setVoicing(float freq)
        {
            switch (Voice){
                case "2": return freq * 4;
                case "1": return freq * 2;  
                case "0": return freq; 
                case "-1": return freq/2; 
                case "-2": return freq/4; 
                default: return freq;
            }
            
        }
        public void setEQGain(float gain)
        {
            EQ_Gain = gain;
            Reset_Player();
        }
        public void setEQFrequency(int freq)
        {
            EQ_Frequency = freq;
            Reset_Player();
        }
        public void setEQ_Q(float q)
        {
            EQ_q = q;
            Reset_Player();
        }

        public void EnableEQ(bool enable)
        {
            EQ_Enabled = enable;
            Reset_Player();
        }
        public void SetPanning(float pan)
        {
            panning = pan;
        }
        public void SetPanning2(float pan)
        {
            panning2 = pan;
        }
        public void SetDelayMix(float val)
        {
            Mix = val;
            SetDelay();
        }
        public void SetDelayDry(float val)
        {
            Dry = val;
            SetDelay();
        }
        public void SetDelayWet(float val)
        {
            Wet = val;
            SetDelay();
        }
        public void SetDelayFeedback(float val)
        {
            Feedback = val;
            SetDelay();
        }
        public void SetDelayLength(float val)
        {
            Length = val;
            SetDelay();
        }
        private void SetDelay()
        {
            _delay.Length = Length * 2000;
            _delay.Mix = Mix;
            _delay.Feedback = Feedback;
            _delay.WetGain = Wet;
            _delay.DryGain = Dry;
        }
    }
}
