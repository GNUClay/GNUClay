using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveBeenTransNodeAction(ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenTransNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenTransNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_FToHave_Been_Ving_TransOrFin
    Condition_QWObj_Will_Subj_FToHave_Been_V3_TransOrFin
    Condition_QWObj_Will_Subj_FToHave_Been_Condition_Trans
*/

    public class ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Been_Trans;

        public ATNConditionQWObjWillSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveBeenTransNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveBeenTransNodeAction mInitAction;

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

