using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeAction(ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_FToHave_Been_Condition_Ving_TransOrFin
    Condition_QWObj_Will_Subj_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Been_Condition_Trans;

        public ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveBeenConditionTransNodeAction mInitAction;

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

