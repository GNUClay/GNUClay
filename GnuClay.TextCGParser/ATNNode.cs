using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class ATNNode : BaseATNNode
    {
        public ATNNode(TextPhraseContext context, ATNParser parent)
            : base(context, parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private ExtendToken CurrToken = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var state = mContext.State;

            NLog.LogManager.GetCurrentClassLogger().Info($"Run state = {state}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mContext = {mContext.ToDbgString()}");

            CurrToken = mContext.GetToken();

            NLog.LogManager.GetCurrentClassLogger().Info($"Run CurrToken = {CurrToken}");

            List<ExtendTokenGoal> goals = null;

            switch (state)
            {
                case ATNNodeState.Init:
                    goals = ExtendTokenToGoals(CurrToken);

                    if (goals.Count == 0)
                    {
                        return;
                    }

                    foreach (var goal in goals)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info($"Run goal = {goal}");

                        switch (goal)
                        {
                            case ExtendTokenGoal.NP:
                                var targetContext = mContext.Clone();

                                targetContext.State = ATNNodeState.NP;
                                targetContext.Recovery(CurrToken);

                                var targetNpContext = new ATNNPParserContext(targetContext);

                                var npParser = new ATNNPParser(targetNpContext);
                                npParser.Run();

                                var npResult = npParser.Result;

                                if (npResult.Count == 0)
                                {
                                    NLog.LogManager.GetCurrentClassLogger().Info("Run npResult.Count == 0");

                                    throw new NotImplementedException();
                                }
                                else
                                {
                                    foreach (var npItem in npResult)
                                    {
                                        NLog.LogManager.GetCurrentClassLogger().Info($"Run npItem = {npItem.ToDbgString()}");

                                        var targetContext_2 = targetContext.Clone();
                                        targetContext_2.AssignTokens(npItem.Context);

                                        targetContext_2.Subject = npItem.NP;

                                        var node = new ATNNode(targetContext_2, mParent);
                                        node.Run();
                                    }
                                }
                                break;

                            default: throw new ArgumentOutOfRangeException(nameof(goal), goal.ToString());
                        }
                    }
                    break;

                case ATNNodeState.NP:
                    goals = ExtendTokenToGoals(CurrToken);

                    if (goals.Count == 0)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("goals.Count == 0");

                        throw new NotImplementedException();
                    }

                    foreach (var goal in goals)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info($"Run goal = {goal}");

                        switch (goal)
                        {
                            case ExtendTokenGoal.V:
                                var targetContext = mContext.Clone();

                                targetContext.State = ATNNodeState.NP_V;

                                targetContext.Verb = CurrToken;

                                var node = new ATNNode(targetContext, mParent);
                                node.Run();
                                break;

                            default: throw new ArgumentOutOfRangeException(nameof(goal), goal.ToString());
                        }
                    }
                    break;

                case ATNNodeState.NP_V:
                    goals = ExtendTokenToGoals(CurrToken);

                    if (goals.Count == 0)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("goals.Count == 0");

                        throw new NotImplementedException();
                    }

                    foreach (var goal in goals)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info($"Run goal = {goal}");

                        switch (goal)
                        {
                            case ExtendTokenGoal.NP:
                                var targetContext = mContext.Clone();

                                targetContext.TailState = goal;
                                targetContext.Recovery(CurrToken);

                                var tailNode = new ATNTailNode(targetContext, mParent);
                                tailNode.Run();
                                break;

                            default: throw new ArgumentOutOfRangeException(nameof(goal), goal.ToString());
                        }
                    }
                    break;

                case ATNNodeState.NP_FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_Not_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToDo_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToDo_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToDo_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToDo_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Be:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Be:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Have:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Will_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Not_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Not_Able:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Not_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Not_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Able:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToBe_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToHave_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToHave_Not_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToHave_To:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_FToHave_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Must:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Must_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Must_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_May:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_May_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_May_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Might:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Might_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Might_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Can:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Can_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Can_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Could:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Could_V:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.PQW_Could_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.V:
                    throw new NotImplementedException();

                case ATNNodeState.V_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Do:
                    throw new NotImplementedException();

                case ATNNodeState.Do_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Do_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.Do_Not_V_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_Not_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.Must:
                    throw new NotImplementedException();

                case ATNNodeState.Must_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Must_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Must_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Must_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.May:
                    throw new NotImplementedException();

                case ATNNodeState.May_NP:
                    throw new NotImplementedException();

                case ATNNodeState.May_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.May_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.May_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Might:
                    throw new NotImplementedException();

                case ATNNodeState.Might_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Might_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Might_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Might_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Can:
                    throw new NotImplementedException();

                case ATNNodeState.Can_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Can_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Can_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Can_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Could:
                    throw new NotImplementedException();

                case ATNNodeState.Could_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Could_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Could_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Could_Not_NP_V:
                    throw new NotImplementedException();

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state.ToString());
            }
        }
    }
}
