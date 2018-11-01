using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionVerbObjTransOrFinNodeAction(ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Verb_Obj_TransOrFin;

        public ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionVerbObjTransOrFinNodeAction mInitAction;

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

