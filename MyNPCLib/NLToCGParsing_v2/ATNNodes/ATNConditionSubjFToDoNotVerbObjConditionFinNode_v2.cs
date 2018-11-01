using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotVerbObjConditionFinNodeAction(ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToDoNotVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotVerbObjConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotVerbObjConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToDoNotVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Verb_Obj_Condition_Fin;

        public ATNConditionSubjFToDoNotVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotVerbObjConditionFinNodeAction mInitAction;

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

