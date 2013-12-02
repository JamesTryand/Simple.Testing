using Simple.Testing.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Testing.Documentation
{
    public class TestReporter
    {
        public static IEnumerable<string> WriteReport(string[] args)
        {
            return args.SelectMany(x => TestReporter.PrintSpecs(SimpleRunner.RunAllInAssembly(x)));
        }

        public static IEnumerable<string> PrintSpecs(IEnumerable<RunResult> results)
        {
            foreach (RunResult runResult in results)
            {
                yield return PrintSpec(runResult);
            }
        }

        private static string FormatName(string name)
        {
            return name.Contains('_')
                ? name.Replace('_', ' ')
                : CleanupCamelCasing(name);           
        }

        private static string CleanupCamelCasing(string name)
        {
            return System.Text.RegularExpressions.Regex.Replace(name,
            "([A-Z])",
            " $1",
            System.Text.RegularExpressions.RegexOptions.Compiled
            ).Trim();
        }

        public static string PrintSpec(RunResult result)
        {
            var console = new StringBuilder();
            var passed = result.Passed ? "*Passed*" : "**Failed**";
            var testname = "### " + FormatName(result.Name) + " - " + passed;
            console.AppendLine(new string('-', testname.Length));
            console.AppendLine(testname);
            console.AppendLine();
            var on = result.GetOnResult();
            if (on != null)
            {
                console.AppendLine();
                console.AppendLine("On:");
                console.AppendLine(on.ToString());
                console.AppendLine();
            }
            if (result.Result != null)
            {
                console.AppendLine();
                console.AppendLine("Results with:");
                if (result.Result is Exception)
                    console.AppendLine(result.Result.GetType() + "\n" + ((Exception)result.Result).Message);
                else
                    console.AppendLine(result.Result.ToString());
                console.AppendLine();
            }

            console.AppendLine("Expectations:");
            foreach (var expecation in result.Expectations)
            {
                if (expecation.Passed)
                    console.AppendLine(">\t" + expecation.Text + " " + (expecation.Passed ? "*Passed*" : "**Failed**"));
                else
                    console.AppendLine("> " + expecation.Exception.Message);
            }
            if (result.Thrown != null)
            {
                console.AppendLine("**Specification failed: " + result.Message + "**");
                console.AppendLine();
                console.AppendLine("> " + result.Thrown.ToString());
            }
            // console.AppendLine(new string('-', 80));
            Enumerable.Repeat<string>("",4).ForEach(i => console.AppendLine(i));
            
            return console.ToString();
        }

    }
}
