using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenVingObjTransOrFinNodeAction(ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenVingObjTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenVingObjTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_Ving_Obj_Condition_Fin
*/

    public class ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Ving_Obj_TransOrFin;

        public ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenVingObjTransOrFinNodeAction mInitAction;

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

