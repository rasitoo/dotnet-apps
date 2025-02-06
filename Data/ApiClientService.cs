using System.Net.Http;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data;

internal class ApiClientService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiClientService()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<JsonDocument> GetJsonAsync(string url)
    {
        HttpResponseMessage response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(content);
    }
}
