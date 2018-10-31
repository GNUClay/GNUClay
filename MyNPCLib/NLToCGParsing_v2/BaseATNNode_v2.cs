using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public abstract class BaseATNNode_v2
    {
        public BaseATNNode_v2(ContextOfATNParsing_v2 context)
        {
            Context = context;
        }

        public ContextOfATNParsing_v2 Context { get; private set; }

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

        private void ProcessTasks()
        {
            if(mTasksList.Count == 0)
            {
                return;
            }

            foreach (var task in mTasksList)
            {
                var newContext = Context.Fork();
                var node = task.Create(newContext);
                node.Run();
            }
        }
    }
}
