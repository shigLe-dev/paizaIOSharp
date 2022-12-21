using paizaIOSharp;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(PaizaIO.Run("print(\"aaaaa\")", "python3").stdOut);
    }
}
