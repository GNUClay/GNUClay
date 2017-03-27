using GnuClay.CommonUtils.Tasking;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SquaresWorkBench.CommonEngine
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
            Id = CreateNewId();

            var tmpPen = new Pen();

            tmpPen.Brush = Brushes.Black;
            tmpPen.DashStyle = DashStyles.Solid;
            tmpPen.Thickness = 1;

            CurrentPen = tmpPen;

            mDrawingVisual = new DrawingVisual();

            mVisualHost = new CustomVisualHost(mDrawingVisual);

            CalculateTargetPolarAngle();
        }

        private string CreateNewId()
        {
            return $"#{Guid.NewGuid().ToString("D")}";
        }

        [PersistentKVPProperty]
        public string Id = string.Empty;

        private Dispatcher mCurrDispatcher = null;

        public Dispatcher CurrDispatcher
        {
            get
            {
                return mCurrDispatcher;
            }

            protected set
            {
                if (mCurrDispatcher == value)
                {
                    return;
                }

                mCurrDispatcher = value;
            }
        }

        private SimpleViewer mViewer = null;

        public SimpleViewer CurrViewer
        {
            get
            {
                return mViewer;
            }

            set
            {
                if (mViewer == value)
                {
                    return;
                }

                var tmpOldViewer = mViewer;

                mViewer = value;

                if (tmpOldViewer != null)
                {
                    tmpOldViewer.RemoveEntity(this);
                }

                if (mViewer != null)
                {
                    CurrDispatcher = mViewer.CurrCanvas.Dispatcher;
                    mViewer.AddEntity(this);
                }

                UpdateView();

                OnSetViewer();
            }
        }

        protected virtual void OnSetViewer()
        {
        }

        private Movator mMovator = null;

        public Movator CurrMovator
        {
            get
            {
                return mMovator;
            }

            set
            {
                if (mMovator == value)
                {
                    return;
                }

                var tmpOldMovator = mMovator;

                mMovator = value;

                if (tmpOldMovator != null)
                {
                    tmpOldMovator.Remove(this);
                }

                if (mMovator != null)
                {
                    mMovator.Add(this);
                }

                OnSetMovator();
            }
        }

        protected virtual void OnSetMovator()
        {
        }

        private MainContext mMainContext = null;

        public MainContext CurrMainContext
        {
            get
            {
                return mMainContext;
            }

            set
            {
                if (mMainContext == value)
                {
                    return;
                }

                mMainContext = value;

                if (mMainContext != null)
                {
                    CurrMovator = mMainContext.CurrMovator;
                    CurrViewer = mMainContext.CurrViewer;
                    CurrActiveContext = mMainContext.CurrActiveContext;
                }
            }
        }

        public virtual ActiveContext CurrActiveContext { get; set; }

        protected virtual void OnSetMainContext()
        {
        }

        private DrawingVisual mDrawingVisual = null;
        private CustomVisualHost mVisualHost = null;

        public CustomVisualHost VisualHost
        {
            get
            {
                return mVisualHost;
            }
        }

        private Geometry mGeometry = null;

        private double mDX = 0;
        private double mDY = 0;

        protected double DX
        {
            get
            {
                return mDX;
            }
        }

        protected double DY
        {
            get
            {
                return mDY;
            }
        }

        public void UpdateView()
        {
            if (CurrDispatcher == null)
            {
                return;
            }

            CurrDispatcher.Invoke(() =>
            {
                OnCreateGeometry();
            });

            Draw();
        }

        protected virtual void OnCreateGeometry()
        {
        }

        public Geometry CurrentGeometry
        {
            get
            {
                return mGeometry;
            }

            protected set
            {
                mGeometry = value;

                if (mGeometry == null)
                {
                    return;
                }

                var tmpCentralPoint = SimpleMath.GetCentralPoint(mGeometry.Bounds);

                mDX = tmpCentralPoint.X;
                mDY = tmpCentralPoint.Y;
            }
        }

        private Brush mBrush = null;

        protected Brush CurrentBrush
        {
            get
            {
                return mBrush;
            }

            set
            {
                if (mBrush == value)
                {
                    return;
                }

                mBrush = value;

                if (mBrush != null)
                {
                    mBrush.Freeze();
                }

                UpdateView();
            }
        }

        private Pen mPen = null;

        protected Pen CurrentPen
        {
            get
            {
                return mPen;
            }

            set
            {
                if (mPen == value)
                {
                    return;
                }

                mPen = value;

                if (mPen != null)
                {
                    mPen.Freeze();
                }

                UpdateView();
            }
        }

        protected void Draw()
        {
            if (CurrentGeometry == null)
            {
                return;
            }

            if (mDrawingVisual == null)
            {
                return;
            }

            mDrawingVisual.Dispatcher.Invoke(() =>
            {
                using (var drawingContext = mDrawingVisual.RenderOpen())
                {
                    var tmpGeometryDrawing = new GeometryDrawing(CurrentBrush, CurrentPen, CurrentGeometry);

                    drawingContext.DrawDrawing(tmpGeometryDrawing);

                    drawingContext.Close();
                }
            });

            ImplementLocation();
        }

        private object mLockObj = new object();

        protected object LockObj
        {
            get
            {
                return mLockObj;
            }
        }

        private double mCurrAngle = 0;
        private double mCurrPolarAngle = -90;

        private double mTargetPolarAngle = -90;

        private double mTargetRadiansPolarAngle = 0;

        public double CurrAngle
        {
            get
            {
                return mCurrAngle;
            }

            set
            {
                NSetCurrAngle(value);

                mOldAngle = value;
            }
        }

        public double CurrPolarAngle
        {
            get
            {
                return mCurrPolarAngle;
            }
        }

        public double TargetPolarAngle
        {
            get
            {
                return mTargetPolarAngle;
            }
        }

        public double TargetRadiansPolarAngle
        {
            get
            {
                return mTargetRadiansPolarAngle;
            }
        }

        private void CalculateTargetPolarAngle()
        {
            mTargetPolarAngle = mCurrPolarAngle + mGoingAzimut;

            mTargetRadiansPolarAngle = SimpleMath.DegreesToRadians(mTargetPolarAngle);
        }

        private void NSetCurrAngle(double value)
        {
            if (mCurrAngle == value)
            {
                return;
            }

            mOldAngle = mCurrAngle;

            mCurrAngle = value;

            mCurrPolarAngle = ConvertScreenAngleToPolarAngle(mCurrAngle);

            CalculateTargetPolarAngle();

            var tmpDifAngle = mCurrAngle - mOldAngle;

            ImplementLocation(tmpDifAngle);
        }

        private double ConvertScreenAngleToPolarAngle(double screenAngle)
        {
            return screenAngle - 90;
        }

        private void ImplementLocation(double angleDif = 0)
        {
            if (CurrentGeometry == null)
            {
                return;
            }

            if (double.IsNaN(mCurrPos.X) || double.IsNaN(mCurrPos.Y))
            {
                return;
            }

            if (mIsDestroyed)
            {
                return;
            }

            try
            {
                CurrentGeometry.Dispatcher.Invoke(() =>
                {
                    var tmpTransformGroup = new TransformGroup();

                    var tmpRotateTransform = new RotateTransform(mCurrAngle);

                    tmpRotateTransform.CenterX = DX;
                    tmpRotateTransform.CenterY = DY;

                    tmpTransformGroup.Children.Add(tmpRotateTransform);

                    var tmpTranslateTransform = new TranslateTransform(mDarawablePos.X - DX, mDarawablePos.Y - DY);

                    tmpTransformGroup.Children.Add(tmpTranslateTransform);

                    CurrentGeometry.Transform = tmpTransformGroup;

                    mBound = CurrentGeometry.Bounds;

                    OnImplementLocationInDispatcher();
                }, DispatcherPriority.Background);
            }
            catch
            {
                return;
            }

            RegOnRTree();

            UpdateChildrenLocations(angleDif);

            OnImplementLocation();
            OnImplementLocationAsyncEmit();
        }

        protected virtual void OnImplementLocationInDispatcher()
        {
        }

        protected virtual void OnImplementLocation()
        {
        }

        protected virtual void OnImplementLocationAsync()
        {
        }

        public async void OnImplementLocationAsyncEmit()
        {
            await OnImplementLocationAsyncTask();
        }

        private Task OnImplementLocationAsyncTask()
        {
            var tmpT = new Task(() =>
            {
                OnImplementLocationAsync();
            });

            tmpT.Start();

            return tmpT;
        }

        private void RegOnRTree()
        {
            if (CurrViewer == null)
            {
                return;
            }

            List<RTreeNode> tmpNewList = null;

            try
            {
                tmpNewList = CurrViewer.CurrRTree.GetNodeByRect(mBound);
            }
            catch
            {
                return;
            }

            var tmpRez = _ListHelper.Comparare(mCurrentRTreeNodes, tmpNewList);

            foreach (var node in tmpRez.MustAddedItems)
            {
                node.AddEntity(this);
            }

            foreach (var node in tmpRez.MustRemovedItems)
            {
                node.RemoveEntity(this);
            }

            mCurrentRTreeNodes = tmpNewList;
        }

        private void RemoveAllOnRTree()
        {
            foreach (var node in mCurrentRTreeNodes)
            {
                node.RemoveEntity(this);
            }
        }

        private void UpdateChildrenLocations(double angleDif)
        {
            foreach (var child in mChildren)
            {
                child.UpdateLocationByPlatform(angleDif);
            }
        }

        public void UpdateLocationByPlatform(double angleDif)
        {
            if (angleDif != 0)
            {
                NSetCurrAngle(CurrAngle + angleDif);
            }

            NUpdateAbsolutePosByRelativePos();
        }

        public List<BaseEntity> OtherEntities
        {
            get
            {
                var tmpRez = new List<BaseEntity>();

                foreach (var node in mCurrentRTreeNodes)
                {
                    var tmpLItems = node.Entities;

                    foreach (var tmpLI in tmpLItems)
                    {
                        if (tmpRez.Contains(tmpLI))
                        {
                            continue;
                        }

                        if (tmpLI == this)
                        {
                            continue;
                        }

                        tmpRez.Add(tmpLI);
                    }
                }

                return tmpRez;
            }
        }

        private Rect mBound = new Rect();

        public Rect Bound
        {
            get
            {
                return mBound;
            }
        }

        private List<RTreeNode> mCurrentRTreeNodes = new List<RTreeNode>();

        private Point mCurrPos = new Point(0, 0);

        public Point CurrPos
        {
            get
            {
                return mCurrPos;
            }

            set
            {
                NSetCurrPos(value);

                mOldPosition = value;
            }
        }

        private Point mRelativePos = new Point(0, 0);

        public Point RelativePos
        {
            get
            {
                return mRelativePos;
            }

            set
            {
                NSetRelativePos(value);
            }
        }

        private void NSetRelativePos(Point value)
        {
            if (CurrPlatform == null)
            {
                return;
            }

            if (mRelativePos == value)
            {
                return;
            }

            NSetRelativePos_Internales(value);

            NUpdateAbsolutePosByRelativePos();
        }

        private void NSetRelativePos_Internales(Point value)
        {
            if (CurrPlatform == null)
            {
                return;
            }

            if (mRelativePos == value)
            {
                return;
            }

            mRelativePos = value;

            CalculatePolarRelativePos();
        }

        public Point TransformToViewer(Point value)
        {
            if (CurrPlatform == null)
            {
                throw new Exception();
            }

            var tmpTargetPos = new Point(CurrPlatform.CurrPos.X + value.X, CurrPlatform.CurrPos.Y + value.Y);

            return tmpTargetPos;
        }

        public Point TransformToPlatform(Point value)
        {
            if (CurrPlatform == null)
            {
                throw new Exception();
            }

            var tmpTargetPos = new Point(value.X - CurrPlatform.CurrPos.X, value.Y - CurrPlatform.CurrPos.Y);

            return tmpTargetPos;
        }

        private double mCurrRelativeAngle = 0;
        private double mCurrRelativeRadius = 0;

        public double CurrRelativeAngle
        {
            get
            {
                return mCurrRelativeAngle;
            }
        }

        public double CurrRelativeRadius
        {
            get
            {
                return mCurrRelativeRadius;
            }
        }

        private void NSetCurrPos(Point value)
        {
            if (mCurrPos == value)
            {
                return;
            }

            NSetCurrPos_Internales(value);

            NSyncRelativePosByCurrPos();
        }

        private void NSetCurrPos_Internales(Point value)
        {
            if (mCurrPos == value)
            {
                return;
            }

            mOldPosition = mCurrPos;

            mCurrPos = value;

            var tmpX = (int)mCurrPos.X;
            var tmpY = (int)mCurrPos.Y;

            if (mDarawablePos.X == tmpX && mDarawablePos.Y == tmpY)
            {
                return;
            }

            mDarawablePos = new Point(tmpX, tmpY);

            ImplementLocation();
        }

        private void NSyncRelativePosByCurrPos()
        {
            if (CurrPlatform == null)
            {
                return;
            }

            var tmpTargetRelativePos = TransformToPlatform(mCurrPos);

            NSetRelativePos_Internales(tmpTargetRelativePos);
        }

        private void CalculatePolarRelativePos()
        {
            var tmpAngle = Math.Atan2(RelativePos.Y, RelativePos.X);

            var tmpDAngle = SimpleMath.RadiansToDegrees(tmpAngle);

            mCurrRelativeAngle = tmpDAngle - CurrPolarAngle;

            mCurrRelativeRadius = Math.Sqrt(RelativePos.X * RelativePos.X + RelativePos.Y * RelativePos.Y);
        }

        private void NUpdateAbsolutePosByRelativePos()
        {
            var tmpDAngle = CurrPolarAngle + CurrRelativeAngle;

            var tmpTargetPoint = SimpleMath.PolarToDecartByBasePos_D(tmpDAngle, CurrRelativeRadius, CurrPlatform.CurrPos);

            NSetCurrPos_Internales(tmpTargetPoint);
        }

        private bool mIsHard = false;

        [PersistentKVPProperty]
        public bool IsHard
        {
            get
            {
                return mIsHard;
            }

            set
            {
                NSetIsHard(value);
            }
        }

        private void NSetIsHard(bool value)
        {
            if (mIsHard == value)
            {
                return;
            }

            mIsHard = value;
        }

        private double mSpeed = 0;

        [PersistentKVPProperty]
        public double Speed
        {
            get
            {
                return mSpeed;
            }

            set
            {
                NSetSpeed(value);
            }
        }

        public double SpeedPerTick(double multiplier)
        {
            return mSpeed / multiplier;
        }

        private void NSetSpeed(double value)
        {
            if (mSpeed == value)
            {
                return;
            }

            mSpeed = value;

            CalculateDamage();
        }

        private double mGoingAzimut = 0;

        [PersistentKVPProperty]
        public double GoingAzimut
        {
            get
            {
                return mGoingAzimut;
            }

            set
            {
                NSetGoingAzimut(value);
            }
        }

        private void NSetGoingAzimut(double value)
        {
            if (mGoingAzimut == value)
            {
                return;
            }

            mGoingAzimut = value;

            CalculateTargetPolarAngle();
        }

        private GoDirectionFlag mGoDirection = GoDirectionFlag.Stop;

        [PersistentKVPProperty]
        public GoDirectionFlag GoDirection
        {
            get
            {
                return mGoDirection;
            }

            set
            {
                NSetGoDirection(value);
            }
        }

        private void NSetGoDirection(GoDirectionFlag value)
        {
            if (mGoDirection == value)
            {
                return;
            }

            if (value != GoDirectionFlag.Stop)
            {
                if (!CanSetGoDirection(value))
                {
                    return;
                }
            }

            mGoDirection = value;
        }

        protected virtual bool CanSetGoDirection(GoDirectionFlag value)
        {
            return true;
        }

        public bool IsMoving
        {
            get
            {
                if (GoDirection == GoDirectionFlag.Stop)
                {
                    return false;
                }

                if (Speed == 0)
                {
                    return false;
                }

                return true;
            }
        }

        private double mOpacity = 0;

        [PersistentKVPProperty]
        public double Opacity
        {
            get
            {
                return mOpacity;
            }

            set
            {
                mOpacity = value;
            }
        }

        private Point mOldPosition = new Point();
        private double mOldAngle = 0;

        private Point mDarawablePos = new Point();

        public void MoveBySession(double multiplier)
        {
            var speedPerTick = SpeedPerTick(multiplier);

            switch (GoDirection)
            {
                case GoDirectionFlag.Go:
                    MoveGoBySession(speedPerTick);
                    break;

                case GoDirectionFlag.RotateLeft:
                    MoveRotateLeftBySession(speedPerTick);
                    break;

                case GoDirectionFlag.GoAndRotateLeft:
                    MoveGoBySession(speedPerTick);
                    MoveRotateLeftBySession(speedPerTick);
                    break;

                case GoDirectionFlag.RotateRight:
                    MoveRotateRightBySession(speedPerTick);
                    break;

                case GoDirectionFlag.GoAndRotateRight:
                    MoveGoBySession(speedPerTick);
                    MoveRotateRightBySession(speedPerTick);
                    break;
            }
        }

        private void MoveGoBySession(double speedPerTick)
        {
            NSetCurrPos(SimpleMath.PolarToDecartByBasePos_R(TargetRadiansPolarAngle, speedPerTick, CurrPos));
        }

        private void MoveRotateLeftBySession(double speedPerTick)
        {
            NSetCurrAngle(CurrAngle - speedPerTick);
        }

        private void MoveRotateRightBySession(double speedPerTick)
        {
            NSetCurrAngle(CurrAngle + speedPerTick);
        }

        private void RestoreAbsolutePosByRelativePos()
        {
            NUpdateAbsolutePosByRelativePos();
        }

        public void UndoMoving()
        {
            NSetCurrPos(mOldPosition);

            NSetCurrAngle(mOldAngle);
        }

        protected virtual void CollideWith(BaseEntity entity)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("CollideWith {0} => {1}", Id, entity.Id);
        }

        public async void CollideWithAsync(BaseEntity entity)
        {
            await CollideWithAsyncTask(entity);
        }

        private Task CollideWithAsyncTask(BaseEntity entity)
        {
            var tmpT = new Task(() =>
            {
                if (mChildren.Contains(entity))
                {
                    return;
                }

                if (CurrPlatform == entity)
                {
                    return;
                }

                CollideWith(entity);
            });

            tmpT.Start();

            return tmpT;
        }

        protected virtual void IAmOn(BaseEntity entity)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("IAmOn {0} => {1}", Id, entity.Id);
        }

        public async void IAmOnEmit(BaseEntity entity)
        {
            await IAmOnTask(entity);
        }

        private Task IAmOnTask(BaseEntity entity)
        {
            var tmpT = new Task(() =>
            {
                IAmOn(entity);
            });

            tmpT.Start();

            return tmpT;
        }

        public virtual void Scan()
        {
        }

        public virtual void ActivateEntity()
        {
        }

        public virtual void StopEntity()
        {
        }

        public void ProcessPostMoving()
        {
            var tmpList = OtherEntities;

            foreach (var entity in tmpList)
            {
                if (entity.CurrPlatform == this)
                {
                    continue;
                }

                if (CurrPlatform == entity)
                {
                    continue;
                }

                var tmpIntersectRez = IntersectionDetail.NotCalculated;

                try
                {
                    tmpIntersectRez = entity.CurrentGeometry.Dispatcher.Invoke(() =>
                    {
                        return CurrentGeometry.FillContainsWithDetail(entity.CurrentGeometry);
                    });
                }
                catch
                {
                    return;
                }

                if (tmpIntersectRez == IntersectionDetail.Empty)
                {
                    continue;
                }

                if (IsHard && entity.IsHard)
                {
                    if (CurrPlatform == null && entity.CurrPlatform == null)
                    {
                        if (IsMoving)
                        {
                            UndoMoving();
                        }

                        if (entity.IsMoving)
                        {
                            entity.UndoMoving();
                        }

                        CollideWithAsync(entity);
                        entity.CollideWithAsync(this);
                    }
                    else
                    {
                        if (CurrPlatform == entity.CurrPlatform)
                        {
                            if (IsMoving)
                            {
                                UndoMoving();
                            }

                            if (entity.IsMoving)
                            {
                                entity.UndoMoving();
                            }

                            CollideWithAsync(entity);
                            entity.CollideWithAsync(this);
                        }
                        else
                        {
                            if (CurrPlatform == null)
                            {
                                if (IsMoving)
                                {
                                    UndoMoving();
                                }

                                CollideWithAsync(entity);
                            }
                            else
                            {
                                if (CurrPlatform.IsMoving)
                                {
                                    CurrPlatform.UndoMoving();
                                }

                                CollideWithAsync(entity);
                                CurrPlatform.CollideWithAsync(entity);
                            }

                            if (entity.CurrPlatform == null)
                            {
                                if (entity.IsMoving)
                                {
                                    entity.UndoMoving();
                                }

                                entity.CollideWithAsync(this);
                            }
                            else
                            {
                                if (entity.CurrPlatform.IsMoving)
                                {
                                    entity.CurrPlatform.UndoMoving();
                                }

                                entity.CollideWithAsync(this);
                                entity.CurrPlatform.CollideWithAsync(this);
                            }
                        }
                    }
                }
                else
                {
                    IAmOnEmit(entity);
                }
            }

            ProcessPostMovingChildren();
        }

        private void ProcessPostMovingChildren()
        {
            foreach (var child in mChildren)
            {
                child.ProcessPostMoving();
            }
        }

        private List<BaseEntity> mChildren = new List<BaseEntity>();

        public void AddChild(BaseEntity entity)
        {
            if (mChildren.Contains(entity))
            {
                return;
            }

            mChildren.Add(entity);

            if (entity.CurrPlatform != this)
            {
                entity.CurrPlatform = this;
            }
        }

        public void RemoveChild(BaseEntity entity)
        {
            if (!mChildren.Contains(entity))
            {
                return;
            }

            mChildren.Remove(entity);

            if (entity.CurrPlatform == this)
            {
                entity.CurrPlatform = null;
            }
        }

        private BaseEntity mPlatform = null;

        public BaseEntity CurrPlatform
        {
            get
            {
                return mPlatform;
            }

            set
            {
                if (mPlatform == value)
                {
                    return;
                }

                var tmpOldPlatform = mPlatform;

                mPlatform = value;

                if (tmpOldPlatform != null)
                {
                    tmpOldPlatform.RemoveChild(this);

                    ResetRelativePos();
                }

                if (mPlatform != null)
                {
                    mPlatform.AddChild(this);

                    NSyncRelativePosByCurrPos();
                }
            }
        }

        private void ResetRelativePos()
        {
            mRelativePos = new Point(0, 0);
            mCurrRelativeAngle = 0;
            mCurrRelativeRadius = 0;
        }

        public bool mIsDestroyed = false;

        public void Destroy()
        {
            if (mIsDestroyed)
            {
                return;
            }

            mIsDestroyed = true;

            StopEntity();

            if (CurrMovator != null)
            {
                CurrMovator.Remove(this);
            }

            if (CurrViewer != null)
            {
                CurrViewer.RemoveEntity(this);
            }

            RemoveAllOnRTree();

            OnDestroy();

            CurrPlatform = null;

            var tmpChildren = mChildren.ToList();

            foreach (var child in tmpChildren)
            {
                child.CurrPlatform = null;
            }
        }

        protected virtual void OnDestroy()
        {
        }

        private double mWeight = 1;

        [PersistentKVPProperty]
        public double Weight
        {
            get
            {
                return mWeight;
            }

            set
            {
                if (mWeight == value)
                {
                    return;
                }

                mWeight = value;

                CalculateDamage();
            }
        }

        private double mDamage = 0;

        public double Damage
        {
            get
            {
                return mDamage;
            }
        }

        private void CalculateDamage()
        {
            mDamage = Weight * Speed;
        }

        private double mThreshold = 1;

        [PersistentKVPProperty]
        public double Threshold
        {
            get
            {
                return mThreshold;
            }

            set
            {
                if (mThreshold == value)
                {
                    return;
                }

                mThreshold = value;
            }
        }

        private double mDurability = 1;

        [PersistentKVPProperty]
        public double Durability
        {
            get
            {
                return mDurability;
            }

            set
            {
                if (mDurability == value)
                {
                    return;
                }

                mDurability = value;

                if (mDurability > 0)
                {
                    mIsBroken = false;
                }
                else
                {
                    mIsBroken = true;
                }
            }
        }

        public bool mIsBroken = false;

        public bool IsBroken
        {
            get
            {
                return mIsBroken;
            }
        }

        public void Hit(double damage)
        {
            if (damage < Threshold)
            {
                return;
            }

            if (Durability <= 0)
            {
                return;
            }

            Durability -= damage;
        }

        public EntityInfo CreateInfo()
        {
            var tmpInfo = new EntityInfo();

            var tmpCurrType = GetType();

            tmpInfo.TypeName = tmpCurrType.FullName;

            tmpInfo.CurrAngle = CurrAngle;

            tmpInfo.CurrPos = CurrPos;

            tmpInfo.RelativePos = RelativePos;

            var tmpTargetAttributeType = typeof(PersistentKVPPropertyAttribute);

            var tmpFields = tmpCurrType.GetFields().Where(p => p.CustomAttributes.Count(i => i.AttributeType == tmpTargetAttributeType) > 0);

            foreach (var field in tmpFields)
            {
                tmpInfo.SecondaryProps.Add(new SecondaryPropertyInfo(field.Name, field.GetValue(this)));
            }

            var tmpProps = tmpCurrType.GetProperties().Where(p => p.CustomAttributes.Count(i => i.AttributeType == tmpTargetAttributeType) > 0);

            foreach (var prop in tmpProps)
            {
                tmpInfo.SecondaryProps.Add(new SecondaryPropertyInfo(prop.Name, prop.GetValue(this)));
            }

            return tmpInfo;
        }

        public void RestoreSecondaryProps(EntityInfo info)
        {
            var tmpCurrType = GetType();

            var tmpTargetAttributeType = typeof(PersistentKVPPropertyAttribute);

            var tmpMembers = tmpCurrType.GetMembers().Where(p => (p.MemberType == MemberTypes.Field || p.MemberType == MemberTypes.Property) && p.CustomAttributes.Count(i => i.AttributeType == tmpTargetAttributeType) > 0).ToList();

            var tmpMembersDict = tmpMembers.ToDictionary(p => p.Name, p => p);

            foreach (var prop in info.SecondaryProps)
            {
                if (!tmpMembersDict.ContainsKey(prop.Name))
                {
                    return;
                }

                var tmpMember = tmpMembersDict[prop.Name];

                if (tmpMember.MemberType == MemberTypes.Field)
                {
                    ((FieldInfo)tmpMember).SetValue(this, prop.Value);

                    continue;
                }

                ((PropertyInfo)tmpMember).SetValue(this, prop.Value);
            }
        }

        public T Supports<T>() where T : BaseEntity
        {
            return this as T;
        }

        public bool IsT<T>() where T : BaseEntity
        {
            return this is T;
        }
    }
}
