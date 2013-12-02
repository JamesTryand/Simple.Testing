using Mono.Options;
using Simple.Testing.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Testing.Documentation.Generator
{
    public class Program
    {


        public static void Main(string[] args)
        {
            IDoWork worker;

            worker = new SimpleWorker();

            worker.Work(args);
        }
    }

    enum ReportFormat
    {
        Text,
        Json,
        Xml,
        Markdown

    }
    class FancyWorker : IDoWork
    {
        public FancyWorker()
        {

        }

        public void Work(string[] args)
        {


            string specificAssembly = "";
            string assemblySignature = "";

            string assemblyPath = "";
            bool showHelp = false;

            ReportFormat ReportFormat = ReportFormat.Text;


            var p = new OptionSet()
            {
                {"a|assembly","specify a specific assembly",v => specificAssembly = v}, 
                {"g|signature","specify an assembly signature (ie. *Tests.dll) ",v => assemblySignature = v}, 
                {"p|path","path to the assemblies",v => assemblyPath = v}, 
                //{"t|text","report in text format",v => ReportFormat = ReportFormat.Text},
                //{"j|json","report in text format",v => ReportFormat = ReportFormat.Json},
                //{"x|xml", "report in text format",v => ReportFormat = ReportFormat.Xml},
                //{"m|markdown","report in text format",v => ReportFormat = ReportFormat.Markdown},
                {"h|help", "show this help message and exit",v => showHelp = v != null}
            };
            if (string.IsNullOrWhiteSpace(assemblySignature))
            {
                specificAssembly = "*Tests.dll";
            }

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("greet: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }



            // Get the path ( or assume 'here' )

            // Get the specified assembly
            // Get the other assemblies


            string[] assemblies;

            assemblies = new[] { "" };// DO THE WORK HERE 

            IEnumerable<string> results;


            switch (ReportFormat)
            {
                case ReportFormat.Text:
                    results = assemblies.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x)));
                    break;
                case ReportFormat.Json:
                    results = assemblies.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x)));
                    break;
                case ReportFormat.Xml:
                    results = assemblies.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x)));
                    break;
                case ReportFormat.Markdown:
                    results = assemblies.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x)));
                    break;
                default:
                    results = assemblies.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x)));
                    break;
            }

            results.ForEach(x => Console.WriteLine(x));

            // Assume assemblies of the current working directory if no parameters are given.
            // Try doing this in json

        }
    }


    public interface IDoWork
    {
        void Work(string[] args);
    }

    class SimpleWorker : IDoWork
    {
        public void Work(string[] args)
        {
            args.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x))).ForEach(x => Console.WriteLine(x));
        }
    }
}