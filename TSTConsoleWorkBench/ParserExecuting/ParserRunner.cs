using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ParserExecuting
{
    public class ParserRunner : BaseRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";
                var result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");

                queryString = "SELECT{son(Piter,$X1)}";
                result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");
                
                queryString = "CALL { 1.0 + 2;}";
                result = GnuClayEngine.Context.ParserEngine.Parse(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"result = {result}");
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
