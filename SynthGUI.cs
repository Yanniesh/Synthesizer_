using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer
{
    public class SynthGUI
    {
        public Panel keyPanel;
        public PianoKeys keys = new PianoKeys();
        public SynthGUI(Panel _keyPanel)
        {
            keyPanel = _keyPanel;
            createKeys();
            pushKeysUP();
        }
        void createKeys()
        {
                Button btn = new Button();
                Button prevBtn = btn;
                for (int i = 0; i < 60; i++)
                {
                    btn = new Button();
                    btn.Name = keys.KeysLettersArray[i];
                    int X;
                    if (i == 0)
                    {
                        btn.Width = 34;
                        btn.Height = 140;
                        btn.BackColor = Color.White;
                        X = 20;
                        btn.Location = new Point(X, btn.Location.Y + 20);
                        prevBtn = btn;
                        keyPanel.Controls.Add(btn);
                        continue;
                    }
                    if (keys.KeysLettersArray[i].Contains("#"))
                    {
                        btn.Width = 34;
                        btn.Height = 95;
                        X = prevBtn.Location.X + btn.Width / 2;
                        btn.BackColor = Color.Black;                 
                    }
                    else
                    {
                        btn.Width = 34;
                        btn.Height = 140;
                        if(keys.KeysLettersArray[i].Contains("F") || keys.KeysLettersArray[i].Contains("C"))
                        {
                            X = prevBtn.Location.X + btn.Width;
                        }
                        else
                        {
                            X = prevBtn.Location.X + btn.Width / 2;
                        }
                        btn.BackColor = Color.White;
                    }
                    prevBtn = btn;
                    btn.Location = new Point(X, btn.Location.Y+20);
                    keyPanel.Controls.Add(btn);
                }
        }
        void pushKeysUP()
        {
            foreach(Button tempButton in keyPanel.Controls)
            {
                if (tempButton.Name.Contains("#"))
                {
                    tempButton.BringToFront();                  
                }
            }
        }
    }
}
