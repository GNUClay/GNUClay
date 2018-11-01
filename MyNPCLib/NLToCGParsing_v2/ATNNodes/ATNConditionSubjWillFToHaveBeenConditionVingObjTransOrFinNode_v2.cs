using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeAction(ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Been_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

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

