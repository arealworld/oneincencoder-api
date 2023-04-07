using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneInc.Encoder.BusinessLogic
{
    public class EncoderService
    {
        public async IAsyncEnumerable<string> ConvertStringToBase64Async(string originalText)
        {
            var originalTextBytes = Encoding.UTF8.GetBytes(originalText);
            string base64FromString = Convert.ToBase64String(originalTextBytes); ;

            foreach (char character in base64FromString.ToArray())
            {
                await Task.Delay(new Random().Next(1000, 5000));
                yield return character.ToString();
            }
        }
    }
}
