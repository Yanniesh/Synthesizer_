
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
            this.WaveTypeCB = new System.Windows.Forms.ComboBox();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.WaveTypeLabel = new System.Windows.Forms.Label();
            this.VolumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
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
            // WaveTypeCB
            // 
            this.WaveTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaveTypeCB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WaveTypeCB.FormattingEnabled = true;
            this.WaveTypeCB.Items.AddRange(new object[] {
            "Sine",
            "SawTooth",
            "Square",
            "Triangle"});
            this.WaveTypeCB.Location = new System.Drawing.Point(124, 341);
            this.WaveTypeCB.Name = "WaveTypeCB";
            this.WaveTypeCB.Size = new System.Drawing.Size(121, 24);
            this.WaveTypeCB.TabIndex = 3;
            this.WaveTypeCB.TextChanged += new System.EventHandler(this.WaveTypeCB_TextChanged);
            // 
            // VolumeBar
            // 
            this.VolumeBar.Location = new System.Drawing.Point(127, 383);
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(104, 45);
            this.VolumeBar.TabIndex = 4;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Value = 1;
            this.VolumeBar.ValueChanged += new System.EventHandler(this.VolumeBar_ValueChanged);
            // 
            // WaveTypeLabel
            // 
            this.WaveTypeLabel.AutoSize = true;
            this.WaveTypeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WaveTypeLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.WaveTypeLabel.Location = new System.Drawing.Point(12, 342);
            this.WaveTypeLabel.Name = "WaveTypeLabel";
            this.WaveTypeLabel.Size = new System.Drawing.Size(108, 18);
            this.WaveTypeLabel.TabIndex = 5;
            this.WaveTypeLabel.Text = "WaveType:";
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.VolumeLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.VolumeLabel.Location = new System.Drawing.Point(28, 383);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(79, 18);
            this.VolumeLabel.TabIndex = 6;
            this.VolumeLabel.Text = "Volume:";
            // 
            // SynthesizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(88)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(1030, 600);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.WaveTypeLabel);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.WaveTypeCB);
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
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel keysPanel;
        private System.Windows.Forms.ComboBox WaveTypeCB;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Label WaveTypeLabel;
        private System.Windows.Forms.Label VolumeLabel;
    }
}

