using System.Text;
using System.Text.Json.Nodes;

namespace paizaIOSharp;

public static class PaizaIO
{
    static HttpClient client;

    static PaizaIO()
    {
        client = new HttpClient();
    }

    public static async Task<Result> RunAsync(string sourceCode, string language, string input = "")
    {
        return await Task.Run(() => { 
            return Run(sourceCode, language, input);
        });
    }

    public static Result Run(string sourceCode, string language, string input = "")
    {
        string id = CreateRunner(sourceCode, language, input);
        while (GetStatus(id) != "completed"){}
        return GetDetails(id);
    }

    public static string CreateRunner(string sourceCode, string language, string input)
    {
        sourceCode = Uri.EscapeDataString(sourceCode);
        input = Uri.EscapeDataString(input);
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

    public static Result GetDetails(string id)
    {
        var result = client.GetAsync($"http://api.paiza.io:80/runners/get_details?id={id}&api_key=guest").Result;
        var node = JsonNode.Parse(result.Content.ReadAsStringAsync().Result);
        var ret = new Result();

        ret.id = node?["id"]?.GetValue<string>() ?? "";
        ret.language = node?["language"]?.GetValue<string>() ?? "";
        ret.note = node?["note"]?.GetValue<string>() ?? "";
        ret.status = node?["status"]?.GetValue<string>() ?? "";
        ret.buildStdOut = node?["build_stdout"]?.GetValue<string>() ?? "";
        ret.buildStdError = node?["build_stderr"]?.GetValue<string>() ?? "";
        ret.buildExitCode = node?["build_exit_code"]?.GetValue<int>() ?? 0;
        ret.buildTime = node?["build_time"]?.GetValue<string>() ?? "";
        ret.buildMemory = node?["build_memory"]?.GetValue<int>() ?? 0;
        ret.buildResult = node?["build_result"]?.GetValue<string>() ?? "";
        ret.stdOut = node?["stdout"]?.GetValue<string>() ?? "";
        ret.stdError = node?["stderr"]?.GetValue<string>() ?? "";
        ret.exitCode = node?["exit_code"]?.GetValue<int>() ?? 0;
        ret.time = node?["time"]?.GetValue<string>() ?? "";
        ret.memory = node?["memory"]?.GetValue<int>() ?? 0;
        ret.connections = node?["connections"]?.GetValue<int>() ?? 0;
        ret.result = node?["result"]?.GetValue<string>() ?? "";

        return ret;
    }
}
