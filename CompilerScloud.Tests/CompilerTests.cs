using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CompilerScloud.Tests {    
    [TestFixture]
    public class CompilerTests {
        [Test]
        public void ValidateHeader() {
            string content = @"
[KTA_NDS]
Connect=File=""\\clusterfs126\users\91776\DB\Accounting3"";
ID = e74bf314 - e943 - 4830 - bd93 - befc04aa714e
External = 0";
            Compiler compiler = new Compiler(null);
            List<int> errors = compiler.Validate();
            Assert.AreEqual(1, errors.Count);

        }
    }
}
