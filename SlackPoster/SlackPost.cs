using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SlackPoster.Models;

namespace SlackPoster
{
    public class SlackPost : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _webhookUri;

        public SlackPost(string webhookUrl)
        {
            _httpClient = new HttpClient();
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
            {
                throw new ArgumentException("SlackPoster: Please enter a valid web hook url.");
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public bool PostMessage(string message)
        {
            var payload = new SlackPayload();
            payload.Blocks.Add(new SlackBlock {Type = "section", Text = new SlackText {Text = message}});
            return SlackPostAsync(JsonSerializer.Serialize(payload), false).Result;
        }

        public async Task<bool> PostMessageAsync(string message)
        {
            var payload = new SlackPayload();
            payload.Blocks.Add(new SlackBlock {Type = "section", Text = new SlackText {Text = message}});
            return await SlackPostAsync(JsonSerializer.Serialize(payload));
        }

        public bool PostSlackPayload(SlackPayload payload)
        {
            return SlackPostAsync(JsonSerializer.Serialize(payload), false).Result;
        }

        public async Task<bool> PostSlackPayloadAsync(SlackPayload payload)
        {
            return await SlackPostAsync(JsonSerializer.Serialize(payload));
        }

        public bool LegacyPostMessage(string message)
        {
            var payload = new SlackPayloadLegacy {Text = message};
            return SlackPostAsync(JsonSerializer.Serialize(payload), false).Result;
        }

        public async Task<bool> LegacyPostMessageAsync(string message)
        {
            var payload = new SlackPayloadLegacy { Text = message };
            return await SlackPostAsync(JsonSerializer.Serialize(payload));
        }

        public bool LegacyPostSlackPayload(SlackPayloadLegacy payload)
        {
            return SlackPostAsync(JsonSerializer.Serialize(payload), false).Result;
        }

        public async Task<bool> LegacyPostSlackPayloadAsync(SlackPayloadLegacy payload)
        {
            return await SlackPostAsync(JsonSerializer.Serialize(payload));
        }

        private async Task<bool> SlackPostAsync(string json, bool configureAwait = true)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, _webhookUri))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.SendAsync(request).ConfigureAwait(configureAwait);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"SlackPoster: {content} / {json}");
                return content.Equals("ok", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
