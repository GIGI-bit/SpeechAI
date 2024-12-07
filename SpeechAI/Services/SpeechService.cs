using Microsoft.CognitiveServices.Speech;

namespace SpeechAI.Services
{
    public class SpeechService
    {
        private readonly string _subscriptionKey;
        private readonly string _region;

        public SpeechService(string subscriptionKey, string region)
        {
            _subscriptionKey = subscriptionKey;
            _region = region;
        }
        public async Task<string> RecognizeSpeechAsync()
        {
            var config = SpeechConfig.FromSubscription(_subscriptionKey, _region);
            using var recognizer = new SpeechRecognizer(config);

            var result = await recognizer.RecognizeOnceAsync();
            return result.Text;
        }

        public async Task SynthesizeSpeechAsync(string text)
        {
            var config = SpeechConfig.FromSubscription(_subscriptionKey, _region);
            using var synthesizer = new SpeechSynthesizer(config);
            await synthesizer.SpeakTextAsync(text);
        }
    }
}
