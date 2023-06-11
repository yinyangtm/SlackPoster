using System.Text.Json.Serialization;

namespace SlackPoster.Models
{
    public class SlackText
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "plain_text";


        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text { get; set; }


        [JsonPropertyName("emoji")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Emoji { get; set; } = true;
    }
}
