using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.UnitTests.Engine
{
    [TestFixture]
    public class GnuClayEngineScriptsAssignOperatorsTests
    {
        [Test]
        public void AssignOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void PlusAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MinusAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MulAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void DivAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void AssingFactOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void PlusAssingFactOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }
    }
}
