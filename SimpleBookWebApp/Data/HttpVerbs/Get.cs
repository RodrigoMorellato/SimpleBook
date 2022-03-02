namespace SimpleBookWebApp.Data.HttpVerbs
{
    public class Get : HttpRequestHelper
    {
        public override async Task<HttpResponseMessage> ExecutaRequisicaoAsync(Uri uri, Dictionary<string, string> httpHeaders, object? objectSending = null)
        {
            return await ExecutaPostAsync(uri, httpHeaders);
        }

        private static async Task<HttpResponseMessage> ExecutaPostAsync(Uri uri, Dictionary<string, string> httpHeaders)
        {
            using var client = await CriaHttpClient(uri, httpHeaders, "application/json");
            return await client.GetAsync(client.BaseAddress);
        }
    }
}
