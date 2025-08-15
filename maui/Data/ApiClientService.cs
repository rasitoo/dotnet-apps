using System.Text;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data;

public class ApiClientService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;
    public string Url { get; } = "http://192.168.16.10:8080";
    //public string Url { get; } = "http://localhost:8081";

    public ApiClientService(HttpClient client)
    {
        _client = client;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<JsonDocument> GetJsonAsync(string urlextension)
    {

        var response = await _client.GetAsync(Url + urlextension);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(jsonString);
    }

    public async Task<HttpResponseMessage> PostJsonAsync(string urlextension, object data)
    {
        var jsonString = JsonSerializer.Serialize(data, _serializerOptions);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return await _client.PostAsync(Url + urlextension, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string urlextension)
    {
        return await _client.DeleteAsync(Url + urlextension);
    }

    public async Task<HttpResponseMessage> PatchJsonAsync(string urlextension, object data)
    {
        var jsonString = JsonSerializer.Serialize(data, _serializerOptions);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), Url + urlextension)
        {
            Content = content
        };
        return await _client.SendAsync(request);
    }
}
