using System;
using System.Speech.Recognition;
using MyLocation.Services.Interfaces;

namespace MyLocation.Services
{
    public class SimpleVoiceRecognitionService : IVoiceRecognitionService, IDisposable
    {
        private readonly ISpeechRecognizerFactory _recognizerFactory;

        //speech recognizer is IDisposable and is instantiated inside this class,
        //so the higher level of IDisposable should be implemented to not keep it hanging
        private SpeechRecognizer? _recognizer;

        public SimpleVoiceRecognitionService(ISpeechRecognizerFactory recognizerFactory)
        {
            _recognizerFactory = recognizerFactory ?? throw new ArgumentNullException(nameof(recognizerFactory));
        }

        public event EventHandler<EventArgs>? VoiceCommandReceived;

        public void StartListening()
        {
            //lazy init recognizer, to not waste memory if it is never needed
            if (_recognizer == null)
            {
                _recognizer = _recognizerFactory.CreateSpeechRecognizer();
                _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            }
        }

        private void _recognizer_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            VoiceCommandReceived?.Invoke(this, EventArgs.Empty);
        }

        public void StopListening()
        {
            DisposeRecognizer();
        }
        
        public void Dispose()
        {
            DisposeRecognizer();
        }

        private void DisposeRecognizer()
        {
            if (_recognizer != null)
            {
                _recognizer.SpeechRecognized -= _recognizer_SpeechRecognized;
                _recognizer.Dispose();
            }
        }
    }
}
