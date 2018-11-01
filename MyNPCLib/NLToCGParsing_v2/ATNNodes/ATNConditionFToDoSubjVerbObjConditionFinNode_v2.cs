using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjVerbObjConditionFinNodeAction(ATNConditionFToDoSubjVerbObjConditionFinNode_v2 item);

    public class ATNConditionFToDoSubjVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjVerbObjConditionFinNodeFactory_v2(ATNConditionFToDoSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjVerbObjConditionFinNodeFactory_v2(ATNConditionFToDoSubjVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoSubjVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToDoSubjVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbObjConditionFinNode_v2 sameNode, InitATNConditionFToDoSubjVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Verb_Obj_Condition_Fin;

        public ATNConditionFToDoSubjVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToDoSubjVerbObjConditionFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

