using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionVerbTransOrFinNodeAction(ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjWillConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Condition_Verb_Obj_TransOrFin
    Condition_QWSubj_Will_Condition_Verb_No_Trans
    Condition_QWSubj_Will_Condition_Verb_Condition_Fin
*/

    public class ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Verb_TransOrFin;

        public ATNConditionQWSubjWillConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionVerbTransOrFinNodeAction mInitAction;

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

