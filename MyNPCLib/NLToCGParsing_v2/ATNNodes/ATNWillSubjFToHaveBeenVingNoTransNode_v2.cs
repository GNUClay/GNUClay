using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenVingNoTransNodeAction(ATNWillSubjFToHaveBeenVingNoTransNode_v2 item);

    public class ATNWillSubjFToHaveBeenVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNWillSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNWillSubjFToHaveBeenVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_Ving_No_Obj_TransOrFin
*/

    public class ATNWillSubjFToHaveBeenVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenVingNoTransNode_v2 sameNode, InitATNWillSubjFToHaveBeenVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Ving_No_Trans;

        public ATNWillSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenVingNoTransNodeAction mInitAction;

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

