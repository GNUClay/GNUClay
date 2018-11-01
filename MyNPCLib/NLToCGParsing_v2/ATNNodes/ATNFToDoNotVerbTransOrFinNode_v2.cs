using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoNotVerbTransOrFinNodeAction(ATNFToDoNotVerbTransOrFinNode_v2 item);

    public class ATNFToDoNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoNotVerbTransOrFinNodeFactory_v2(ATNFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoNotVerbTransOrFinNodeFactory_v2(ATNFToDoNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoNotTransNode_v2 mParentNode;
        private ATNFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Not_Verb_Obj_TransOrFin
    FToDo_Not_Verb_Condition_Fin
*/

    public class ATNFToDoNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotVerbTransOrFinNode_v2 sameNode, InitATNFToDoNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Not_Verb_TransOrFin;

        public ATNFToDoNotTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNFToDoNotVerbTransOrFinNodeAction mInitAction;

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

