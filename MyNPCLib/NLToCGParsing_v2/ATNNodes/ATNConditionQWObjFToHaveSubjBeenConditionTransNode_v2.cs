using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenConditionTransNodeAction(ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionTransNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionTransNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjBeenTransNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToHave_Subj_Been_Condition_Ving_TransOrFin
    Condition_QWObj_FToHave_Subj_Been_Condition_V3_TransOrFin
*/

    public class ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_Condition_Trans;

        public ATNConditionQWObjFToHaveSubjBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenConditionTransNodeAction mInitAction;

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

