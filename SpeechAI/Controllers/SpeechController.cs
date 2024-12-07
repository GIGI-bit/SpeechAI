using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechAI.Services;

namespace SpeechAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechController : ControllerBase
    {
        private readonly SpeechService _speechService;

        public SpeechController(SpeechService speechService)
        {
            _speechService = speechService;
        }

        [HttpGet("recognize")]
        public async Task<IActionResult> RecognizeSpeech()
        {
            var text = await _speechService.RecognizeSpeechAsync();
            return Ok(new { Transcription = text });
        }

        [HttpPost("synthesize")]
        public async Task<IActionResult> SynthesizeSpeech([FromBody] string text)
        {
            await _speechService.SynthesizeSpeechAsync(text);
            return Ok();
        }
    }
}
