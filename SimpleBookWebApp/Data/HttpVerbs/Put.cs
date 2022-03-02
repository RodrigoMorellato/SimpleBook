namespace SimpleBookWebApp.Data.HttpVerbs
{
    public class Put : HttpRequestHelper
    {
        public override async Task<HttpResponseMessage> ExecutaRequisicaoAsync(Uri uri, Dictionary<string, string> httpHeaders, object? objectSending = null)
        {
            return await ExecutaPutAsync(uri, httpHeaders, objectSending);
        }

        private static async Task<HttpResponseMessage> ExecutaPutAsync(Uri uri, Dictionary<string, string> httpHeaders, object? objectSending = null)
        {
            using var client = await CriaHttpClient(uri, httpHeaders, "application/json");
            return await client.PutAsJsonAsync(client.BaseAddress, objectSending);
        }
    }
}
