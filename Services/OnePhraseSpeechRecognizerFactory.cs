using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using MyLocation.Services.Interfaces;

namespace MyLocation.Services
{
    public class OnePhraseSpeechRecognizerFactory : ISpeechRecognizerFactory
    {
        private readonly string _phrase;

        public OnePhraseSpeechRecognizerFactory(string phrase)
        {
            _phrase = phrase;
        }

        public SpeechRecognizer CreateSpeechRecognizer()
        {
            var grammar = new Grammar(new GrammarBuilder(_phrase));
            var recognizer = new SpeechRecognizer();
            recognizer.LoadGrammar(grammar);
            return recognizer;
        }
    }
}
