﻿using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ObjectTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public ObjectTargetOfATNSlaveNAPNode(VerbPhrase_v2 verbPhrase)
        {
            mVerbPhrase = verbPhrase;
        }

        private VerbPhrase_v2 mVerbPhrase;

        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsBaseWordPhrase;

            if(wordNode == null)
            {
                throw new ArgumentNullException(nameof(wordNode));
            }

            NSetNode(wordNode, context);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
#if DEBUG
            //LogInstance.Log($"node = {node}");
#endif

            var wordNode = node.AsBaseWordPhrase;

            var actualTarget = context.GetByRunTimeSessionKey<VerbPhrase_v2>(mVerbPhrase);

            var itemsList = actualTarget.ObjectsList;

            if (itemsList.Count > 0)
            {
                var lastNode = itemsList.Last();
                itemsList.Remove(lastNode);
            }

            NSetNode(wordNode, context);
        }

        private void NSetNode(BaseWordPhrase_v2 wordNode, ContextOfATNParsing_v2 context)
        {
#if DEBUG
            //LogInstance.Log($"wordNode = {wordNode}");
            //LogInstance.Log($"context = {context}");
#endif

            var actualTarget = context.GetByRunTimeSessionKey<VerbPhrase_v2>(mVerbPhrase);

            actualTarget.ObjectsList.Add(wordNode);

#if DEBUG
            //LogInstance.Log($"context = {context}");
#endif
        }

        public void ResetNodes(ContextOfATNParsing_v2 context)
        {
            var actualTarget = context.GetByRunTimeSessionKey<VerbPhrase_v2>(mVerbPhrase);

            actualTarget.ObjectsList.Clear();
        }
    }
}
