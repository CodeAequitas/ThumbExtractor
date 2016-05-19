using System;
using System.IO;
using System.Threading;
using Fclp;
using ThumbExtractor.Engine;

namespace ThumbExtractor.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new Core();
            core.OnStatusUpdate += OnStatusUpdate;

            var parser = new FluentCommandLineParser<Options>();

            parser.Setup(arg => arg.ThumbDB)
                .As('t', "thumbDB")
                .WithDescription("Thumb.db file used for extracting images")
                .Required();

            parser.Setup(arg => arg.OutputDirectory)
                .As('o', "out")
                .WithDescription("Output directory for extracted images");

            parser.SetupHelp("?", "help", "h").Callback(() =>
            {
                Console.WriteLine("ThumbExtractor v0.1 (c) 2016 Code Aequitas");
                Console.WriteLine("www.code-aequitas.com");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Usage:");
                Console.WriteLine("CLI.exe -t[--thumb][/thumb]      specifies the thumb.db input file");
                Console.WriteLine("CLI.exe -o[--out][/out]          specifies an output directory");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            });

            var result = parser.Parse(args);

            if (result.HasErrors)
            {
                parser.HelpOption.ShowHelp(parser.Options);
                return;
            }

            if (!File.Exists(parser.Object.ThumbDB))
            {
                parser.HelpOption.ShowHelp(parser.Options);
                core.Log.Error("Thumb.db file does not exist: {0}", parser.Object.ThumbDB);
                Console.WriteLine("[ERROR]: Input file does not exist: {0}", parser.Object.ThumbDB);
                return;
            }

            var outputDirectory = parser.Object.OutputDirectory ?? Path.Combine(Environment.CurrentDirectory, "Output");

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            var tokenSource = new CancellationTokenSource();
            var ct = tokenSource.Token;

            parser.Object.OutputDirectory = outputDirectory;
            parser.Object.ConsoleTarget = true;

            var task = core.Process(parser.Object, ct);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    core.Log.Info("Extraction abort requested by user.");
                    tokenSource.Cancel();
                }

                try
                {
                    if (!task.Wait(150))
                    {
                        continue;
                    }

                    break;
                }
                catch (Exception e)
                {
                    core.Log.Error(e, "[INFO] Extraction cancelled by user.");
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void OnStatusUpdate(object sender, string s)
        {
            Console.WriteLine(s);
        }
    }
}
