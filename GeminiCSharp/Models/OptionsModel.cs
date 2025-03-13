using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeminiCSharp.Models
{
    public class OptionsModel
    {
        internal sealed class GeminiOptions
        {
            public string ApiKey { get; set; } = string.Empty;
            public string Url { get; set; } = string.Empty;
        }
    }
}