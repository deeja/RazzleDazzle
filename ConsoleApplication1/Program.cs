namespace RazzleDazzle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using HedgehogDevelopment.Razl;
    using HedgehogDevelopment.Razl.CommandLine;
    using HedgehogDevelopment.Razl.CommandLine.OperationRunners;


    class Program
    {
        static readonly ICommandRunner[] CommandRunners = {
            new CopyAllRunner(),
            new CopyItemRunner(),
            new CopyHistoryRunner(),
            new CopyVersionRunner(),
            new DeleteItemRunner(),
            new MoveItemRunner(),
            new SetFieldValueRunner(),
            new SetPropertyValueRunner()
        };

        // private static ILog Log => log4net.LogManager.GetLogger("main");

        static void Main(string[] args)
        {
            Console.WriteLine("RAZZLE DAZZLE!!");
            Console.WriteLine("Usage: razzledazzle.exe SCRIPTPATH");


            int exitCode;
            try
            {
                exitCode = RunTool(args.FirstOrDefault());
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error! " + exception);
                exitCode = 11;
            }

            Environment.Exit(exitCode);
        }

        private static int RunTool(string scriptFile)
        {
            if (string.IsNullOrEmpty(scriptFile))
            {
                Console.WriteLine("No script file specified");
                return 1;
            }

            if (!File.Exists(scriptFile))
            {
                Console.WriteLine($"Script file not found: '{scriptFile}'");
                return 2;
            }

            ExecuteScript(scriptFile);
            return 0;
        }

        private static void ExecuteScript(string scriptFile)
        {
            var commandLineParser = new HedgehogDevelopment.Razl.CommandLine.CommandParsers.XmlParser();
            var operations = commandLineParser.GetCommands(new Dictionary<string, string> { { "/script", scriptFile } });
            foreach (Operation operation in operations)
            {
                Operation command = operation;
                ICommandRunner commandRunner = CommandRunners.FirstOrDefault(x => x.Operation == command.Name);
                commandRunner?.Run(command);
            }
        }


    }
}
