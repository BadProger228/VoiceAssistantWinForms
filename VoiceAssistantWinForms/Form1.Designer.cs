namespace KursovWork
{
    partial class Form1
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
            CloseForm = new Button();
            ProgramList = new ListBox();
            AddOpenProgram = new Button();
            NameProgram = new TextBox();
            AddName = new Label();
            VoiceConfiguration = new Label();
            VoiceSpeed = new Label();
            VoiceAge = new Label();
            VoiceGender = new Label();
            AgeValue = new ComboBox();
            GenderValue = new ComboBox();
            SpeedValue = new TrackBar();
            TestingVoiceAssistant = new TextBox();
            TestButton = new Button();
            DeleteItem = new Button();
            ((System.ComponentModel.ISupportInitialize)SpeedValue).BeginInit();
            SuspendLayout();
            // 
            // CloseForm
            // 
            CloseForm.Location = new Point(656, 388);
            CloseForm.Name = "CloseForm";
            CloseForm.Size = new Size(132, 50);
            CloseForm.TabIndex = 0;
            CloseForm.Text = "Close";
            CloseForm.UseVisualStyleBackColor = true;
            CloseForm.Click += CloseForm_Click;
            // 
            // ProgramList
            // 
            ProgramList.FormattingEnabled = true;
            ProgramList.ItemHeight = 15;
            ProgramList.Location = new Point(45, 65);
            ProgramList.Name = "ProgramList";
            ProgramList.Size = new Size(214, 259);
            ProgramList.TabIndex = 1;
            // 
            // AddOpenProgram
            // 
            AddOpenProgram.Location = new Point(337, 172);
            AddOpenProgram.Name = "AddOpenProgram";
            AddOpenProgram.Size = new Size(145, 56);
            AddOpenProgram.TabIndex = 2;
            AddOpenProgram.Text = "Add Program";
            AddOpenProgram.UseVisualStyleBackColor = true;
            AddOpenProgram.Click += AddOpenProgram_Click;
            // 
            // NameProgram
            // 
            NameProgram.Location = new Point(337, 143);
            NameProgram.Name = "NameProgram";
            NameProgram.Size = new Size(145, 23);
            NameProgram.TabIndex = 3;
            // 
            // AddName
            // 
            AddName.AutoSize = true;
            AddName.Location = new Point(317, 112);
            AddName.Name = "AddName";
            AddName.Size = new Size(184, 15);
            AddName.TabIndex = 4;
            AddName.Text = "Add name for program (optional)";
            // 
            // VoiceConfiguration
            // 
            VoiceConfiguration.AutoSize = true;
            VoiceConfiguration.Location = new Point(624, 48);
            VoiceConfiguration.Name = "VoiceConfiguration";
            VoiceConfiguration.Size = new Size(113, 15);
            VoiceConfiguration.TabIndex = 5;
            VoiceConfiguration.Text = "Voice configuration ";
            // 
            // VoiceSpeed
            // 
            VoiceSpeed.AutoSize = true;
            VoiceSpeed.Location = new Point(541, 112);
            VoiceSpeed.Name = "VoiceSpeed";
            VoiceSpeed.Size = new Size(39, 15);
            VoiceSpeed.TabIndex = 6;
            VoiceSpeed.Text = "Speed";
            // 
            // VoiceAge
            // 
            VoiceAge.AutoSize = true;
            VoiceAge.Location = new Point(552, 159);
            VoiceAge.Name = "VoiceAge";
            VoiceAge.Size = new Size(28, 15);
            VoiceAge.TabIndex = 7;
            VoiceAge.Text = "Age";
            // 
            // VoiceGender
            // 
            VoiceGender.AutoSize = true;
            VoiceGender.Location = new Point(541, 208);
            VoiceGender.Name = "VoiceGender";
            VoiceGender.Size = new Size(45, 15);
            VoiceGender.TabIndex = 8;
            VoiceGender.Text = "Gender";
            // 
            // AgeValue
            // 
            AgeValue.FormattingEnabled = true;
            AgeValue.Location = new Point(607, 156);
            AgeValue.Name = "AgeValue";
            AgeValue.Size = new Size(121, 23);
            AgeValue.TabIndex = 10;
            AgeValue.SelectedIndexChanged += AgeValue_SelectedIndexChanged;
            // 
            // GenderValue
            // 
            GenderValue.FormattingEnabled = true;
            GenderValue.Location = new Point(607, 205);
            GenderValue.Name = "GenderValue";
            GenderValue.Size = new Size(121, 23);
            GenderValue.TabIndex = 11;
            GenderValue.SelectedIndexChanged += GenderValue_SelectedIndexChanged;
            // 
            // SpeedValue
            // 
            SpeedValue.Location = new Point(607, 105);
            SpeedValue.Name = "SpeedValue";
            SpeedValue.Size = new Size(121, 45);
            SpeedValue.TabIndex = 12;
            SpeedValue.Scroll += SpeedValue_Scroll;
            // 
            // TestingVoiceAssistant
            // 
            TestingVoiceAssistant.Location = new Point(593, 301);
            TestingVoiceAssistant.Name = "TestingVoiceAssistant";
            TestingVoiceAssistant.Size = new Size(135, 23);
            TestingVoiceAssistant.TabIndex = 13;
            TestingVoiceAssistant.TextChanged += TestingVoiceAssistant_TextChanged;
            // 
            // TestButton
            // 
            TestButton.Location = new Point(624, 330);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(92, 41);
            TestButton.TabIndex = 14;
            TestButton.Text = "Test";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // DeleteItem
            // 
            DeleteItem.Location = new Point(45, 342);
            DeleteItem.Name = "DeleteItem";
            DeleteItem.Size = new Size(214, 55);
            DeleteItem.TabIndex = 15;
            DeleteItem.Text = "Delete select program";
            DeleteItem.UseVisualStyleBackColor = true;
            DeleteItem.Click += DeleteItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteItem);
            Controls.Add(TestButton);
            Controls.Add(TestingVoiceAssistant);
            Controls.Add(SpeedValue);
            Controls.Add(GenderValue);
            Controls.Add(AgeValue);
            Controls.Add(VoiceGender);
            Controls.Add(VoiceAge);
            Controls.Add(VoiceSpeed);
            Controls.Add(VoiceConfiguration);
            Controls.Add(AddName);
            Controls.Add(NameProgram);
            Controls.Add(AddOpenProgram);
            Controls.Add(ProgramList);
            Controls.Add(CloseForm);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)SpeedValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseForm;
        private ListBox ProgramList;
        private Button AddOpenProgram;
        private TextBox NameProgram;
        private Label AddName;
        private Label VoiceConfiguration;
        private Label VoiceSpeed;
        private Label VoiceAge;
        private Label VoiceGender;
        private ComboBox AgeValue;
        private ComboBox GenderValue;
        private TrackBar SpeedValue;
        private TextBox TestingVoiceAssistant;
        private Button TestButton;
        private Button DeleteItem;
    }
}
