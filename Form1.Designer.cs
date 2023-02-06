
namespace Synthesizer
{
    partial class SynthesizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynthesizerForm));
            this.keysPanel = new System.Windows.Forms.Panel();
            this.WaveTypeCB1 = new System.Windows.Forms.ComboBox();
            this.VolumeBar1 = new System.Windows.Forms.TrackBar();
            this.WaveTypeLabel = new System.Windows.Forms.Label();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.OctaveKeysSelector = new System.Windows.Forms.NumericUpDown();
            this.OctaveKeysLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VolumeBar2 = new System.Windows.Forms.TrackBar();
            this.WaveTypeCB2 = new System.Windows.Forms.ComboBox();
            this.Oscillator2GroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Osc2TurnCheck = new System.Windows.Forms.CheckBox();
            this.KeyboardInput = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OctaveKeysSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar2)).BeginInit();
            this.Oscillator2GroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // keysPanel
            // 
            this.keysPanel.Location = new System.Drawing.Point(1, 455);
            this.keysPanel.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.keysPanel.Name = "keysPanel";
            this.keysPanel.Size = new System.Drawing.Size(1029, 144);
            this.keysPanel.TabIndex = 2;
            // 
            // WaveTypeCB1
            // 
            this.WaveTypeCB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaveTypeCB1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WaveTypeCB1.FormattingEnabled = true;
            this.WaveTypeCB1.Items.AddRange(new object[] {
            "Sine",
            "SawTooth",
            "Square",
            "Triangle"});
            this.WaveTypeCB1.Location = new System.Drawing.Point(173, 55);
            this.WaveTypeCB1.MaxDropDownItems = 4;
            this.WaveTypeCB1.Name = "WaveTypeCB1";
            this.WaveTypeCB1.Size = new System.Drawing.Size(121, 24);
            this.WaveTypeCB1.TabIndex = 3;
            this.WaveTypeCB1.SelectedValueChanged += new System.EventHandler(this.WaveTypeCB_SelectedValueChanged);
            // 
            // VolumeBar1
            // 
            this.VolumeBar1.Location = new System.Drawing.Point(156, 116);
            this.VolumeBar1.Maximum = 100;
            this.VolumeBar1.Name = "VolumeBar1";
            this.VolumeBar1.Size = new System.Drawing.Size(157, 45);
            this.VolumeBar1.TabIndex = 4;
            this.VolumeBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar1.Value = 40;
            this.VolumeBar1.ValueChanged += new System.EventHandler(this.VolumeBar_ValueChanged);
            // 
            // WaveTypeLabel
            // 
            this.WaveTypeLabel.AutoSize = true;
            this.WaveTypeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.WaveTypeLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.WaveTypeLabel.Location = new System.Drawing.Point(19, 56);
            this.WaveTypeLabel.Name = "WaveTypeLabel";
            this.WaveTypeLabel.Size = new System.Drawing.Size(128, 23);
            this.WaveTypeLabel.TabIndex = 5;
            this.WaveTypeLabel.Text = "WaveType:";
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.VolumeLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.VolumeLabel.Location = new System.Drawing.Point(28, 116);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(100, 23);
            this.VolumeLabel.TabIndex = 6;
            this.VolumeLabel.Text = "Volume:";
            // 
            // OctaveKeysSelector
            // 
            this.OctaveKeysSelector.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.OctaveKeysSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OctaveKeysSelector.InterceptArrowKeys = false;
            this.OctaveKeysSelector.Location = new System.Drawing.Point(990, 430);
            this.OctaveKeysSelector.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.OctaveKeysSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OctaveKeysSelector.Name = "OctaveKeysSelector";
            this.OctaveKeysSelector.ReadOnly = true;
            this.OctaveKeysSelector.Size = new System.Drawing.Size(35, 23);
            this.OctaveKeysSelector.TabIndex = 7;
            this.OctaveKeysSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OctaveKeysSelector.ValueChanged += new System.EventHandler(this.OctaveKeysSelector_ValueChanged);
            this.OctaveKeysSelector.Enter += new System.EventHandler(this.OctaveKeysSelector_Enter);
            // 
            // OctaveKeysLabel
            // 
            this.OctaveKeysLabel.AutoSize = true;
            this.OctaveKeysLabel.Font = new System.Drawing.Font("Verdana", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OctaveKeysLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.OctaveKeysLabel.Location = new System.Drawing.Point(952, 409);
            this.OctaveKeysLabel.Name = "OctaveKeysLabel";
            this.OctaveKeysLabel.Size = new System.Drawing.Size(73, 18);
            this.OctaveKeysLabel.TabIndex = 8;
            this.OctaveKeysLabel.Text = "Octave:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SpringGreen;
            this.label1.Location = new System.Drawing.Point(195, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Oscillator A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SpringGreen;
            this.label2.Location = new System.Drawing.Point(709, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Oscillator B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SpringGreen;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "WaveType:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.SpringGreen;
            this.label4.Location = new System.Drawing.Point(31, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Volume:";
            // 
            // VolumeBar2
            // 
            this.VolumeBar2.Location = new System.Drawing.Point(156, 107);
            this.VolumeBar2.Maximum = 100;
            this.VolumeBar2.Name = "VolumeBar2";
            this.VolumeBar2.Size = new System.Drawing.Size(157, 45);
            this.VolumeBar2.TabIndex = 13;
            this.VolumeBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar2.Value = 40;
            this.VolumeBar2.ValueChanged += new System.EventHandler(this.VolumeBar2_ValueChanged);
            // 
            // WaveTypeCB2
            // 
            this.WaveTypeCB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaveTypeCB2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WaveTypeCB2.FormattingEnabled = true;
            this.WaveTypeCB2.Items.AddRange(new object[] {
            "Sine",
            "SawTooth",
            "Square",
            "Triangle"});
            this.WaveTypeCB2.Location = new System.Drawing.Point(171, 52);
            this.WaveTypeCB2.MaxDropDownItems = 4;
            this.WaveTypeCB2.Name = "WaveTypeCB2";
            this.WaveTypeCB2.Size = new System.Drawing.Size(121, 24);
            this.WaveTypeCB2.TabIndex = 14;
            this.WaveTypeCB2.SelectedValueChanged += new System.EventHandler(this.WaveTypeCB2_SelectedValueChanged);
            // 
            // Oscillator2GroupBox
            // 
            this.Oscillator2GroupBox.BackColor = System.Drawing.Color.MediumPurple;
            this.Oscillator2GroupBox.Controls.Add(this.WaveTypeCB2);
            this.Oscillator2GroupBox.Controls.Add(this.VolumeBar2);
            this.Oscillator2GroupBox.Controls.Add(this.label3);
            this.Oscillator2GroupBox.Controls.Add(this.label4);
            this.Oscillator2GroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Oscillator2GroupBox.Location = new System.Drawing.Point(627, 220);
            this.Oscillator2GroupBox.Name = "Oscillator2GroupBox";
            this.Oscillator2GroupBox.Size = new System.Drawing.Size(319, 197);
            this.Oscillator2GroupBox.TabIndex = 15;
            this.Oscillator2GroupBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.MediumPurple;
            this.groupBox2.Controls.Add(this.VolumeBar1);
            this.groupBox2.Controls.Add(this.VolumeLabel);
            this.groupBox2.Controls.Add(this.WaveTypeLabel);
            this.groupBox2.Controls.Add(this.WaveTypeCB1);
            this.groupBox2.Location = new System.Drawing.Point(110, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 197);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // Osc2TurnCheck
            // 
            this.Osc2TurnCheck.AutoSize = true;
            this.Osc2TurnCheck.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Osc2TurnCheck.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Osc2TurnCheck.Location = new System.Drawing.Point(881, 180);
            this.Osc2TurnCheck.Name = "Osc2TurnCheck";
            this.Osc2TurnCheck.Size = new System.Drawing.Size(109, 20);
            this.Osc2TurnCheck.TabIndex = 17;
            this.Osc2TurnCheck.Text = "TurnOn/Off";
            this.Osc2TurnCheck.UseVisualStyleBackColor = true;
            this.Osc2TurnCheck.CheckedChanged += new System.EventHandler(this.Osc2TurnCheck_CheckedChanged);
            // 
            // KeyboardInput
            // 
            this.KeyboardInput.AutoSize = true;
            this.KeyboardInput.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KeyboardInput.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.KeyboardInput.Location = new System.Drawing.Point(12, 423);
            this.KeyboardInput.Name = "KeyboardInput";
            this.KeyboardInput.Size = new System.Drawing.Size(193, 20);
            this.KeyboardInput.TabIndex = 18;
            this.KeyboardInput.Text = "Keyboard Input On/Off";
            this.KeyboardInput.UseVisualStyleBackColor = true;
            // 
            // SynthesizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1030, 600);
            this.Controls.Add(this.KeyboardInput);
            this.Controls.Add(this.Osc2TurnCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OctaveKeysLabel);
            this.Controls.Add(this.Oscillator2GroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OctaveKeysSelector);
            this.Controls.Add(this.keysPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.MaximizeBox = false;
            this.Name = "SynthesizerForm";
            this.Text = "Syntezator Muzyczny";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SynthesizerForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynthesizerForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OctaveKeysSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar2)).EndInit();
            this.Oscillator2GroupBox.ResumeLayout(false);
            this.Oscillator2GroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel keysPanel;
        private System.Windows.Forms.ComboBox WaveTypeCB1;
        private System.Windows.Forms.TrackBar VolumeBar1;
        private System.Windows.Forms.Label WaveTypeLabel;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.NumericUpDown OctaveKeysSelector;
        private System.Windows.Forms.Label OctaveKeysLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar VolumeBar2;
        private System.Windows.Forms.ComboBox WaveTypeCB2;
        private System.Windows.Forms.GroupBox Oscillator2GroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Osc2TurnCheck;
        private System.Windows.Forms.CheckBox KeyboardInput;
    }
}

