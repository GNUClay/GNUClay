using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionTransNodeAction(ATNConditionTransNode_v2 item);

    public class ATNConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionTransNodeFactory_v2(ATNConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Trans
    Condition_FToDo_Trans
    Condition_QWSubj_Trans
    Condition_QWObj_Trans
    Condition_Will_Trans
    Condition_FToBe_Trans
    Condition_FToHave_Trans
    Condition_ModalVerb_Trans
    Condition_Verb_TransOrFin
    Condition_There_Trans
    Condition_Condition_Trans
*/

    public class ATNConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 sameNode, InitATNConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNConditionTransNode_v2 mSameNode;
        private InitATNConditionTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

