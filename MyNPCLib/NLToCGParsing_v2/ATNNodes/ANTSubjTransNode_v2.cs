using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitANTSubjTransNodeAction(ANTSubjTransNode_v2 item);

    public class ANTSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ANTSubjTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ANTSubjTransNodeFactory_v2(ANTSubjTransNode_v2 sameNode, ATNExtendedToken token, InitANTSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ANTSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitANTSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ANTSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ANTSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ANTSubjTransNode_v2: BaseATNNode_v2
    {
        public ANTSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ANTSubjTransNode_v2(ContextOfATNParsing_v2 context, ANTSubjTransNode_v2 sameNode, InitANTSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ANTSubjTransNode_v2 mSameNode;
        private InitANTSubjTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            LogInstance.Log($"N = {N}");
            LogInstance.Log($"Token = {Token}");
        }

        protected override void ProcessNextToken()
        {
            LogInstance.Log("Begin");

            if(Token.Content != "-")
            {
                AddTask(new ANTSubjTransNodeFactory_v2(this, new ATNExtendedToken()
                {
                    Content = "-"
                }, (ANTSubjTransNode_v2 item) => {
                    LogInstance.Log($"this == item = {this == item}");
                    item.N = 15;
                }));
            }
        }

        public int N;
    }
}
