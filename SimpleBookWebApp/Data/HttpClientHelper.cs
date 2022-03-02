#nullable disable

namespace SimpleBookWebApp.Data
{
    public class HttpClientHelper
    {
        private readonly IConfiguration _configuration;

        public HttpClientHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> EnviaHttpRequestAsync(HttpRequestHelper httpRequisicao, string endpoint, object objectSending = null)
        {
            var uri = new Uri($"{_configuration.GetSection("SimpleBook:UrlApiBook").Value}{endpoint}");
            var httpHeaders = new Dictionary<string, string>();

            var myHttpResponse = await httpRequisicao.ExecutaRequisicaoAsync(uri, httpHeaders, objectSending);
            if (myHttpResponse.IsSuccessStatusCode)
                return myHttpResponse;

            var objectError = await HttpRequestHelper.ConverteHttpResponseToObjectTask<object>(myHttpResponse);
            if (objectError == null)
                throw new Exception($"Error to create Book StatusCode: {myHttpResponse.StatusCode} - Message: {myHttpResponse.ReasonPhrase}");
            throw new Exception(objectError.ToString());
        }
    }
}
