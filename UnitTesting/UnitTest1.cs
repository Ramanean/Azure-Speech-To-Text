using SpeechToText;
namespace UnitTesting
{
   
  
        [TestClass]
        public class SpeechToTextTests
        {



            [DataRow("New paragraph.", "\n\n")]
            [DataRow("Colon.", ":")]
            [DataRow("Arrow mark", ">>>>")]
            [DataRow("Next line.", "\n")]
            [DataTestMethod]
            public void TestConvertedText(string TranslatedText, string ConvertedText)
            {

                //Mpore changes
                string ConvertedText_Expected = ConvertedText;
                string ConvertedText_Actual = Form1.ConvertReturnText(TranslatedText);
                Assert.AreEqual(ConvertedText_Expected, ConvertedText_Actual, true, TranslatedText + "is failing to convert");


            }
        }
    
}