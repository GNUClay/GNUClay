using GnuClay.CommonUtils.TypeHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.UnitTests.CommonUtils
{
    [TestFixture]
    public class _StringHelperTests
    {
        [Test]
        public void Normalize_NullOrEmptyString_ReturnEmptyString()
        {
            StringAssert.AreEqualIgnoringCase(string.Empty, _StringHelper.Normalize(string.Empty));
            StringAssert.AreEqualIgnoringCase(string.Empty, _StringHelper.Normalize(null));
        }

        [Test]
        public void Normalize_Case1()
        {
            var tmpSourceString = " dog      cat (    (tree)   )   w ";

            var tmpTargetString = "dog cat((tree))w";

            StringAssert.AreNotEqualIgnoringCase(tmpSourceString, tmpTargetString);

            StringAssert.AreEqualIgnoringCase(tmpTargetString, _StringHelper.Normalize(tmpTargetString));
        }
    }
}
