using paizaIOSharp;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(PaizaIO.Run("print(\"aaaaa\")", Language.Python3).stdOut);
        Console.WriteLine(PaizaIO.RunAsync("print(\"bbbbb\")", Language.Python3).Result.stdOut);
        Console.WriteLine(PaizaIO.Run(@"
public class Hello{
    public static void Main(){
        System.Console.WriteLine(""Hello C#"");
    }
}
",
Language.CSharp).stdOut);
    }
}
