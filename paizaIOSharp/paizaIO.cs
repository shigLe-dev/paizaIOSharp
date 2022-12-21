using System.Text;
using System.Text.Json.Nodes;

namespace paizaIOSharp;

public static class paizaIO
{
    static HttpClient client;

    static paizaIO()
    {
        client = new HttpClient();
    }

    public static string CreateRunner(string sourceCode, string language, string input)
    {
        var content = new StringContent("", Encoding.UTF8, @"application/json");
        var uri = $"http://api.paiza.io:80/runners/create?source_code={sourceCode}&language={language}&input={input}&api_key=guest";
        var result = client.PostAsync(uri, content).Result;
        var node = JsonNode.Parse(result.Content.ReadAsStringAsync().Result);
        return node?["id"]?.GetValue<string>() ?? "";
    }

    public static string GetStatus(string id)
    {
        var result = client.GetAsync($"http://api.paiza.io:80/runners/get_status?id={id}&api_key=guest").Result;
        var node = JsonNode.Parse(result.Content.ReadAsStringAsync().Result);
        return node?["status"]?.GetValue<string>() ?? "";
    }
}
