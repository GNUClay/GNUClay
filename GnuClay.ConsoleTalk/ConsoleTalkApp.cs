using GnuClay.CommonClientTypes;
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

            mEntityConnection = mServerConnection.ConnectToEntity(mEntityName);
        }

        private string mEntityName = "#0813940A-EAC6-47E7-BF57-9B8C05E2168A";
        private IGnuClayServerConnection mServerConnection = null;
        private IGnuClayEntityConnection mEntityConnection = null;
        private ConsoleTalkAppConfig mConfig = null;
        private string mConfigFileName = "config.json";

        private void LoadConfig()
        {
            if(File.Exists(mConfigFileName))
            {
                using (var fileStream = new FileStream(mConfigFileName, FileMode.Open, FileAccess.Read))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var content = streamReader.ReadToEnd();

                        mConfig = JsonConvert.DeserializeObject<ConsoleTalkAppConfig>(content);
                    }
                }
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
            Console.WriteLine("begin loading...");
            mServerConnection.Load(mConfig.AutoSavedDumpName);
            Console.WriteLine("dump was loaded successfully");
        }

        private void SaveDefaultDump()
        {
            Console.WriteLine("begin saving...");
            mServerConnection.Save(mConfig.AutoSavedDumpName);
            Console.WriteLine("dump was saved successfully");
        }

        public void Dispose()
        {
            mServerConnection.Dispose();
        }

        public void Run()
        {
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

                if(tmpFirstStr.StartsWith("clear"))
                {
                    ProcessClear();
                    continue;
                }

                if (tmpFirstStr.StartsWith(SaveCommandName))
                {
                    ProcessSave(tmpStr);
                    continue;
                }

                if (tmpFirstStr.StartsWith(LoadCommandName))
                {
                    ProcessLoad(tmpStr);
                    continue;
                }

                ProcessQuery(tmpStr);
            }
        }

        private string SaveCommandName = "save";
        private int SaveCommandNameLength = 4;
        private string LoadCommandName = "load";
        private int LoadCommandNameLength = 4;

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
            Console.WriteLine("eas - enable auto saving. The state of this program will be saved, when command exit will be executed;");
            Console.WriteLine("das - disable auto saving;");
            Console.WriteLine("isas - print a state of the auto saving. true if enabled. false if disabled;");
            Console.WriteLine("clear - reset current state. Remove all rules, facts and other information;");
            Console.WriteLine("load - load a state of the program from default dump;");
            Console.WriteLine("load <file name> - load a state of the program from file by the file name;");
            Console.WriteLine("save - save a state of the program to default dump;");
            Console.WriteLine("save <file name> - save a state of the program to file with the file name;");
            Console.WriteLine("exit - exit from this program;");
            Console.WriteLine("type queries and this program execute its;");
            Console.WriteLine(" ");
        }

        private void ProcessQuery(string queryText)
        {
            try
            {
                var tmpResult = mEntityConnection.Query(queryText);
                if(tmpResult == null)
                {
                    Console.WriteLine("yess");
                    Console.WriteLine(" ");
                    return;
                }

                Console.WriteLine(SelectResultDebugHelper.ConvertToString(tmpResult, mEntityConnection));
            }
            catch(Exception e)
            {
                Console.Write("Error: ");
                Console.WriteLine(e.Message);
            }
        }

        private void PrintNotSupportedMessage()
        {
            Console.WriteLine("This command is not supported yet");
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
            Console.WriteLine(mConfig.EnabledAutoSave ? "yes" : "no");
        }

        private void ProcessClear()
        {
            mEntityConnection.Clear();
        }

        private void ProcessSave(string queryText)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSave queryText = `{queryText}`");

            var dumpName = queryText.Remove(0, SaveCommandNameLength);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSave dumpName = `{dumpName}`");

            if(string.IsNullOrWhiteSpace(dumpName))
            {
                SaveDefaultDump();
                return;
            }

            mEntityConnection.Save(dumpName);
        }

        private void ProcessLoad(string queryText)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLoad queryText = `{queryText}`");

            var dumpName = queryText.Remove(0, LoadCommandNameLength);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSave dumpName = `{dumpName}`");

            if (string.IsNullOrWhiteSpace(dumpName))
            {
                LoadDefaultDump();
                return;
            }

            mEntityConnection.Load(dumpName);
        }
    }
}
