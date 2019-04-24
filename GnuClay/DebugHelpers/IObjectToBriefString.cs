﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.DebugHelpers
{
    public interface IObjectToBriefString
    {
        string ToBriefString();
        string ToBriefString(uint n);
        string PropertiesToBriefString(uint n);
    }
}

/*
        public string ToBriefString()
        {
            return ToBriefString(0u);
        }

        public string ToBriefString(uint n)
        {
            return this.GetDefaultToBriefStringInformation(n);
        }

        public string PropertiesToBriefString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            return sb.ToString();
        } 
*/
