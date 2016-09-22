using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TortoiseDiffPatcher
{
    /*
     * Removes duplicate sections from a TortoiseSVN Patch
     * and writes a new file in the same directory as the original.
     */
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.Write("Please specify the full file path of the diff");
                Console.WriteLine(" you want cleaned up as a command line parameter.");
                Console.WriteLine();
                Console.Write("Example: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"TortoiseDiffPatcher.exe C:\somefolder\mydiff.patch");
                Console.ResetColor();
                Console.WriteLine(@"Press the ""Enter"" key to exit.");
                Console.ReadLine();
                Environment.Exit(-1);
            }

            if(!File.Exists(args[0]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to find file at location: " + args[0]);
                Console.WriteLine(@"Press the ""Enter"" key to exit.");
                Console.ReadLine();
                Environment.Exit(-1);
            }

            try
            {
                Console.WriteLine("Attempting to parse file located at: " + args[0]);
                DeDuplicator myDeDuplicator = new DeDuplicator(args[0]);
                myDeDuplicator.Init();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File parsed successfully check for your new file in your current directory.");
                Console.WriteLine(@"Press the ""Enter"" key to exit.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                Console.ResetColor();
                Console.WriteLine("Unfortuantely an exception was thrown, the error was:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(@"Press the ""Enter"" key to exit.");
                Environment.Exit(-1);
            }
        }
    }
}
