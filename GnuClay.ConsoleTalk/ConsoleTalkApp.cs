using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.LocalHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GnuClay.ConsoleTalk
{
    public class ConsoleTalkApp: IDisposable
    {
        public ConsoleTalkApp()
        {
            PrintHello();

            mServerConnection = new GnuClayLocalServer();
            
            LoadConfig();

            if(mConfig.EnabledAutoSave)
            {
                LoadDefaultDump();
            }

            mEntityConnection = mServerConnection.ConnectToNPC(mEntityName);

            mEntityConnection.AddLogHandler((IExternalValue value) => {
                var tmpSb = new StringBuilder();
                tmpSb.Append(mEntityConnection.GetValue(value.TypeKey));
                if(value.Value != null)
                {
                    tmpSb.Append($": {value.Value}");
                }

                var text = tmpSb.ToString();

                lock (mConsoleLock)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(text);
                    Console.ForegroundColor = mDefaultForegroundColor;
                }
            });
        }

        private string mEntityName = "#0813940A_EAC6_47E7_BF57_9B8C05E2168A";
        private IGnuClayServerConnection mServerConnection = null;
        private IGnuClayNPCConnection mEntityConnection = null;
        private ConsoleTalkAppConfig mConfig = null;
        private string mConfigFileName = "config.json";
        private object mConsoleLock = new object();

        private string ReadContent(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private void LoadConfig()
        {
            if(File.Exists(mConfigFileName))
            {
                var content = ReadContent(mConfigFileName);
                mConfig = JsonConvert.DeserializeObject<ConsoleTalkAppConfig>(content);
            }
            else
            {
                mConfig = new ConsoleTalkAppConfig();
            }
        }

        private void SaveConfig()
        {
            if (File.Exists(mConfigFileName))
            {
                File.Delete(mConfigFileName);
            }

            using (var fileStream = new FileStream(mConfigFileName, FileMode.Create, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.AutoFlush = true;

                    streamWriter.Write(JsonConvert.SerializeObject(mConfig));
                }
            }
        }

        private void LoadDefaultDump()
        {
            PrintMessageLine("begin loading...");
            mServerConnection.Load(mConfig.AutoSavedDumpName);
            PrintMessageLine("dump was loaded successfully");
        }

        private void SaveDefaultDump()
        {
            PrintMessageLine("begin saving...");
            mServerConnection.Save(mConfig.AutoSavedDumpName);
            PrintMessageLine("dump was saved successfully");
        }

        /// <summary>
        /// Stop and free all of internal resources.
        /// </summary>
        public void Dispose()
        {
            mServerConnection.Dispose();
        }

        private ConsoleColor mDefaultForegroundColor = ConsoleColor.White;
        private string mCommand;

        public void Run()
        {
            mDefaultForegroundColor = Console.ForegroundColor;

            var rx = new Regex("\\s+");

            while (true)
            {
                PrintMessage("gnuclay ?: ");

                mCommand = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(mCommand))
                {
                    continue;
                }

                mCommand = rx.Replace(mCommand, " ");

                var tmpL = 10;

                if(mCommand.Length < 6)
                {
                    tmpL = mCommand.Length;
                }

                var tmpFirstStr = mCommand.Substring(0, tmpL).ToLower();

                if(tmpFirstStr.StartsWith("exit"))
                {
                    if (mConfig.EnabledAutoSave)
                    {
                        SaveDefaultDump();
                    }

                    return;
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

                if(tmpFirstStr.StartsWith("eas"))
                {
                    ProcessEnableAutoSave();
                    continue;
                }

                if (tmpFirstStr.StartsWith("das"))
                {
                    ProcessDisableAutoSave();
                    continue;
                }

                if (tmpFirstStr.StartsWith("isas"))
                {
                    ProcessIsAutoSave();
                    continue;
                }

                if (tmpFirstStr.StartsWith("clear"))
                {
                    ProcessClear();
                    continue;
                }

                if (tmpFirstStr.StartsWith(CallFromCommandName))
                {
                    ProcessCallFrom();
                    continue;
                }

                if (tmpFirstStr.StartsWith(SaveCommandName))
                {
                    ProcessSave();
                    continue;
                }

                if (tmpFirstStr.StartsWith(LoadCommandName))
                {
                    ProcessLoad();
                    continue;
                }

                ProcessQuery(mCommand);
            }
        }

        private string SaveCommandName = "save";
        private string LoadCommandName = "load";
        private string CallFromCommandName = "call from";

        private void PrintErrorLine(string message)
        {
            lock (mConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = mDefaultForegroundColor;
            }
        }

        private void PrintMessage(string message)
        {
            lock (mConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(message);
                Console.ForegroundColor = mDefaultForegroundColor;
            }
        }

        private void PrintMessageLine(string message)
        {
            lock (mConsoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ForegroundColor = mDefaultForegroundColor;
            }
        }

        private void PrintHello()
        {
            var now = DateTime.Today.Year;

            PrintMessageLine($"gnuclay (c)metatypeman 2016 - {now}");
            Console.WriteLine(" ");
        }

        private void PrintHelp()
        {
            PrintMessageLine("h - print help;");
            PrintMessageLine("help - print help;");
            PrintMessageLine("man - print help;");
            PrintMessageLine("eas - enable auto saving. The state of this program will be saved, when command exit will be executed;");
            PrintMessageLine("das - disable auto saving;");
            PrintMessageLine("isas - print a state of the auto saving. true if enabled. false if disabled;");
            PrintMessageLine("clear - reset current state. Remove all rules, facts and other information;");
            PrintMessageLine("load - load a state of the program from default dump;");
            PrintMessageLine("load <file name> - load a state of the program from file by the file name;");
            PrintMessageLine("save - save a state of the program to default dump;");
            PrintMessageLine("save <file name> - save a state of the program to file with the file name;");
            PrintMessageLine("call from <file name> - load and execute set of queries from file;");
            PrintMessageLine("exit - exit from this program;");
            PrintMessageLine("Type queries and this program execute its;");
            Console.WriteLine(" ");
        }

        private void ProcessQuery(string queryText)
        {
            try
            {
                var tmpResult = mEntityConnection.Query(queryText);
                PrintMessageLine("Executed successfully");

                if (tmpResult == null)
                {
                    PrintMessageLine("yess");
                    Console.WriteLine(" ");
                    return;
                }

                lock (mConsoleLock)
                {
                    Console.WriteLine(SelectResultDebugHelper.ConvertToString(tmpResult, mEntityConnection));
                }   
            }
            catch(Exception e)
            {
                PrintErrorLine($"Error: {e.Message}");
                PrintErrorLine($"in query:");
                PrintErrorLine(mCommand);
            }
        }

        private void PrintNotSupportedMessage()
        {
            PrintErrorLine("This command is not supported yet");
        }
        
        private void ProcessEnableAutoSave()
        {
            mConfig.EnabledAutoSave = true;
            SaveConfig();
        }

        private void ProcessDisableAutoSave()
        {
            mConfig.EnabledAutoSave = true;
            SaveConfig();
        }

        private void ProcessIsAutoSave()
        {
            lock (mConsoleLock)
            {
                Console.WriteLine(mConfig.EnabledAutoSave ? "yes" : "no");
            }          
        }

        private void ProcessClear()
        {
            mEntityConnection.Clear();
        }

        private string GetCommandValue(string commandName)
        {
            return mCommand.Remove(0, commandName.Length).Trim();
        }

        private void ProcessCallFrom()
        {
            var fileName = GetCommandValue(CallFromCommandName);

            if (!File.Exists(fileName))
            {
                PrintErrorLine($"Error: File `{fileName}` is not exists!");
                return;
            }

            var content = ReadContent(fileName);
            ProcessQuery(content);
        }

        private void ProcessSave()
        {
            var dumpName = GetCommandValue(SaveCommandName);

            if(string.IsNullOrWhiteSpace(dumpName))
            {
                SaveDefaultDump();
                return;
            }

            mEntityConnection.Save(dumpName);
        }

        private void ProcessLoad()
        {
            var dumpName = GetCommandValue(LoadCommandName);
            if (string.IsNullOrWhiteSpace(dumpName))
            {
                LoadDefaultDump();
                return;
            }

            mEntityConnection.Load(dumpName);
        }
    }
}
