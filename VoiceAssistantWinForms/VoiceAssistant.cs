using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Net;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using System.Windows.Forms;
using static KursovWork.VoiceAssistant;

namespace KursovWork
{
    public class VoiceAssistant
    {
        private Action<bool> ChangeVisible;
        private SpeechRecognitionEngine recognizer = new();
        private SpeechRecognitionEngine recognizerQuery;
        private SpeechSynthesizer synth = new();
        public List<OpenCommand> openCommands { get; set; }
        private Action<string> command;
        
        public class OpenCommand
        {
            public string FileName { get; set; }
            public string Path { get; set; }

            public OpenCommand(string programName, string pathToFile)
            {
                FileName = programName;
                Path = pathToFile;
            }
            public override string ToString()
            {
                return FileName + ", " + Path;
            }
        }
        
        public VoiceAssistant(Action<bool> changeVisible)
        {
            OpenConfiguration(GetProgramDirectory() + "\\Configuration.xml");
            ChangeVisible = changeVisible;
        }
        public VoiceAssistant(string configPath, Action<bool> changeVisible)
        {
            OpenConfiguration(configPath);
            ChangeVisible = changeVisible;
        }
        
        public void Start()
        {

            SystemSounds.Beep.Play();

           

            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(new Choices("Can you find in Google", "Stop recognition", "open program", "Settings", "Close Settings", "Help"));
            var grammar = new Grammar(grammarBuilder);
            recognizer.LoadGrammar(grammar);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += RecognizerCommand_SpeechRecognized;
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            // Load grammar for recognizerQuery
            
            DefaultRecognizerQuery();

            synth.Speak("Hi, I'm your voice assistant. If you need help for use me just say help");
            //AddChoicesForQuery();


        }
        public void TestSpeach(string text) => synth.Speak(text);




        private void CreateRecognizerQuery()
        {
            recognizerQuery = new();
            recognizerQuery.SetInputToDefaultAudioDevice();
            recognizerQuery.SpeechRecognized += RecognizerQuery_SpeechRecognized;
        }
        private void DefaultRecognizerQuery() 
        {
            if(recognizerQuery != null)
                recognizerQuery.Dispose();

            CreateRecognizerQuery();
            recognizerQuery.LoadGrammar(new DictationGrammar());    
        }
        public void ChangeSpeachConfiguration(VoiceGender voiceGender, VoiceAge voiceAge, int voiceSpeed)
        {   
                synth.SelectVoiceByHints(voiceGender, voiceAge);
                synth.Rate = voiceSpeed;   
        }

        private void OpenConfiguration(string configPath)
        {
            openCommands = new();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(configPath);

                XmlNode settingsNode = xmlDoc.SelectSingleNode("/Settings");
                int voiceGender = int.Parse(settingsNode.SelectSingleNode("VoiceGender").InnerText);
                int voiceAge = int.Parse(settingsNode.SelectSingleNode("VoiceAge").InnerText);

                ChangeSpeachConfiguration((VoiceGender)voiceGender, (VoiceAge)voiceAge, int.Parse(settingsNode.SelectSingleNode("VoiceSpeed").InnerText));

                
                

                XmlNodeList openCommandsTMP = xmlDoc.SelectNodes("/Settings/OpenCommand");
                foreach (XmlNode openCommand in openCommandsTMP)
                {
                    string programName = openCommand.SelectSingleNode("programName").InnerText;
                    string pathToFile = openCommand.SelectSingleNode("pathToFile").InnerText;
                    openCommands.Add(new OpenCommand(programName, pathToFile));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void AddChoicesForQuery()
        {

            CreateRecognizerQuery();

            Choices choices = new();

            foreach(var program in openCommands)
                choices.Add(program.FileName);

            choices.Add("Nothing");

            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(choices);
            var grammar = new Grammar(grammarBuilder);
            recognizerQuery.LoadGrammar(grammar);

        }
        private string GetProgramDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);
            for (int i = 0; i < 2; i++)
            {
                if (parentDirectory == null)
                    return null;

                parentDirectory = parentDirectory.Parent;
            }
            return parentDirectory.FullName;
        }

        public void GetStartConfiguration(out VoiceGender voiceGender, out VoiceAge voiceAge, out int voiceSpeed)
        {
            voiceGender = synth.Voice.Gender;
            voiceAge = synth.Voice.Age;
            voiceSpeed = synth.Rate;
        }
        private void RecognizerCommand_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence <= 0.7)
                return;
            


            if (e.Result.Text == "Can you find in Google")
            {

                recognizer.RecognizeAsyncCancel();
                synth.Speak("Yeah, search in Google");
                SystemSounds.Beep.Play();
                command = SearchInGoogle;
                recognizerQuery.RecognizeAsync(RecognizeMode.Multiple);
            }
            else if (e.Result.Text == "open program")
            {
                recognizer.RecognizeAsyncCancel();
                synth.Speak("Yes, what do you want to open");
                SystemSounds.Beep.Play();
                command = OpenProgram;
                AddChoicesForQuery();
                recognizerQuery.RecognizeAsync(RecognizeMode.Multiple);
            }
            else if (e.Result.Text == "Stop recognition")
            {
                synth.Speak("OK, bye!");
                Environment.Exit(0);
            }
            else if (e.Result.Text == "Settings")
            {
                synth.Speak("OK, wait a second!");
                ChangeVisible?.Invoke(true);
            }
            else if (e.Result.Text == "Close Settings")
            {
                synth.Speak("A moment");
                ChangeVisible?.Invoke(false);
            }
            else if (e.Result.Text == "Help")
            {
                synth.Speak(File.ReadAllText(GetProgramDirectory() + "\\read me.txt"));
            } 
        }



        private void RecognizerQuery_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            command(e.Result.Text);
            recognizerQuery.RecognizeAsyncCancel();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void OpenProgram(string programName)
        {
            if (programName == "Nothing") {
                synth.Speak("OK, close open program command");
                DefaultRecognizerQuery();
                return;
            }
            foreach (var program in openCommands)
            {
                if (program.FileName == programName)
                {
                    if (File.Exists(program.Path))
                        Process.Start(program.Path);
                    else
                        MessageBox.Show("File is not found");

                    break;
                }
            }
            DefaultRecognizerQuery();
        }

        private async void SearchInGoogle(string query)
        {

            string url = $"https://www.google.com/search?q={Uri.EscapeDataString(query)}";
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
