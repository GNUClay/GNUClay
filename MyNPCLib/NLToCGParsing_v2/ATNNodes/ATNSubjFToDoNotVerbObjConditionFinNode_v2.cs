using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotVerbObjConditionFinNodeAction(ATNSubjFToDoNotVerbObjConditionFinNode_v2 item);

    public class ATNSubjFToDoNotVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotVerbObjConditionFinNodeFactory_v2(ATNSubjFToDoNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotVerbObjConditionFinNodeFactory_v2(ATNSubjFToDoNotVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToDoNotVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToDoNotVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbObjConditionFinNode_v2 sameNode, InitATNSubjFToDoNotVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Verb_Obj_Condition_Fin;

        public ATNSubjFToDoNotVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotVerbObjConditionFinNodeAction mInitAction;

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

