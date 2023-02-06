using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synthesizer
{
    public partial class SynthesizerForm : Form
    {
        public Synthesizer synthesizer = new Synthesizer();
        SynthGUI synthGUI = null;
        public int OctaveIndex;
        Button focusBtn;
        public SynthesizerForm()
        {         
            InitializeComponent();
            WaveTypeCB1.SelectedItem = "Sine";
            WaveTypeCB2.SelectedItem = "SawTooth";
            synthGUI = new SynthGUI(keysPanel);
            OctaveIndex = (int)OctaveKeysSelector.Value;
            Oscillator2GroupBox.Enabled = false;


            foreach (var button in synthGUI.keyPanel.Controls.OfType<Button>())
            {
                button.MouseDown += KeyButtons_MouseDown;
                button.MouseUp += KeyButtons_MouseUp;
                focusBtn = button;
            }
        }

        private void KeyButtons_MouseDown(object sender, EventArgs e)
        {
            foreach (Button key in synthGUI.keyPanel.Controls)
            {
                if (sender.Equals(key))
                {
                    Console.WriteLine(key.Name);
                    foreach (PianoKey item in synthGUI.keys.ListOfKeys)
                    {
                        if (item.NoteName == key.Name)
                        {
                            synthesizer.PlayNote(item.frequency);
                        };
                    }
                    
                }
            }
        }
        private void KeyButtons_MouseUp(object sender, EventArgs e)
        {
            foreach (Button key in synthGUI.keyPanel.Controls)
            {
                if (sender.Equals(key))
                {
                    Console.WriteLine(key.Name);
                    foreach (PianoKey item in synthGUI.keys.ListOfKeys)
                    {
                        if (item.NoteName == key.Name)
                        {
                            synthesizer.StopNote(item.frequency);
                        };
                    }

                }
            }
        }
        private void KeyBoardPlay(Keys k)
        {         
            switch (k)
            {
                case Keys.Z:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C" + OctaveIndex).frequency);
                    break;
                case Keys.X:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D" + OctaveIndex).frequency);
                    break;
                case Keys.C:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "E" + OctaveIndex).frequency);
                    break;
                case Keys.V:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F" + OctaveIndex).frequency);
                    break;
                case Keys.B:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G" + OctaveIndex).frequency);
                    break;
                case Keys.N:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A" + OctaveIndex).frequency);
                    break;
                case Keys.M:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "B" + OctaveIndex).frequency);
                    break;
                case Keys.S:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C#" + OctaveIndex).frequency);
                    break;
                case Keys.D:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D#" + OctaveIndex).frequency);
                    break;
                case Keys.G:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F#" + OctaveIndex).frequency);
                    break;
                case Keys.H:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G#" + OctaveIndex).frequency);
                    break;
                case Keys.J:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A#" + OctaveIndex).frequency);
                    break;
                case Keys.Q:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.W:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.E:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "E" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.R:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.T:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.Y:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.U:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "B" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D2:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D3:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D5:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D6:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D7:
                    synthesizer.PlayNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A#" + (OctaveIndex + 1)).frequency);
                    break;
            }
            foreach(var temp in synthesizer.oscillatorsList.FindAll(x=> x.isPlaying == true)){

                Button btnTemp = (Button)synthGUI.keyPanel.Controls.Find(synthGUI.keys.ListOfKeys.Find(x => x.frequency == temp._oscillator.Frequency).NoteName, true)[0];
                btnTemp.Focus();

            }
        }
        private void KeyBoardStop(Keys k)
        {
            
            switch (k)
            {
                case Keys.Z:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C" + OctaveIndex).frequency);
                    break;
                case Keys.X:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D" + OctaveIndex).frequency);
                    break;
                case Keys.C:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "E" + OctaveIndex).frequency);
                    break;
                case Keys.V:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F" + OctaveIndex).frequency);
                    break;
                case Keys.B:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G" + OctaveIndex).frequency);
                    break;
                case Keys.N:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A" + OctaveIndex).frequency);
                    break;
                case Keys.M:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "B" + OctaveIndex).frequency);
                    break;
                case Keys.S:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C#" + OctaveIndex).frequency);
                    break;
                case Keys.D:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D#" + OctaveIndex).frequency);
                    break;
                case Keys.G:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F#" + OctaveIndex).frequency);
                    break;
                case Keys.H:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G#" + OctaveIndex).frequency);
                    break;
                case Keys.J:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A#" + OctaveIndex).frequency);
                    break;
                case Keys.Q:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C" + (OctaveIndex +1)).frequency);
                    break;
                case Keys.W:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.E:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "E" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.R:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.T:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.Y:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.U:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "B" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D2:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D3:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D5:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "F#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D6:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "G#" + (OctaveIndex + 1)).frequency);
                    break;
                case Keys.D7:
                    synthesizer.StopNote(synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "A#" + (OctaveIndex + 1)).frequency);
                    break;
            }
        }
        private void SynthesizerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(KeyboardInput.Checked)
            {
                KeyBoardPlay(e.KeyCode);
            }                             
        }

        private void SynthesizerForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (KeyboardInput.Checked)
            {
                KeyBoardStop(e.KeyCode);
            }           
        }
        private void VolumeBar_ValueChanged(object sender, EventArgs e)
        {
            synthesizer.SetVolume(VolumeBar1.Value/100.0);
        }

        private void WaveTypeCB_SelectedValueChanged(object sender, EventArgs e)
        {
            synthesizer.SetWaveType(WaveTypeCB1.SelectedItem.ToString());
        }

        private void OctaveKeysSelector_ValueChanged(object sender, EventArgs e)
        {
            OctaveIndex = (int)OctaveKeysSelector.Value;
        }

        private void OctaveKeysSelector_Enter(object sender, EventArgs e)
        {
                focusBtn.Focus();
        }

        private void VolumeBar2_ValueChanged(object sender, EventArgs e)
        {
            synthesizer.SetVolume2(VolumeBar2.Value / 100.0);
        }
        private void WaveTypeCB2_SelectedValueChanged(object sender, EventArgs e)
        {
            synthesizer.SetWaveType2(WaveTypeCB2.SelectedItem.ToString());
        }
        private void Osc2TurnCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (Osc2TurnCheck.Checked)
            {
                synthesizer.Oscilllator2TurnON = true;
                Oscillator2GroupBox.Enabled = true;
            }
            else
            {
                synthesizer.Oscilllator2TurnON = false;
                Oscillator2GroupBox.Enabled = false;
            }
        }


    }
}
