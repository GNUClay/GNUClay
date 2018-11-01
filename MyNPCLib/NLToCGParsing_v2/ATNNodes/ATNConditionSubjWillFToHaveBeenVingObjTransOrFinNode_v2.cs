using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeAction(ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Been_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Ving_Obj_TransOrFin;

        public ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

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

