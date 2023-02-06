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
        private HashSet<Keys> _keys = new HashSet<Keys>();
        public SynthesizerForm()
        {
            InitializeComponent();
            WaveTypeCB.SelectedItem = "Sine";
            synthGUI = new SynthGUI(keysPanel);
            foreach (var button in synthGUI.keyPanel.Controls.OfType<Button>())
            {
                button.MouseDown += KeyButtons_MouseDown;
                button.MouseUp += KeyButtons_MouseUp;
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
        private void KeyBoardPlay(Keys k) {
           
            switch (k)
            {
                case Keys.Z:
                        synthesizer.PlayNote((synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C1")).frequency);
                    break;
                case Keys.X:
                    synthesizer.PlayNote((synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D1")).frequency);
                    break;
            }
        }
        private void KeyBoardStop(Keys k)
        {
            switch (k)
            {
                case Keys.Z:
                    synthesizer.StopNote((synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "C1")).frequency);
                    break;
                case Keys.X:
                    synthesizer.StopNote((synthGUI.keys.ListOfKeys.Find(x => x.NoteName == "D1")).frequency);
                    break;
            }
        }
        private void SynthesizerForm_KeyDown(object sender, KeyEventArgs e)
        {
/*            if (!_keys.Contains(e.KeyCode))
            {
                _keys.Add(e.KeyCode);
                KeyBoardPlay(e.KeyCode);
            }*/
            KeyBoardPlay(e.KeyCode);
            Console.WriteLine(e.KeyCode);
          
        }

        private void SynthesizerForm_KeyUp(object sender, KeyEventArgs e)
        {
            _keys.Remove(e.KeyCode);
            KeyBoardStop(e.KeyCode);
        }
        private void VolumeBar_ValueChanged(object sender, EventArgs e)
        {
            synthesizer.SetVolume(VolumeBar.Value/10);
        }

        private void WaveTypeCB_TextChanged(object sender, EventArgs e)
        {
            synthesizer.SetWaveType(WaveTypeCB.SelectedItem.ToString());
        }

    }
}
