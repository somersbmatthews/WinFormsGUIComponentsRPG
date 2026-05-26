namespace WinFormsGUIComponentsRPG
{
    partial class statsDisplay
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStory = new Label();
            displayPanel = new Panel();
            comboLocations = new ComboBox();
            statsLabel = new TextBox();
            button1 = new Button();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // lblStory
            // 
            lblStory.AutoSize = true;
            lblStory.Location = new Point(347, 130);
            lblStory.Name = "lblStory";
            lblStory.Size = new Size(94, 32);
            lblStory.TabIndex = 0;
            lblStory.Text = "lblStory";
            // 
            // displayPanel
            // 
            displayPanel.BackColor = Color.Black;
            displayPanel.Location = new Point(193, 213);
            displayPanel.Name = "displayPanel";
            displayPanel.Size = new Size(601, 455);
            displayPanel.TabIndex = 1;
            // 
            // comboLocations
            // 
            comboLocations.FormattingEnabled = true;
            comboLocations.Location = new Point(1237, 33);
            comboLocations.Name = "comboLocations";
            comboLocations.Size = new Size(242, 40);
            comboLocations.TabIndex = 2;
            comboLocations.SelectedIndexChanged += comboLocations_SelectedIndexChanged;
            // 
            // statsLabel
            // 
            statsLabel.Location = new Point(104, 68);
            statsLabel.Name = "statsLabel";
            statsLabel.Size = new Size(200, 39);
            statsLabel.TabIndex = 4;
            statsLabel.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1350, 690);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 5;
            button1.Text = "Explore";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(193, 703);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1063, 109);
            progressBar.TabIndex = 6;
            // 
            // statsDisplay
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.DarkWood;
            ClientSize = new Size(1665, 859);
            Controls.Add(progressBar);
            Controls.Add(button1);
            Controls.Add(statsLabel);
            Controls.Add(comboLocations);
            Controls.Add(displayPanel);
            Controls.Add(lblStory);
            Name = "statsDisplay";
            Text = "WinForms GUI Components Dark Woods RPG";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStory;
        private Panel displayPanel;
        private ComboBox comboLocations;
        private TextBox statsLabel;
        private Button button1;
        private ProgressBar progressBar;
    }
}
