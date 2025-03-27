using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Media;
using System.Net;
using System.Xml;
using HtmlAgilityPack;
using static KursovWork.VoiceAssistant;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Speech.Synthesis;

namespace KursovWork
{
    public partial class Form1 : Form
    {
        List<OpenCommand> list;
        VoiceAssistant voiceAssistant;
        public Form1()
        {
            InitializeComponent();

            SpeedValue.Minimum = -10; SpeedValue.Maximum = 10;
            AgeValue.DropDownStyle = ComboBoxStyle.DropDownList;
            GenderValue.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingsConfigValue();



        }

        private void SettingsConfigValue()
        {
            foreach (var value in Enum.GetValues(typeof(VoiceAge)))
                AgeValue.Items.Add(value.ToString());

            foreach (var value in Enum.GetValues(typeof(VoiceGender)))
                GenderValue.Items.Add(value.ToString());

        }
        private void AddItem(string value)
        {
            ProgramList.Items.Add(value);
        }
        private void ShowList(List<OpenCommand> list)
        {
            ProgramList.Items.Clear();
            foreach (var item in list)
                AddItem(item.FileName);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Visible = false;
            Action<bool> setFormVisibility = ChengeVisibleForm;
            voiceAssistant = new(setFormVisibility);
            Thread thread = new(voiceAssistant.Start);
            thread.Start();

            list = voiceAssistant.openCommands;

            voiceAssistant.GetStartConfiguration(out VoiceGender voiceGender, out VoiceAge voiceAge, out int voiceSpeed);

            GenderValue.SelectedIndex = GenderValue.Items.IndexOf(voiceGender.ToString());
            AgeValue.SelectedIndex = AgeValue.Items.IndexOf(voiceAge.ToString());
            SpeedValue.Value = voiceSpeed;


            ShowList(list);
            //ProgramList.SelectedIndex = 0;
        }
        public void ChengeVisibleForm(bool visible)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => ChengeVisibleForm(visible)));
                return;
            }
            Visible = visible;
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddOpenProgram_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File only (*.exe)|*.exe";
            openFileDialog.Title = "Select program";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName;
                if (NameProgram.Text == string.Empty)
                    selectedFileName = openFileDialog.SafeFileName;
                else
                    selectedFileName = NameProgram.Text;

                string selectedFilePath = openFileDialog.FileName;

                list.Add(new OpenCommand(selectedFileName, selectedFilePath));
                ProgramList.Items.Add(selectedFileName);

                MessageBox.Show($"Selected program: {selectedFileName}\nPath: {selectedFilePath}");
            }
        }

        private void SpeedValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeVoiceConfiguration()
        {
            Enum.TryParse(GenderValue.SelectedItem.ToString(), out VoiceGender voiceGender);
            Enum.TryParse(AgeValue.SelectedItem.ToString(), out VoiceAge voiceAge);

            voiceAssistant.ChangeSpeachConfiguration(voiceGender, voiceAge, SpeedValue.Value);
        }



        private void SpeedValue_Scroll(object sender, EventArgs e)
        {
            ChangeVoiceConfiguration();
        }

        private void AgeValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AgeValue.Text == string.Empty)
                return;
            ChangeVoiceConfiguration();
        }

        private void GenderValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AgeValue.Text == string.Empty)
                return;
            ChangeVoiceConfiguration();
        }

        private void TestButton_Click(object sender, EventArgs e) => voiceAssistant.TestSpeach(TestingVoiceAssistant.Text);

        private void TestingVoiceAssistant_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (ProgramList.SelectedItem is null)
                return;

            foreach (var item in voiceAssistant.openCommands)
            {
                if (item.FileName == ProgramList.SelectedItem.ToString())
                {
                    voiceAssistant.openCommands.Remove(item);
                    ShowList(voiceAssistant.openCommands);
                    break;
                }
            }
        }
    }
}












