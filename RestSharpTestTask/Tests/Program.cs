using GitLabAPI.Features;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static GitLabAPI.GlobalParameters;

namespace Tests
{
    public class Program
    {
        public static string filePath = GetFilePath.GetPath(_nunitConsolePath);
        public static string tests = GetFilePath.GetPath(_testPath);
        public static string logs = GetFilePath.GetPath("Logs");
        public static string report = GetFilePath.GetPath("Reports");

        public static void Main(string[] args)
        {
            if (Directory.Exists(logs)) Directory.Delete(logs, true);

            var processInfo = new ProcessStartInfo { FileName = filePath, Arguments = tests };
            var process = new Process { StartInfo = processInfo };

            process.Start();
            process.WaitForExit();

            GenerateReport(logs, report);
            OpenReport(report);
        }

        public void Run(string filePath, string testFilePath, string[] args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = filePath,
                Arguments = $"{ testFilePath } { string.Join(" ", args.Where(arg => !string.IsNullOrEmpty(arg))) }"
            };

            var process = new Process
            {
                StartInfo = processInfo
            };

            process.Start();
            process.WaitForExit();
        }

        public static void GenerateReport(string logs, string output)
        {
            if (Directory.Exists(output)) Directory.Delete(output, true);

            var info = new ProcessStartInfo
            {
                Arguments = $"/C allure generate {logs} -o {output}",
                FileName = Environment.GetEnvironmentVariable("COMSPEC")

            };

            var process = new Process
            {
                StartInfo = info
            };

            var env = Environment.GetEnvironmentVariables();

            process.Start();
            process.WaitForExit();
        }

        public static void OpenReport(string output)
        {
            Process.Start(string.Concat(output, _allureReport));
        }
    }
}