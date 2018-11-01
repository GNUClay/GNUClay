using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeAction(ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoConditionVerbObjConditionFinNodeAction mInitAction;

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

