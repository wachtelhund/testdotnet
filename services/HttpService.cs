using System.Net;
using System.Net.Http.Headers;

public class HttpService {

    private readonly HttpClient _client;

    public HttpService()
    {
        HttpClientHandler handler = new()
        { 
            AutomaticDecompression = DecompressionMethods.All 
        };
        
        _client = new HttpClient();
    }


    public async Task<string> GetAsync(string uri, string acceptHeader)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));

        using HttpResponseMessage response = await _client.GetAsync(uri);

        return await response.Content.ReadAsStringAsync();
    }
}