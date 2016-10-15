﻿using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class ParamsInfo : IToStringData
    {
        public bool IsEntity = false;

        public int EntityKey = 0;

        public int Key_Up = 0;

        public int Key_Down = 0;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(IsEntity));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsEntity.ToString());

            tmpSb.Append(nameof(EntityKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(EntityKey.ToString());

            tmpSb.Append(nameof(Key_Up));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Key_Up.ToString());

            tmpSb.Append(nameof(Key_Down));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Key_Down.ToString());

            return tmpSb.ToString();
        }
    }

    public class ParamsBinder : IToStringData
    {
        public static ParamsBinder FromRelationNode(ExpressionNode node, ParamsBinder sourceParamsBinder, Dictionary<int, int> EKMap)
        {
            var tmpItem = new ParamsBinder();

            tmpItem.RelationKey = node.Key;

            var tmpI = -1;

            foreach (var tmpParam in node.RelationParams)
            {
                tmpI++;

                var tmpBindedParam = new ParamsInfo();

                tmpItem.ParamsList.Add(tmpBindedParam);

                tmpBindedParam.Key_Up = tmpParam.Key;

                switch(tmpParam.Kind)
                {
                    case ExpressionNodeKind.Entity:
                        tmpBindedParam.IsEntity = true;
                        tmpBindedParam.EntityKey = EKMap[tmpBindedParam.Key_Up];
                        tmpItem.IndexesParamsWithEntities.Add(tmpI);
                        break;

                    case ExpressionNodeKind.Var:
                        if(sourceParamsBinder.IsRoot)
                        {
                            tmpBindedParam.IsEntity = false;
                            break;
                        }

                        if(sourceParamsBinder.VarsWithEntities.ContainsKey(tmpParam.Key))
                        {
                            tmpBindedParam.IsEntity = true;
                            tmpBindedParam.EntityKey = sourceParamsBinder.VarsWithEntities[tmpParam.Key];
                            tmpItem.IndexesParamsWithEntities.Add(tmpI);
                            break;
                        }

                        tmpBindedParam.IsEntity = false;
                        break;

                    default:throw new ArgumentOutOfRangeException(nameof(tmpParam.Kind));
                }
            }

            return tmpItem;
        }

        public bool IsRoot = false;

        public int RelationKey = 0;

        public List<ParamsInfo> ParamsList = new List<ParamsInfo>();

        public Dictionary<int, int> VarsWithEntities = new Dictionary<int, int>();

        public List<int> IndexesParamsWithEntities = new List<int>();

        public Dictionary<int, int> RevertDictionary = new Dictionary<int, int>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(IsRoot));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsRoot.ToString());

            tmpSb.Append(nameof(RelationKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(RelationKey.ToString());

            tmpSb.AppendLine(_ListHelper._ToString(ParamsList, nameof(ParamsList)));

            tmpSb.AppendLine(_ListHelper._ToString(IndexesParamsWithEntities, nameof(IndexesParamsWithEntities)));

            tmpSb.AppendLine(_ListHelper._ToString(RevertDictionary.ToList(), nameof(RevertDictionary)));

            return tmpSb.ToString();
        }
    }
}
