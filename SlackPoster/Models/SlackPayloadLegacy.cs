using System;
using System.Text.Json.Serialization;

namespace SlackPoster.Models
{
    [Serializable]
    public class SlackPayloadLegacy
    {
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text { get; set; }

        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Username { get; set; }

        [JsonPropertyName("channel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Channel { get; set; }

        [JsonPropertyName("icon_emoji")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Icon_emoji { get; set; }

        [JsonPropertyName("icon_url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Icon_url { get; set; }
    }
}
