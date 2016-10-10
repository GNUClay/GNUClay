using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ConsoleTalk
{
    public class ConsoleTalkApp
    {
        public ConsoleTalkApp()
        {
            mLogicalStorageExampleWrapper = new LogicalStorageExampleWrapper();
        }

        private LogicalStorageExampleWrapper mLogicalStorageExampleWrapper = null;

        public void Run()
        {
            PrintHello();

            while (true)
            {
                Console.Write("cnuclay ?: ");
                var tmpStr = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(tmpStr))
                {
                    continue;
                }

                var tmpL = 6;

                if(tmpStr.Length < 6)
                {
                    tmpL = tmpStr.Length;
                }

                var tmpFirstStr = tmpStr.Substring(0, tmpL).ToLower();

                if(tmpFirstStr.StartsWith("exit"))
                {
                    break;
                }

                if(tmpFirstStr.StartsWith("h"))
                {
                    PrintHelp();
                    continue;
                }

                if (tmpFirstStr.StartsWith("help"))
                {
                    PrintHelp();
                    continue;
                }

                if (tmpFirstStr.StartsWith("man"))
                {
                    PrintHelp();
                    continue;
                }

                if (tmpFirstStr.StartsWith("insert"))
                {
                    ProcessQuery(tmpStr);
                    continue;
                }

                if (tmpFirstStr.StartsWith("select"))
                {
                    ProcessQuery(tmpStr);
                    continue;
                }
            }
        }

        private void PrintHello()
        {
            Console.WriteLine("gnuclay (c)metatypeman 2016");
            Console.WriteLine(" ");
        }

        private void PrintHelp()
        {
            Console.WriteLine("h - print help;");
            Console.WriteLine("help - print help;");
            Console.WriteLine("man - print help;");
            Console.WriteLine("exit - exit from this program;");
            Console.WriteLine("type queries and this program execute its;");
            Console.WriteLine(" ");
        }

        private void ProcessQuery(string queryText)
        {
            try
            {
                var tmpResult = mLogicalStorageExampleWrapper.Query(queryText);
                if(tmpResult == null)
                {
                    Console.WriteLine("yess");
                    Console.WriteLine(" ");
                    return;
                }

                Console.WriteLine(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageExampleWrapper.DataDictionary));
            }
            catch(Exception e)
            {
                Console.Write("Error: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
