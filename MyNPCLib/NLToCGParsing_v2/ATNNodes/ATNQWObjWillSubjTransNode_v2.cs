using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjTransNodeAction(ATNQWObjWillSubjTransNode_v2 item);

    public class ATNQWObjWillSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjTransNodeFactory_v2(ATNQWObjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjTransNodeFactory_v2(ATNQWObjWillSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillTransNode_v2 mParentNode;
        private ATNQWObjWillSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_Verb_TransOrFin
    QWObj_Will_Subj_Be_Trans
    QWObj_Will_Subj_FToHave_Trans
    QWObj_Will_Subj_Condition_Trans
*/

    public class ATNQWObjWillSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjTransNode_v2 sameNode, InitATNQWObjWillSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Trans;

        public ATNQWObjWillTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjTransNode_v2 mSameNode;
        private InitATNQWObjWillSubjTransNodeAction mInitAction;

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

