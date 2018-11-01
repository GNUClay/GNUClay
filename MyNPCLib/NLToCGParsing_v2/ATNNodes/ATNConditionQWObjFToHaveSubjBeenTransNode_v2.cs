using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenTransNodeAction(ATNConditionQWObjFToHaveSubjBeenTransNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenTransNodeFactory_v2(ATNConditionQWObjFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenTransNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjTransNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToHave_Subj_Been_Ving_TransOrFin
    Condition_QWObj_FToHave_Subj_Been_V3_TransOrFin
    Condition_QWObj_FToHave_Subj_Been_Condition_Trans
*/

    public class ATNConditionQWObjFToHaveSubjBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenTransNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_Trans;

        public ATNConditionQWObjFToHaveSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenTransNodeAction mInitAction;

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

