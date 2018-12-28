using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TransformModel: IObjectToString
    {
        private Vector3 mPosition = new Vector3(0, 0, 0);
        public Vector3 Position
        {
            get
            {
                return mPosition;
            }

            set
            {
                if(mPosition == value)
                {
                    return;
                }

                mPosition = value;

                CalculateCornerPoints();
            }
        }
        
        private Quaternion mRotation = new Quaternion(0, 0, 0, 0);
        public Quaternion Rotation
        {
            get
            {
                return mRotation;
            }

            set
            {
                if(mRotation == value)
                {
                    return;
                }

                mRotation = value;

                CalculateCornerPoints();
            }
        }

        private Vector3 mScale = new Vector3(1, 1, 1);
        public Vector3 Scale
        {
            get
            {
                return mScale;
            }

            set
            {
                if(mScale == value)
                {
                    return;
                }

                mScale = value;

                CalculateCornerPoints();
            }
        }

        private void CalculateCornerPoints()
        {
#if DEBUG
            LogInstance.Log($"mPosition = {mPosition}");
            LogInstance.Log($"mRotation = {mRotation}");
            LogInstance.Log($"mScale = {mScale}");
#endif

            var zScale = mScale.Z / 2;
            var xScale = mScale.X / 2;

#if DEBUG
            LogInstance.Log($"zScale = {zScale}");
            LogInstance.Log($"xScale = {xScale}");
#endif

            var point = new Vector3(mPosition.X - xScale, mPosition.Z, mPosition.Z - zScale);

#if DEBUG
            LogInstance.Log($"point = {point}");
#endif

            point = Vector3.Transform(point, mRotation);

#if DEBUG
            LogInstance.Log($"after point = {point}");
#endif

            mLeftBottomPoint = point;

            point = new Vector3(mPosition.X + xScale, mPosition.Z, mPosition.Z + zScale);

#if DEBUG
            LogInstance.Log($"point = {point}");
#endif

            point = Vector3.Transform(point, mRotation);

#if DEBUG
            LogInstance.Log($"after point = {point}");
#endif

            mRightTopPoint = point;
        }

        private Vector3 mLeftBottomPoint;
        private Vector3 mRightTopPoint;

        public bool Contains(Vector3 point)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            return sb.ToString();
        }
    }
}
