using GnuClay.CommonUtils.TypeHelpers;
using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class WalkToAvailableGoalProcess : BaseLogicalProcess
    {
        public WalkToAvailableGoalProcess()
            : base(StartupMode.OnDemand, "walk to available goal")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new ActionCommandFilter();
            filter.CommandName = Name;

            var numberKey = LogicalEntity.GetKey("number");
            var stringKey = LogicalEntity.GetKey("string");

            var filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = stringKey;
            filter.Params.Add("goal", filterParameter);

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = numberKey;
            filter.Params.Add("speed", filterParameter);

            AddFilter(filter);
        }

        private double Speed = 0;
        private string Goal = string.Empty;

        protected override void OnStart()
        {
            var paramsDict = CurrentCommand.Params;

            Speed = (double)paramsDict["speed"];
            Goal = (string)paramsDict["goal"];
        }

        private void InitialExamination()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("InitialExamination");

            var result = LogicalEntity.IsVisible(Goal);

            if(!result)
            {
                CurrentEntityAction.Status = EntityActionStatus.Faulted;
            }
        }

        private void RotateToGoal()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RotateToGoal Speed = {Speed} Goal = {Goal}");

            while (true)
            {
                FindTargetAngle();

                if (CurrentEntityAction.Status != EntityActionStatus.Running)
                {
                    return;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"RotateToGoal Speed = {Speed} Goal = {Goal} mTargetAngle = {mTargetAngle}");

                if (mTargetAngle == 0)
                {
                    return;
                }

                DispatchTargetAngle();

                if (CurrentEntityAction.Status != EntityActionStatus.Running)
                {
                    return;
                }
            }
        }

        private double mTargetAngle = double.NaN;

        private void FindTargetAngle()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindTargetAngle Speed = {Speed} Goal = {Goal}");

            var targetVisibleItem = LogicalEntity.GetVisibleResultItem(Goal);

            var targetPointsList = targetVisibleItem.VisiblePoints;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindTargetAngle targetPointsList = {_ListHelper._ToString(targetPointsList)}");

            var minDistance = targetPointsList.Min(p => p.Radius);

            var itemsForMinDistance = targetPointsList.Where(p => p.Radius == minDistance).ToList();

            if(itemsForMinDistance.Any(p => p.Angle == 0))
            {
                mTargetAngle = 0;
                return;
            }

            var minDistanceForMinAngle = itemsForMinDistance.Min(p => p.Angle);

            NLog.LogManager.GetCurrentClassLogger().Info($"FindTargetAngle minDistance = {minDistance} minDistanceForMinAngle = {minDistanceForMinAngle}");

            CurrentEntityAction.Status = EntityActionStatus.Faulted;
        }

        private void DispatchTargetAngle()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchTargetAngle Speed = {Speed} Goal = {Goal} mTargetAngle = {mTargetAngle}");
        }

        private double mRemainingDistance = double.NaN;

        private void FindRemainingDistance()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindRemainingDistance Speed = {Speed} Goal = {Goal}");

            var targetVisibleItem = LogicalEntity.GetVisibleResultItem(Goal);

            var targetPointsList = targetVisibleItem.VisiblePoints;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindRemainingDistance targetPointsList = {_ListHelper._ToString(targetPointsList)}");

            mRemainingDistance = targetPointsList.Where(p => p.Angle == 0).Min(p => p.Radius);          
        }

        private void WalkDirectly()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"WalkDirectly Speed = {Speed} Goal = {Goal}");
        }

        private void RotateRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RotateRight Speed = {Speed} Goal = {Goal}");
        }

        private void RotateLeft()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RotateLeft Speed = {Speed} Goal = {Goal}");
        }

        private void Stop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Stop Speed = {Speed} Goal = {Goal}");
        }

        private bool mIsWalking = false;
        private double mMinDistance = 2;

        private void DispatchRemainingDistance()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchRemainingDistance Speed = {Speed} Goal = {Goal} mRemainingDistance = {mRemainingDistance}");

            if(mRemainingDistance >= mMinDistance)
            {
                if(!mIsWalking)
                {
                    WalkDirectly();
                    mIsWalking = true;
                }
            }
            else
            {
                if(mIsWalking)
                {
                    Stop();
                    mIsWalking = false;
                }
            }

            CurrentEntityAction.Status = EntityActionStatus.Faulted;
        }

        private void GoToGoal()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GoToGoal Speed = {Speed} Goal = {Goal}");

            while (true)
            {
                FindRemainingDistance();

                if (CurrentEntityAction.Status != EntityActionStatus.Running)
                {
                    return;
                }

                DispatchRemainingDistance();

                if (CurrentEntityAction.Status != EntityActionStatus.Running)
                {
                    return;
                }
            }
        }

        protected override void Main()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Main Speed = {Speed} Goal = {Goal}");

            InitialExamination();

            if (CurrentEntityAction.Status != EntityActionStatus.Running)
            {
                return;
            }

            RotateToGoal();

            if (CurrentEntityAction.Status != EntityActionStatus.Running)
            {
                return;
            }

            if (CurrentEntityAction.Status != EntityActionStatus.Running)
            {
                return;
            }

            GoToGoal();

            CurrentEntityAction.Status = EntityActionStatus.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info("End Main");
        }
    }
}
