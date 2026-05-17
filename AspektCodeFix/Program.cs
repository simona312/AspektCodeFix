using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\levko\source\repos\AspektCodeFix\TestDirectory";

        List<string> txtFiles = new List<string>();

        GetTxtFiles(directoryPath, txtFiles);

        foreach (var file in txtFiles)
        {
            AppendTextToFile(file, "ASPEKT");
        }

        Console.WriteLine("Done.");
    }

    static void GetTxtFiles(string directoryPath, List<string> txtFiles)
    {
        string[] files = Directory.GetFiles(directoryPath, "*.txt");

        txtFiles.AddRange(files);

        string[] subdirectories = Directory.GetDirectories(directoryPath);

        foreach (string subdirectory in subdirectories)
        {
            GetTxtFiles(subdirectory, txtFiles);
        }
    }

    static void AppendTextToFile(string filePath, string textToAppend)
    {
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(textToAppend);
        }
    }
}
