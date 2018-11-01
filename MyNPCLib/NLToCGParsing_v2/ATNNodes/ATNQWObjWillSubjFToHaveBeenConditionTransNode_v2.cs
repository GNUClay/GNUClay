using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenConditionTransNodeAction(ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionTransNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionTransNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_FToHave_Been_Condition_Ving_TransOrFin
    QWObj_Will_Subj_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Condition_Trans;

        public ATNQWObjWillSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenConditionTransNodeAction mInitAction;

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

