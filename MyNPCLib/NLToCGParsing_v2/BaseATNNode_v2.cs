﻿using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public abstract class BaseATNNode_v2
    {
        public BaseATNNode_v2(ContextOfATNParsing_v2 context, ATNExtendedToken token)
        {
            Context = context;
            Token = token;
        }

        public ContextOfATNParsing_v2 Context { get; private set; }
        public ATNExtendedToken Token { get; private set; }
        public abstract StateOfATNParsing_v2 GlobalState { get; }

        public void Run()
        {
            ImplementGoalToken();
            ProcessNextToken();
            ProcessTasks();
        }

        protected abstract void ImplementGoalToken();
        protected abstract void ProcessNextToken();

        private List<BaseATNNodeFactory_v2> mTasksList = new List<BaseATNNodeFactory_v2>();

        protected void AddTask(BaseATNNodeFactory_v2 factory)
        {
            mTasksList.Add(factory);
        }

        private bool mIsSuccess = true;

        private void ProcessTasks()
        {
            if(mTasksList.Count == 0)
            {
                return;
            }

            if(mIsSuccess)
            {
                foreach (var task in mTasksList)
                {
                    var newContext = Context.Fork();
                    var node = task.Create(newContext);
                    node.Run();
                }
            }
        }

        protected void SetAsSuccess(bool result)
        {
            mIsSuccess = result;
        }

        protected IList<ATNExtendedToken> GetСlusterOfExtendedTokens()
        {
            return Context.GetСlusterOfExtendedTokens();
        }

        protected Sentence_v2 Sentence
        {
            get
            {
                return Context.Sentence;
            }
        }
    }
}
