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
        /// Starts the translation when Speak button is clicked
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
        /// Starts the Translation by using Azure Speech Services SDK and returns back the Text!
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


            /* Getting the Key needed for Translation from the Azure Speech services (Need to be entered in the Speech TextBox)
              If the text in the TextBox "SpeechKey" is null then it takes the value from the code  
            */
            string AzureSpeechKey = SpeechKeyTextBox.Text;
            if (string.IsNullOrEmpty(AzureSpeechKey))
            {

            }
            else
            {
                YourSubscriptionKey = AzureSpeechKey;
            }


            
             /* Sets the ServiceRegion and Gets the speech from the Microphone and converts the Speech into Text
               1.Next Line with a pause in speech before and after types the text in the next line
               2.Colon with a pause in speech before and after types colon
               3.Paragraph will create a new Paragraph */
            YourServiceRegion = SpeechRegionTextBox.Text;
            var speechConfig = SpeechConfig.FromSubscription(YourSubscriptionKey, YourServiceRegion);



            //Gets the language as well as any text that has been already translated
            speechConfig.SpeechRecognitionLanguage = LanguageSelect.Text;
            string SpeechOutputText = SpeechOutput.Text;
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);        
            var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();

            //Returns the Speech as Text 
            string ReturnText = OutputSpeechRecognitionResult(speechRecognitionResult,Label_CurrentStatus);
            string FinalReturnText = ConvertReturnText(ReturnText);

            Label_CurrentStatus.Text = "Translating";
       

            /*
             * Setting the Output with translated Text and again starting the Translation.
             * And when Stop button is clicked, Translation would be stopped but can be restarted again using Speak button
             */
            SpeechOutput.Text = SpeechOutputText+ FinalReturnText;
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

        /// <summary>
        /// Get the Speech Recognizition Results from Azure and Sets the Label Status
        /// </summary>
        /// <param name="speechRecognitionResult">Speech Recognition</param>
        /// <param name="LabelStatus">Label which needs to set the Status</param>
        /// <returns></returns>

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

        public static string ConvertReturnText(string ReturnText)
        {
            switch (ReturnText)
            {
                case "New paragraph.":
                    ReturnText = "\n\n";
                    break;

                case "Next line.":
                    ReturnText = "\n";
                    break;

                case "Colon.":
                    ReturnText = ":";
                    break;

                case "Arrow mark":
                    ReturnText = ">>>>";
                    break;

            }          
            return ReturnText;
        }

      
    }
}