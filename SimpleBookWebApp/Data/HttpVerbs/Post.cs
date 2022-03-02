namespace SimpleBookWebApp.Data.HttpVerbs
{
    public class Post : HttpRequestHelper
    {
        public override async Task<HttpResponseMessage> ExecutaRequisicaoAsync(Uri uri, Dictionary<string, string> httpHeaders, object? objectSending = null)
        {
            return await ExecutaPostAsync(uri, httpHeaders, objectSending);
        }

        private static async Task<HttpResponseMessage> ExecutaPostAsync(Uri uri, Dictionary<string, string> httpHeaders, object? objectSending = null)
        {
            using var client = await CriaHttpClient(uri, httpHeaders, "application/json");
            return await client.PostAsJsonAsync(client.BaseAddress, objectSending);
        }
    }
}
