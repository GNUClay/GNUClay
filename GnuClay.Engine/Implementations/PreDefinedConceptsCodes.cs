using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public static class PreDefinedConceptsCodes
    {
        public const ulong MinAutoDefinedIndex = 3000;

        /// <summary>
        /// Iself - the concept what is I of this engine instance.
        /// </summary>
        public const ulong ISELF = 1;

        public const ulong IS = 2;

        public const ulong PROPOSITION = 3;

        public const ulong INSTANCE = 4;

        public const ulong CLASS = 5;
    }
}
