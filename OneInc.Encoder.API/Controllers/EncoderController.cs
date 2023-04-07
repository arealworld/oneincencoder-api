using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using OneInc.Encoder.API.DTOs;
using OneInc.Encoder.API.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace OneInc.Encoder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncoderController : ControllerBase
    {
        private readonly ILogger<EncoderController> _logger;

        public EncoderController(ILogger<EncoderController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Convert a string to base64, getting one character at time
        /// </summary>
        /// <param name="originalText"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("GetBase64FromString")]
        [Produces("application/json")]
        [HttpGet]
        public async IAsyncEnumerable<string> GetBase64FromString(string originalText,[EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var originalTextBytes = Encoding.UTF8.GetBytes(originalText);
            string base64FromString = Convert.ToBase64String(originalTextBytes);

            foreach (char character in base64FromString.ToArray())
            {
                await Task.Delay(new Random().Next(1000, 5000), cancellationToken);
                yield return character.ToString();
            }
        }
    }
}