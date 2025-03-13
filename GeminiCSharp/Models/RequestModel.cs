using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeminiCSharp.Models
{
    public class RequestModel
    {
        // Our request body
        internal sealed class GeminiRequest
        {
            public GeminiContent[] Contents { get; set; }
            public GenerationConfig GenerationConfig { get; set; }
            public SafetySettings[] SafetySettings { get; set; }
        }

        internal sealed class GeminiContent
        {
            public string Role { get; set; }
            public GeminiPart[] Parts { get; set; }
        }

        internal sealed class GeminiPart
        {
            // This one interests us the most
            public string Text { get; set; }
        }

        // Two models used for configuration
        internal sealed class GenerationConfig
        {
            public int Temperature { get; set; }
            public int TopK { get; set; }
            public int TopP { get; set; }
            public int MaxOutputTokens { get; set; }
            public List<object> StopSequences { get; set; }
        }

        internal sealed class SafetySettings
        {
            public string Category { get; set; }
            public string Threshold { get; set; }
        }
    }
}