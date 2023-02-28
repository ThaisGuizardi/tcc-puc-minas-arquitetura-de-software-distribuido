using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace MenuFacile.Mvc.Services
{
    public static class LogFile
    {
        public static void AddLogFile(ILogger logger, LogLevel logLevel)
        {
            // Create a string with a line of text.
            string text = "First line" + Environment.NewLine;

            // Set a variable to the Documents path.
            
            string docPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "LogFileMvc.txt");

            // Write the text to a new file named "WriteFile.txt".
            File.WriteAllText(Path.Combine(docPath, string.Empty), text);

            // Create a string array with the additional lines of text
            string[] lines = { "New line 1", "New line 2" };

            // Append new lines of text to the file
            File.AppendAllLines(Path.Combine(docPath, string.Empty), lines);
        }
    }
}
