namespace CS2UML
{
    partial class MenuUI
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUI));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxInputFileControls = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOutputFileControls = new System.Windows.Forms.GroupBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonQuide = new System.Windows.Forms.Button();
            this.controlButton = new CS2UML.CustomButton();
            this.radioButtonDrawioOut = new CS2UML.CustomRadioButton();
            this.radioButtonCsharpOut = new CS2UML.CustomRadioButton();
            this.radioButtonDrawioIn = new CS2UML.CustomRadioButton();
            this.radioButtonCsharpIn = new CS2UML.CustomRadioButton();
            this.groupBoxInputFileControls.SuspendLayout();
            this.groupBoxOutputFileControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "drawio";
            // 
            // groupBoxInputFileControls
            // 
            this.groupBoxInputFileControls.Controls.Add(this.radioButtonDrawioIn);
            this.groupBoxInputFileControls.Controls.Add(this.radioButtonCsharpIn);
            this.groupBoxInputFileControls.Location = new System.Drawing.Point(12, 83);
            this.groupBoxInputFileControls.Name = "groupBoxInputFileControls";
            this.groupBoxInputFileControls.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxInputFileControls.Size = new System.Drawing.Size(322, 192);
            this.groupBoxInputFileControls.TabIndex = 2;
            this.groupBoxInputFileControls.TabStop = false;
            this.groupBoxInputFileControls.Text = "Vstupní soubory";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(187, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aplikace pro převod C# kódu a UML třídového diagramu";
            // 
            // groupBoxOutputFileControls
            // 
            this.groupBoxOutputFileControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOutputFileControls.Controls.Add(this.radioButtonDrawioOut);
            this.groupBoxOutputFileControls.Controls.Add(this.radioButtonCsharpOut);
            this.groupBoxOutputFileControls.Location = new System.Drawing.Point(630, 83);
            this.groupBoxOutputFileControls.Name = "groupBoxOutputFileControls";
            this.groupBoxOutputFileControls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBoxOutputFileControls.Size = new System.Drawing.Size(322, 192);
            this.groupBoxOutputFileControls.TabIndex = 3;
            this.groupBoxOutputFileControls.TabStop = false;
            this.groupBoxOutputFileControls.Text = "Výstupní soubory";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(872, 589);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(75, 77);
            this.buttonSettings.TabIndex = 5;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonQuide
            // 
            this.buttonQuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuide.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuide.Image")));
            this.buttonQuide.Location = new System.Drawing.Point(752, 589);
            this.buttonQuide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonQuide.Name = "buttonQuide";
            this.buttonQuide.Size = new System.Drawing.Size(75, 77);
            this.buttonQuide.TabIndex = 6;
            this.buttonQuide.UseVisualStyleBackColor = true;
            this.buttonQuide.Click += new System.EventHandler(this.buttonQuide_Click);
            // 
            // controlButton
            // 
            this.controlButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.controlButton.BackColor = System.Drawing.SystemColors.Control;
            this.controlButton.BorderColor = System.Drawing.Color.Gray;
            this.controlButton.BorderRadius = 20;
            this.controlButton.BorderSize = 3;
            this.controlButton.Enabled = false;
            this.controlButton.FlatAppearance.BorderSize = 0;
            this.controlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.controlButton.ForeColor = System.Drawing.Color.Black;
            this.controlButton.Location = new System.Drawing.Point(373, 324);
            this.controlButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(240, 91);
            this.controlButton.TabIndex = 7;
            this.controlButton.Text = "Vyberte formáty souborů\r\npro převod";
            this.controlButton.UseVisualStyleBackColor = false;
            this.controlButton.Click += new System.EventHandler(this.controlButton_Click);
            // 
            // radioButtonDrawioOut
            // 
            this.radioButtonDrawioOut.AutoSize = true;
            this.radioButtonDrawioOut.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(135)))), ((int)(((byte)(5)))));
            this.radioButtonDrawioOut.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonDrawioOut.Image")));
            this.radioButtonDrawioOut.Location = new System.Drawing.Point(6, 25);
            this.radioButtonDrawioOut.MinimumSize = new System.Drawing.Size(0, 22);
            this.radioButtonDrawioOut.Name = "radioButtonDrawioOut";
            this.radioButtonDrawioOut.Size = new System.Drawing.Size(242, 50);
            this.radioButtonDrawioOut.TabIndex = 7;
            this.radioButtonDrawioOut.TabStop = true;
            this.radioButtonDrawioOut.Text = "Drawio UML diagram";
            this.radioButtonDrawioOut.UnCheckedColor = System.Drawing.Color.Gray;
            this.radioButtonDrawioOut.UseVisualStyleBackColor = true;
            this.radioButtonDrawioOut.CheckedChanged += new System.EventHandler(this.radioButtonDrawioOut_CheckedChanged);
            // 
            // radioButtonCsharpOut
            // 
            this.radioButtonCsharpOut.AutoSize = true;
            this.radioButtonCsharpOut.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(55)))), ((int)(((byte)(135)))));
            this.radioButtonCsharpOut.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonCsharpOut.Image")));
            this.radioButtonCsharpOut.Location = new System.Drawing.Point(6, 111);
            this.radioButtonCsharpOut.MinimumSize = new System.Drawing.Size(0, 22);
            this.radioButtonCsharpOut.Name = "radioButtonCsharpOut";
            this.radioButtonCsharpOut.Size = new System.Drawing.Size(144, 50);
            this.radioButtonCsharpOut.TabIndex = 7;
            this.radioButtonCsharpOut.TabStop = true;
            this.radioButtonCsharpOut.Text = "C# kód";
            this.radioButtonCsharpOut.UnCheckedColor = System.Drawing.Color.Gray;
            this.radioButtonCsharpOut.UseVisualStyleBackColor = true;
            this.radioButtonCsharpOut.CheckedChanged += new System.EventHandler(this.radioButtonCsharpOut_CheckedChanged);
            // 
            // radioButtonDrawioIn
            // 
            this.radioButtonDrawioIn.AutoSize = true;
            this.radioButtonDrawioIn.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(135)))), ((int)(((byte)(5)))));
            this.radioButtonDrawioIn.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonDrawioIn.Image")));
            this.radioButtonDrawioIn.Location = new System.Drawing.Point(6, 25);
            this.radioButtonDrawioIn.MinimumSize = new System.Drawing.Size(0, 22);
            this.radioButtonDrawioIn.Name = "radioButtonDrawioIn";
            this.radioButtonDrawioIn.Size = new System.Drawing.Size(242, 50);
            this.radioButtonDrawioIn.TabIndex = 6;
            this.radioButtonDrawioIn.Text = "Drawio UML diagram";
            this.radioButtonDrawioIn.UnCheckedColor = System.Drawing.Color.Gray;
            this.radioButtonDrawioIn.UseVisualStyleBackColor = true;
            this.radioButtonDrawioIn.CheckedChanged += new System.EventHandler(this.radioButtonDrawioIn_CheckedChanged);
            // 
            // radioButtonCsharpIn
            // 
            this.radioButtonCsharpIn.AutoSize = true;
            this.radioButtonCsharpIn.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(55)))), ((int)(((byte)(135)))));
            this.radioButtonCsharpIn.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonCsharpIn.Image")));
            this.radioButtonCsharpIn.Location = new System.Drawing.Point(6, 111);
            this.radioButtonCsharpIn.MinimumSize = new System.Drawing.Size(0, 22);
            this.radioButtonCsharpIn.Name = "radioButtonCsharpIn";
            this.radioButtonCsharpIn.Size = new System.Drawing.Size(144, 50);
            this.radioButtonCsharpIn.TabIndex = 5;
            this.radioButtonCsharpIn.Text = "C# kód";
            this.radioButtonCsharpIn.UnCheckedColor = System.Drawing.Color.Gray;
            this.radioButtonCsharpIn.UseVisualStyleBackColor = true;
            this.radioButtonCsharpIn.CheckedChanged += new System.EventHandler(this.radioButtonCsharpIn_CheckedChanged);
            // 
            // MenuUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(964, 685);
            this.Controls.Add(this.controlButton);
            this.Controls.Add(this.buttonQuide);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxOutputFileControls);
            this.Controls.Add(this.groupBoxInputFileControls);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(986, 741);
            this.Name = "MenuUI";
            this.Text = "CS2UML";
            this.groupBoxInputFileControls.ResumeLayout(false);
            this.groupBoxInputFileControls.PerformLayout();
            this.groupBoxOutputFileControls.ResumeLayout(false);
            this.groupBoxOutputFileControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBoxInputFileControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxOutputFileControls;
        private CustomRadioButton radioButtonCsharpIn;
        private CustomRadioButton radioButtonDrawioIn;
        private CustomRadioButton radioButtonCsharpOut;
        private CustomRadioButton radioButtonDrawioOut;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonQuide;
        private CustomButton controlButton;
    }
}

