using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackPoster.Models
{
    [Serializable]
    public class SlackBlock
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }


        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SlackText Text { get; set; }

    }
}
