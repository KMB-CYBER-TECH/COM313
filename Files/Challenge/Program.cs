// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Setup directory and file paths
        string directoryName = "FileCollection";
        string resultFileName = "results.txt";

        // Ensure the directory exists
        if (!Directory.Exists(directoryName))
        {
            Console.WriteLine($"Directory '{directoryName}' does not exist.");
            return;
        }

        // Step 2: Create helper function for checking Office files
        bool IsOfficeFile(string fileName)
        {
            string[] officeExtensions = { ".xlsx", ".docx", ".pptx" };
            return officeExtensions.Contains(Path.GetExtension(fileName).ToLower());
        }

        // Step 3: Initialize counters and variables
        int excelFileCount = 0, wordFileCount = 0, pptFileCount = 0;
        long excelTotalSize = 0, wordTotalSize = 0, pptTotalSize = 0;

        // Step 4: Create DirectoryInfo object
        DirectoryInfo dirInfo = new DirectoryInfo(directoryName);

        // Step 5: Enumerate files in the directory
        foreach (var file in dirInfo.GetFiles())
        {
            if (IsOfficeFile(file.Name))
            {
                // Identify the file type based on extension and update counters/sizes
                switch (Path.GetExtension(file.Name).ToLower())
                {
                    case ".xlsx":
                        excelFileCount++;
                        excelTotalSize += file.Length;
                        break;
                    case ".docx":
                        wordFileCount++;
                        wordTotalSize += file.Length;
                        break;
                    case ".pptx":
                        pptFileCount++;
                        pptTotalSize += file.Length;
                        break;
                }
            }
        }

        // Step 6: Write the results to the output file
        using (StreamWriter writer = new StreamWriter(resultFileName))
        {
            writer.WriteLine("Office Files Summary:");
            writer.WriteLine("---------------------");
            writer.WriteLine($"Excel Files (.xlsx): {excelFileCount}, Total Size: {excelTotalSize / 1024} KB");
            writer.WriteLine($"Word Files (.docx): {wordFileCount}, Total Size: {wordTotalSize / 1024} KB");
            writer.WriteLine($"PowerPoint Files (.pptx): {pptFileCount}, Total Size: {pptTotalSize / 1024} KB");
            writer.WriteLine();
            writer.WriteLine($"Total Files: {excelFileCount + wordFileCount + pptFileCount}");
            writer.WriteLine($"Total Size: {(excelTotalSize + wordTotalSize + pptTotalSize) / 1024} KB");
        }

        Console.WriteLine("Summary has been written to results.txt");
    }
}
