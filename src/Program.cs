using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Building Advent of Code for {args[0]}...\n");
        Console.WriteLine("Languages Included:");
        for (int i = 1; i < args.Length; i++)
        {
            Console.WriteLine($"\tAdding {args[i]}...");
        }
        
        Console.WriteLine("\n");

        for (int i = 1; i <= 25; i++)
        {
            Console.WriteLine($"Building Day {i}...\n");

            Directory.CreateDirectory($"../{args[0]}/Day_{i}");
            
            File.Create($"../{args[0]}/Day_{i}/input.txt");
            File.Create($"../{args[0]}/Day_{i}/test.txt");
            
            if (args.Contains("C#"))
            {
                ScaffoldCSharp(args[0], i);
            }
            //
            if (args.Contains("JS"))
            {
                ScaffoldJavaScript(args[0], i);
            }
            
            Console.WriteLine($"Day {i} built.\n");
        }

        Console.WriteLine($"Advent of Code {args[0]} build complete!");
    }

    private static void ScaffoldCSharp(string year, int day)
    {
        Console.WriteLine("\tAdding C# solution...\n");

        string directoryPath = $"../{year}/Day_{day}/C#";
        Directory.CreateDirectory(directoryPath);
        
        string command = "dotnet new console";
        
        ProcessStartInfo processStartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c cd {directoryPath} && {command}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        using (Process? process = Process.Start(processStartInfo))
        {
            if (process != null)
            {
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
            }
        }
    }

    private static void ScaffoldJavaScript(string year, int day)
    {
        Console.WriteLine("\tAdding JS file...\n");

        Directory.CreateDirectory($"../{year}/Day_{day}/JS");
        File.Create($"../{year}/Day_{day}/JS/solution.js");
    }
}