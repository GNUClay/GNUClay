using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingV3NoObjTransOrFinNodeAction(ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2 item);

    public class ATNSubjFToBeBeingV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingV3NoObjTransOrFinNodeFactory_v2(ATNSubjFToBeBeingV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingV3NoObjTransOrFinNodeFactory_v2(ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeBeingV3NoTransNode_v2 mParentNode;
        private ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Being_V3_No_Obj_Condition_Fin
*/

    public class ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2 sameNode, InitATNSubjFToBeBeingV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_V3_No_Obj_TransOrFin;

        public ATNSubjFToBeBeingV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeBeingV3NoObjTransOrFinNodeAction mInitAction;

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

