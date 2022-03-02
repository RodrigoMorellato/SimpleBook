using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleBookWebApp.Data
{
    public abstract class HttpRequestHelper
    {
        public static Task<HttpClient> CriaHttpClient(Uri uri, Dictionary<string, string> httpHeaders, string? mediaAcceptHeader = null)
        {
            var client = new HttpClient
            {
                BaseAddress = uri
            };
            client.DefaultRequestHeaders.Accept.Clear();
            if (!string.IsNullOrWhiteSpace(mediaAcceptHeader))
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue(mediaAcceptHeader)); //ACCEPT header

            foreach (var (key, value) in httpHeaders)
            {
                client.DefaultRequestHeaders.Add(key, value);
            }

            return Task.FromResult(client);
        }

        public abstract Task<HttpResponseMessage> ExecutaRequisicaoAsync(Uri uri,
            Dictionary<string, string> httpHeaders,
            object? objectSending = null);

        internal static async Task<T?> ConverteHttpResponseToObjectTask<T>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            if (responseBody.Length == 0)
                return default;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            return await JsonSerializer.DeserializeAsync<T>(responseBody, options);
        }
    }
}
