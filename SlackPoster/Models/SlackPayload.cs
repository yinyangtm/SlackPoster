using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackPoster.Models
{
    [Serializable]
    public class SlackPayload
    {
        [JsonPropertyName("blocks")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<SlackBlock> Blocks { get; set; } = new();
    }
}
