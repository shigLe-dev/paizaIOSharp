using System;
namespace paizaIOSharp;

public struct Result
{
    public string id { get; internal set; }
    public string language { get; internal set; }
    public string note { get; internal set; }
    public string status { get; internal set; }
    public string buildStdOut { get; internal set; }
    public string buildStdError { get; internal set; }
    public string buildExitCode { get; internal set; }
    public string buildTime { get; internal set; }
    public string buildMemory { get; internal set; }
    public string buildResult { get; internal set; }
    public string stdOut { get; internal set; }
    public string stdError { get; internal set; }
    public string exitCode { get; internal set; }
    public string time { get; internal set; }
    public string memory { get; internal set; }
    public string connections { get; internal set; }
    public string result { get; internal set; }
}
