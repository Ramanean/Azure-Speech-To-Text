using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;
using System.Threading;
using System.Threading.Tasks;

namespace SpeechToText
{
    public partial class Form1 : Form
    {
        public static string YourSubscriptionKey = "EnterYourSubscriptionKey";
        public static string YourServiceRegion = "centralus";
        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public CancellationToken ct;

        public Form1()
        {
            InitializeComponent();
            LanguageSelect.Text = "en-US";
        }

        /// <summary>
        /// Stopping the translation, when Stop button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StopButton_Click(object sender, EventArgs e)
        {
                tokenSource.Cancel();
                
        }

        /// <summary>
        /// Starting the translation when Speak button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SpeakButton_ClickAsync(object sender, EventArgs e)
        {
            string PreviousSpeechOutput = SpeechOutput.Text;
            if (string.IsNullOrEmpty(PreviousSpeechOutput))
            {
                SpeechOutput.Clear();
            }
            else
            {

            }
          
            Label_CurrentStatus.Text = "Start Speaking";
            tokenSource = new CancellationTokenSource();
            
            await StartTranslation();
          

        }

        /// <summary>
        /// Starting the translation 
        /// </summary>
        /// <returns>Text from the Speech</returns>
        public async Task StartTranslation()
        {
            

            //Cancellation token to stop the Speech conversion
            ct = tokenSource.Token;
            
            if (ct.IsCancellationRequested)
            {
                try
                {
                    tokenSource.Cancel();
                    tokenSource.Dispose();
                    //tokenSource.TryReset();
                    ct.ThrowIfCancellationRequested();
                   
                }
                catch (TaskCanceledException)
                {
                    tokenSource = new CancellationTokenSource();
                }
                
              
            }


            /*
             * Getting the Key needed for Translation from the Azure Speech services (Need to be entered in the Speech TextBox)
             * If the text in the TextBox "SpeechKey" is null then it takes the value from the code
             */
            string AzureSpeechKey = SpeechKeyTextBox.Text;
            if (string.IsNullOrEmpty(AzureSpeechKey))
            {

            }
            else
            {
                YourSubscriptionKey = AzureSpeechKey;
            }




            /*
             * Sets the ServiceRegion and Gets the speech from the Microphone and converts the Speech into Text
             * 1.Next Line with a pause in speech before and after types the text in the next line
             * 2.Colon with a pause in speech before and after types colon
             * 
             * */
            YourServiceRegion = SpeechRegionTextBox.Text;
            var speechConfig = SpeechConfig.FromSubscription(YourSubscriptionKey, YourServiceRegion);
            speechConfig.SpeechRecognitionLanguage = LanguageSelect.Text;
            String SpeechOutputText = SpeechOutput.Text;
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);
         
            //MessageBox.Show("start speaking");
            var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
            string ReturnText = OutputSpeechRecognitionResult(speechRecognitionResult,Label_CurrentStatus);
            Label_CurrentStatus.Text = "Translating";
            if (ReturnText == "Paragraph.")
            {
                ReturnText = "\n\n";
            }
            if (ReturnText == "Next line.")
            {
                ReturnText = "\n";
            }
                if (ReturnText == "Colon.")
            {
                ReturnText = ":";
            }
            if (ReturnText == "Arrow mark")
            {
                ReturnText = ">>>>";
            }
            SpeechOutput.Text = SpeechOutputText+ReturnText;
            try
            {              
                await StartTranslation();
            }
            catch (OperationCanceledException e)
            {
                if (ct.IsCancellationRequested)
                {
                    Label_CurrentStatus.Text = "Translation Stopped";
                    // Clean up here, then...
                    MessageBox.Show("Translation Stopped");
                }
            }
           
        }

        public static string OutputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult,Label LabelStatus)
        {
            LabelStatus.Text = "Waiting for Translation";
            switch (speechRecognitionResult.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    LabelStatus.Text = "Translated";
                    Console.WriteLine($"RECOGNIZED: Text={speechRecognitionResult.Text}");                  
                    break;

                case ResultReason.NoMatch:
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    break;

                case ResultReason.Canceled:
                    var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    }
                    break;
            }
            return speechRecognitionResult.Text;
        }

        private void SpeechOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void SpeechKeytextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void Label_Region_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label_CurrentStatus_Click(object sender, EventArgs e)
        {

        }
    }
}