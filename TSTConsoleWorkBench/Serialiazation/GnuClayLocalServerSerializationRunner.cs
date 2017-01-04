﻿using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.LocalHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Serialiazation
{
    public class GnuClayLocalServerSerializationRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var mServerConnection = new GnuClayLocalServer();
                var mEntityName = "#0813940A-EAC6-47E7-BF57-9B8C05E2168A";

                var mEntityConnection = mServerConnection.ConnectToEntity(mEntityName);

                var queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

                mEntityConnection.Query(queryString);

                var fileName = "0813940A-EAC6-47E7-BF57-9B8C05E2168A.gcd";

                mEntityConnection.Save(fileName);

                var entity_2 = mServerConnection.CreateEntity();

                queryString = "SELECT{son(Piter,$X1)}";

                var qr_1 = entity_2.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_1 = {SelectResultDebugHelper.ConvertToString(qr_1, entity_2)}");

                entity_2.Load(fileName);

                var qr_2 = entity_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"qr_2 = {SelectResultDebugHelper.ConvertToString(qr_2, entity_2)}");

                entity_2.Clear();

                var qr_3 = entity_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"qr_3 = {SelectResultDebugHelper.ConvertToString(qr_3, entity_2)}");

                var entity_3 = mServerConnection.CreateEntity(mEntityConnection.Save());

                var qr_4 = entity_3.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"qr_4 = {SelectResultDebugHelper.ConvertToString(qr_4, entity_3)}");

                var targetServerStateName = @"c:\Users\Admin\Documents\GitHub\GNUClay\TSTConsoleWorkBench\bin\Debug\DataDir\TST_1";

                mServerConnection.Save(targetServerStateName);

                var tmpServer_2 = new GnuClayLocalServer();
                var tmpEntityConnection_2 = tmpServer_2.ConnectToEntity(mEntityName);

                var qr_5 = tmpEntityConnection_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"qr_5 = {SelectResultDebugHelper.ConvertToString(qr_5, tmpEntityConnection_2)}");

                tmpServer_2.Load(targetServerStateName);

                var qr_6 = tmpEntityConnection_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info($"qr_6 = {SelectResultDebugHelper.ConvertToString(qr_6, tmpEntityConnection_2)}");
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
