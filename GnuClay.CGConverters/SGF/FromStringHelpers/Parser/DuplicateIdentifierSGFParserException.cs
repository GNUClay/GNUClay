﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class DuplicateIdentifierSGFParserException : Exception
    {
        public DuplicateIdentifierSGFParserException()
        {
        }

        public DuplicateIdentifierSGFParserException(string message)
            : base(message)
        {
        }
    }
}
