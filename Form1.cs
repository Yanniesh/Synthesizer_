using NAudio.Midi;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Synthesizer
{
    public partial class SynthesizerForm : Form
    {
        SynthGUI synthGUI = null;
        public int OctaveIndex;
        private MidiIn midiIn;
        Button focusBtn;
        SynthMixer synthMixer;
        public SynthesizerForm()
        {         
            InitializeComponent();
            synthMixer = new SynthMixer();
            EQcomboBox.SelectedIndex = 0;
            VoiceCB.SelectedIndex = 2;
            synthGUI = new SynthGUI(keysPanel);
            OctaveIndex = (int)OctaveKeysSelector.Value;
            Oscillator2GroupBox.Enabled = false;
            WaveTypeCB1.SelectedItem = "Sine";
            WaveTypeCB2.SelectedItem = "SawTooth";
            synthMixer.SetPlayer();
            MIDIKeyBoardsComboBox.SelectedIndex = 0;
            MidiDevicesUpdate();
            EQgroupBox.Enabled = false;
            foreach (var button in synthGUI.keyPanel.Controls.OfType<Button>())
            {
                button.MouseDown += KeyButtons_MouseDown;
                button.MouseUp += KeyButtons_MouseUp;
                focusBtn = button;
            }
        }
        private void MidiDevicesUpdate()
        {
            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
            {
                MIDIKeyBoardsComboBox.Items.Add(MidiIn.DeviceInfo(i).ProductName);
            }
        }
        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if(e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
            {
                NoteOnEvent temp = (NoteOnEvent)e.MidiEvent;
                var volume = temp.Velocity / 127.0f;
                if ((temp.NoteNumber - 24) > 0 && (temp.NoteNumber - 24) < 61)
                {
                    synthMixer.PlayNote(temp.NoteNumber - 24, synthGUI.keys.ListOfKeys.Find(x => x.Index == (temp.NoteNumber - 24)).frequency, volume);
                }
            }
            else if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
            {
                NoteEvent temp = (NoteEvent)e.MidiEvent;
                if (temp.NoteNumber - 24 > 0 && temp.NoteNumber - 24 < 61)
                {
                    synthMixer.StopNote(temp.NoteNumber - 24);
                }
            }
        }
        private void KeyButtons_MouseDown(object sender, EventArgs e)
        {

            Button temp = (Button)sender;
            Console.WriteLine(temp.Name);
            foreach (PianoKey item in synthGUI.keys.ListOfKeys)
            {
                    if (item.NoteName == temp.Name)
                    {
                        synthMixer.PlayNote(item.Index, item.frequency);
                        break;
                    };
            }
                         
        }
        private void KeyButtons_MouseUp(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            Console.WriteLine(temp.Name);
            foreach (PianoKey item in synthGUI.keys.ListOfKeys)
            {
                if (item.NoteName == temp.Name)
                {
                    synthMixer.StopNote(item.Index);
                    break;
                };
            }
        }
        private void KeyBoardPlay(Keys k)
        {         
            switch (k)
            {
                case Keys.Z:
                    synthMixer.PlayNote(1 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.S:
                    synthMixer.PlayNote(2 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.X:
                    synthMixer.PlayNote(3 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D:
                    synthMixer.PlayNote(4 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.C:
                    synthMixer.PlayNote(5 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "E" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.V:
                    synthMixer.PlayNote(6 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.G:
                    synthMixer.PlayNote(7 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.B:
                    synthMixer.PlayNote(8 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.H:
                    synthMixer.PlayNote(9 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.N:
                    synthMixer.PlayNote(10 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A" + (OctaveIndex +1)).frequency);
                    break;
                case Keys.J:
                    synthMixer.PlayNote(11 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.M:
                    synthMixer.PlayNote(12 + OctaveIndex * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "B" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.Q:
                    synthMixer.PlayNote(1 + (OctaveIndex + 1)* 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.D2:
                    synthMixer.PlayNote(2 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C#" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.W:
                    synthMixer.PlayNote(3 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.D3:
                    synthMixer.PlayNote(4 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D#" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.E:
                    synthMixer.PlayNote(5 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "E" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.R:
                    synthMixer.PlayNote(6 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.D5:
                    synthMixer.PlayNote(7 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F#" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.T:
                    synthMixer.PlayNote(8 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.D6:
                    synthMixer.PlayNote(9 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G#" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.Y:
                    synthMixer.PlayNote(10 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.D7:
                    synthMixer.PlayNote(11 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A#" + (OctaveIndex + 2)).frequency);
                    break;
                case Keys.U:
                    synthMixer.PlayNote(12 + (OctaveIndex + 1) * 12, synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "B" + (OctaveIndex + 2)).frequency);
                    break;
            }
        }
        private void KeyBoardStop(Keys k)
        {

            switch (k)
            {
                case Keys.Z:
                    synthMixer.StopNote(1 + OctaveIndex * 12);
                    break;
                case Keys.S:
                    synthMixer.StopNote(2 + OctaveIndex * 12);
                    break;
                case Keys.X:
                    synthMixer.StopNote(3 + OctaveIndex * 12);
                    break;
                case Keys.D:
                    synthMixer.StopNote(4 + OctaveIndex * 12);
                    break;
                case Keys.C:
                    synthMixer.StopNote(5 + OctaveIndex * 12);
                    break;
                case Keys.V:
                    synthMixer.StopNote(6 + OctaveIndex * 12);
                    break;
                case Keys.G:
                    synthMixer.StopNote(7 + OctaveIndex * 12);
                    break;
                case Keys.B:
                    synthMixer.StopNote(8 + OctaveIndex * 12);
                    break;
                case Keys.H:
                    synthMixer.StopNote(9 + OctaveIndex * 12);
                    break;
                case Keys.N:
                    synthMixer.StopNote(10 + OctaveIndex * 12);
                    break;
                case Keys.J:
                    synthMixer.StopNote(11 + OctaveIndex * 12);
                    break;
                case Keys.M:
                    synthMixer.StopNote(12 + OctaveIndex * 12);
                    break;
                case Keys.Q:
                    synthMixer.StopNote(1 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.D2:
                    synthMixer.StopNote(2 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.W:
                    synthMixer.StopNote(3 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.D3:
                    synthMixer.StopNote(4 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.E:
                    synthMixer.StopNote(5 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.R:
                    synthMixer.StopNote(6 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.D5:
                    synthMixer.StopNote(7 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.T:
                    synthMixer.StopNote(8 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.D6:
                    synthMixer.StopNote(9 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.Y:
                    synthMixer.StopNote(10 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.D7:
                    synthMixer.StopNote(11 + (OctaveIndex + 1) * 12);
                    break;
                case Keys.U:
                    synthMixer.StopNote(12 + (OctaveIndex + 1) * 12);
                    break;
            }
        }
        private void SynthesizerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyboardInput.Checked && MIDIKeyBoardsComboBox.SelectedIndex == 0)
            {
                KeyBoardPlay(e.KeyCode);
            }          
        }

        private void SynthesizerForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (KeyboardInput.Checked && MIDIKeyBoardsComboBox.SelectedIndex == 0)
            {
                KeyBoardStop(e.KeyCode);
            }
        }


        private void WaveTypeCB_SelectedValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetWaveType(WaveTypeCB1.SelectedItem.ToString());
        }

        private void OctaveKeysSelector_ValueChanged(object sender, EventArgs e)
        {
            OctaveIndex = (int)OctaveKeysSelector.Value;
        }

        private void OctaveKeysSelector_Enter(object sender, EventArgs e)
        {
                focusBtn.Focus();
        }

        private void VolumeBar_ValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetVolume(VolumeBar1.Value / 100.0f);
        }
        private void VolumeBar2_ValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetVolume2(VolumeBar2.Value / 100.0f);
        }
        private void WaveTypeCB2_SelectedValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetWaveType2(WaveTypeCB2.SelectedItem.ToString());
        }
        private void Osc2TurnCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (Osc2TurnCheck.Checked)
            {
                synthMixer.Oscilllator2TurnON = true;
                Oscillator2GroupBox.Enabled = true;
            }
            else
            {
                synthMixer.Oscilllator2TurnON = false;
                Oscillator2GroupBox.Enabled = false;
            }
        }

        private void MasterVolumeBar_ValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetMasterVolume(MasterVolumeBar.Value / 100.0f);
        }

        private void knobControl1_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetAttack1((float)temp.Value/5);
        }

        private void knobControl2_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDecay1((float)temp.Value / 5);
        }

        private void knobControl3_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetSustain((float)temp.Value / 100);
        }

        private void knobControl4_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetRelease((float)temp.Value/5);
        }

        private void SubBassChBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            synthMixer.TurnSubBass(temp.Checked);
        }
        private void SubBass1trackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.subBassGain = (float)temp.Value / 100;
        }
        private void LFOChBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            synthMixer.setLFO(temp.Checked);
        }
        private void LFOFreqTrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.setLFOFreq((float)temp.Value);
        }

        private void LFOGain1trackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.setLFOGain((float)temp.Value/200);
        }

        private void SubBass2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            synthMixer.TurnSubBass2(temp.Checked);
        }

        private void SubBass2trackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.subBassGain2 = (float)temp.Value / 100;
        }

        private void LFO2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            synthMixer.setLFO2(temp.Checked);
        }

        private void LFOFreq2TrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.setLFOFreq2((float)temp.Value);
        }

        private void LFOGain2TrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.setLFOGain2((float)temp.Value / 200);
        }

        private void EQcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetEQType(EQcomboBox.SelectedItem.ToString());
            if (EQcomboBox.SelectedItem.ToString() == "Low-Pass" || EQcomboBox.SelectedItem.ToString() == "High-Pass")
            {
                EQdBtrackBar.Enabled = false;
                dbLabel.Enabled = false;
            }
            else
            {
                EQdBtrackBar.Enabled = true;
                dbLabel.Enabled = true;
            }

        }

        private void VoiceCB_SelectedValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetVoice(VoiceCB.SelectedItem.ToString());
        }

        private void knobControl8_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetAttack2((float)temp.Value / 5);
        }

        private void knobControl7_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDecay2((float)temp.Value / 5);
        }

        private void knobControl6_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetSustain2((float)temp.Value / 100);
        }

        private void knobControl5_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetRelease2((float)temp.Value / 5);
        }

        private void EQ_FreqNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown temp = (NumericUpDown)sender;
            synthMixer.setEQFrequency((int)temp.Value);
        }

        private void EQ_Q_TrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.setEQ_Q((float)temp.Value / 100);
        }

        private void EQdBtrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar temp = (TrackBar)sender;
            synthMixer.setEQGain((float)temp.Value / 100);
        }

        private void EQcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            synthMixer.EnableEQ(temp.Checked);
            if (temp.Checked)
            {
                EQgroupBox.Enabled = true;
            }
            else
            {
                EQgroupBox.Enabled = false;
            }
        }

        private void PanningtrackBar_ValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetPanning(PanningtrackBar.Pan);
        }

        private void Panning2trackBar_ValueChanged(object sender, EventArgs e)
        {
            synthMixer.SetPanning2(Panning2trackBar.Pan);
        }

        private void DelayMixknobControl_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDelayMix((float)temp.Value / 100);
        }

        private void DelayDryknobControl_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDelayDry((float)temp.Value / 100);
        }

        private void DelayFeedbackknobControl_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDelayFeedback((float)temp.Value / 100);
        }

        private void DelayWetknobControl_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDelayWet((float)temp.Value / 100);
        }

        private void DelayLengthknobControl_ValueChanged(object Sender)
        {
            KnobControl temp = (KnobControl)Sender;
            synthMixer.SetDelayLength((float)temp.Value/100);
        }

        private void MIDIKeyBoardsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(MIDIKeyBoardsComboBox.SelectedIndex != 0)
            {
                KeyboardInput.Checked = false;
                KeyboardInput.Enabled = false;
                midiIn = new MidiIn(MIDIKeyBoardsComboBox.SelectedIndex-1);
                midiIn.MessageReceived += midiIn_MessageReceived;
                midiIn.Start();
            }
            else
            {
                KeyboardInput.Checked = true;
                KeyboardInput.Enabled = true;
                if (midiIn != null)
                {
                    midiIn.Stop();
                    midiIn.Dispose();
                }

            }

        }

    }
}
