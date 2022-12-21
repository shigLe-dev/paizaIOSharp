using System.Text;
using paizaIOSharp;
using System.Text.Json.Nodes;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(paizaIO.GetStatus(paizaIO.CreateRunner("Console.WriteLine(\"aiueo\")", "csharp", "")));
    }
}
