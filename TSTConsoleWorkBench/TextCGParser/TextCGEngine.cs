﻿using GnuClay.CommonUtils.CG;
using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextCGEngine
    {
        public TextCGEngine()
        {
            mContext = CreateContext();
        }

        TextParsingLexerContex mContext = null;

        public List<CGNode> Run(string text)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Run text = {text}");

            var tmpLexer = new ExtendTextLexer(text.ToLower().Trim(), mContext);

            ExtendToken CurrToken = null;

            var tokens = new List<ExtendToken>();

            while ((CurrToken = tmpLexer.GetToken()) != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(CurrToken);

                tokens.Add(CurrToken);
            }

            var parser = new ATNParser(tokens);

            parser.Run();

            var result = parser.Result;

            var semanticAnalyzer = new SemanticAnalyzer(result, mContext.Engine);
            semanticAnalyzer.Run();

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");

            return semanticAnalyzer.Result;
        }

        private TextParsingLexerContex CreateContext()
        {
            var engine = new GnuClayEngine();

            var context = new TextParsingLexerContex(engine);

            var dataDictionary = context.Engine.DataDictionary;

            InitWordsDb(context);

            dataDictionary.TSTDump();

            return context;
        }

        private void InitWordsDb(TextParsingLexerContex context)
        {
            var engine = context.Engine;

            var queryStr = "INSERT {>: {entity(animate)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {entity(physobj)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {animate(animal)}}, {>: {physobj(animal)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {animal(person)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(the, article)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(dog, noun)}}, { >: {number(dog, singular)}}, {>: {animal(dog)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(like, verb)}}, { >: {tense(like, present)}}, {>: {state(like)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(likes, verb)}}, { >: {tense(likes, present)}}, {>: {root(likes, like)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(man, noun)}}, { >: {number(man, singular)}}, {>: {animal(man)}}";
            engine.Query(queryStr);
        }
    }
}
