using paizaIOSharp;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        string id = "";
        Console.WriteLine(PaizaIO.GetStatus(id = PaizaIO.CreateRunner("print(\"aaaaa\")", "python3", "")));
        Thread.Sleep(4000);
        Console.WriteLine(PaizaIO.GetDetails(id).stdOut);
    }
}
