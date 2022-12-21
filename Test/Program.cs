using System.Text;
using paizaIOSharp;
using System.Text.Json.Nodes;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(PaizaIO.GetStatus(PaizaIO.CreateRunner("Console.WriteLine(\"aiueo\")", "csharp", "")));
    }
}
