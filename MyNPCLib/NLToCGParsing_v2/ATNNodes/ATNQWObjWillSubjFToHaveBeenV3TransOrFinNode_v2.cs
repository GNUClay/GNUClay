using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeAction(ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_FToHave_Been_V3_Condition_Fin
*/

    public class ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_V3_TransOrFin;

        public ATNQWObjWillSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenV3TransOrFinNodeAction mInitAction;

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

