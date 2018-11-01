using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeAction(ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_FToHave_Been_Ving_Condition_Fin
*/

    public class ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Ving_TransOrFin;

        public ATNQWObjWillSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenVingTransOrFinNodeAction mInitAction;

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

