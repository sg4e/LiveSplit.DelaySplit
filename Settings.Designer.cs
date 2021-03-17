
namespace LiveSplit.DelaySplit
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.DelayLabel = new System.Windows.Forms.Label();
            this.SplitNameLabel = new System.Windows.Forms.Label();
            this.SplitNameTextBox = new System.Windows.Forms.TextBox();
            this.SplitNameExplanationLabel = new System.Windows.Forms.Label();
            this.SmartSplitDelayCheckbox = new System.Windows.Forms.CheckBox();
            this.DelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DelayUnitBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DelayLabel.Location = new System.Drawing.Point(9, 10);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(37, 13);
            this.DelayLabel.TabIndex = 0;
            this.DelayLabel.Text = "Delay:";
            // 
            // SplitNameLabel
            // 
            this.SplitNameLabel.AutoSize = true;
            this.SplitNameLabel.Location = new System.Drawing.Point(9, 36);
            this.SplitNameLabel.Name = "SplitNameLabel";
            this.SplitNameLabel.Size = new System.Drawing.Size(61, 13);
            this.SplitNameLabel.TabIndex = 3;
            this.SplitNameLabel.Text = "Split Name:";
            // 
            // SplitNameTextBox
            // 
            this.SplitNameTextBox.Location = new System.Drawing.Point(76, 33);
            this.SplitNameTextBox.Name = "SplitNameTextBox";
            this.SplitNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.SplitNameTextBox.TabIndex = 4;
            // 
            // SplitNameExplanationLabel
            // 
            this.SplitNameExplanationLabel.AutoSize = true;
            this.SplitNameExplanationLabel.Location = new System.Drawing.Point(9, 79);
            this.SplitNameExplanationLabel.Name = "SplitNameExplanationLabel";
            this.SplitNameExplanationLabel.Size = new System.Drawing.Size(279, 208);
            this.SplitNameExplanationLabel.TabIndex = 5;
            this.SplitNameExplanationLabel.Text = resources.GetString("SplitNameExplanationLabel.Text");
            // 
            // SmartSplitDelayCheckbox
            // 
            this.SmartSplitDelayCheckbox.AutoSize = true;
            this.SmartSplitDelayCheckbox.Location = new System.Drawing.Point(76, 59);
            this.SmartSplitDelayCheckbox.Name = "SmartSplitDelayCheckbox";
            this.SmartSplitDelayCheckbox.Size = new System.Drawing.Size(106, 17);
            this.SmartSplitDelayCheckbox.TabIndex = 7;
            this.SmartSplitDelayCheckbox.Text = "Smart Split Delay";
            this.SmartSplitDelayCheckbox.UseVisualStyleBackColor = true;
            // 
            // DelayNumericUpDown
            // 
            this.DelayNumericUpDown.Location = new System.Drawing.Point(76, 8);
            this.DelayNumericUpDown.Maximum = new decimal(new int[] {
            0,
            1048576,
            0,
            0});
            this.DelayNumericUpDown.Name = "DelayNumericUpDown";
            this.DelayNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.DelayNumericUpDown.TabIndex = 8;
            this.DelayNumericUpDown.ThousandsSeparator = true;
            // 
            // DelayUnitBox
            // 
            this.DelayUnitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DelayUnitBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelayUnitBox.FormattingEnabled = true;
            this.DelayUnitBox.Location = new System.Drawing.Point(141, 7);
            this.DelayUnitBox.Name = "DelayUnitBox";
            this.DelayUnitBox.Size = new System.Drawing.Size(121, 21);
            this.DelayUnitBox.TabIndex = 2;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DelayNumericUpDown);
            this.Controls.Add(this.SmartSplitDelayCheckbox);
            this.Controls.Add(this.SplitNameExplanationLabel);
            this.Controls.Add(this.SplitNameTextBox);
            this.Controls.Add(this.SplitNameLabel);
            this.Controls.Add(this.DelayUnitBox);
            this.Controls.Add(this.DelayLabel);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(350, 306);
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.Label SplitNameLabel;
        private System.Windows.Forms.TextBox SplitNameTextBox;
        private System.Windows.Forms.Label SplitNameExplanationLabel;
        private System.Windows.Forms.CheckBox SmartSplitDelayCheckbox;
        private System.Windows.Forms.NumericUpDown DelayNumericUpDown;
        private System.Windows.Forms.ComboBox DelayUnitBox;
    }
}
