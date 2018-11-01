using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoConditionVerbObjConditionFinNodeAction(ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjFToDoConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoConditionVerbObjConditionFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoConditionVerbObjConditionFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjFToDoConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Condition_Verb_Obj_Condition_Fin;

        public ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoConditionVerbObjConditionFinNodeAction mInitAction;

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

