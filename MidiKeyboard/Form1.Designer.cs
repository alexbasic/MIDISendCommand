namespace MidiKeyboard
{
    partial class Form1
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
            this.comboBoxMidiOutDevices = new System.Windows.Forms.ComboBox();
            this.comboBoxOctaves = new System.Windows.Forms.ComboBox();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxInstrument = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMidiOutDevices
            // 
            this.comboBoxMidiOutDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMidiOutDevices.FormattingEnabled = true;
            this.comboBoxMidiOutDevices.Location = new System.Drawing.Point(12, 25);
            this.comboBoxMidiOutDevices.Name = "comboBoxMidiOutDevices";
            this.comboBoxMidiOutDevices.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMidiOutDevices.TabIndex = 0;
            // 
            // comboBoxOctaves
            // 
            this.comboBoxOctaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOctaves.FormattingEnabled = true;
            this.comboBoxOctaves.Location = new System.Drawing.Point(139, 25);
            this.comboBoxOctaves.Name = "comboBoxOctaves";
            this.comboBoxOctaves.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOctaves.TabIndex = 1;
            this.comboBoxOctaves.SelectedIndexChanged += new System.EventHandler(this.comboBoxOctaves_SelectedIndexChanged);
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(266, 25);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChannel.TabIndex = 2;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Octale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Channel";
            // 
            // comboBoxInstrument
            // 
            this.comboBoxInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstrument.FormattingEnabled = true;
            this.comboBoxInstrument.Location = new System.Drawing.Point(393, 25);
            this.comboBoxInstrument.Name = "comboBoxInstrument";
            this.comboBoxInstrument.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInstrument.TabIndex = 6;
            this.comboBoxInstrument.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstrument_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instrument";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 142);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxInstrument);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxChannel);
            this.Controls.Add(this.comboBoxOctaves);
            this.Controls.Add(this.comboBoxMidiOutDevices);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMidiOutDevices;
        private System.Windows.Forms.ComboBox comboBoxOctaves;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxInstrument;
        private System.Windows.Forms.Label label4;
    }
}

