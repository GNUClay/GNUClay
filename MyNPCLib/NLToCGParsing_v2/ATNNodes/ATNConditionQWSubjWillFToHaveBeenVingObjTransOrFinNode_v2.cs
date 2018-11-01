using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeAction(ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_Been_Ving_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Been_Ving_Obj_TransOrFin;

        public ATNConditionQWSubjWillFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

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

