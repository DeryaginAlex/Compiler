using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerScloud.Tests {
    [TestFixture]
    public class CompilerTests {
        public Compiler compiler;
        [SetUp]
        public void SetUp() {
            compiler = new Compiler();
        }

        [Test]
        public void CorrectParseObjectsTest() {
            string text = 
@"[KTA_NDS]
Connect=File=""\\clusterfs126\users\91776\DB\Accounting3"";
ID = e74bf314 - e943 - 4830 - bd93 - befc04aa714e
External = 0

[МХМ]
Connect = File = ""s:\usersdata\643343\МХТ"";

[Оптовик]
Connect = Srvr = ""host371:1741""; Ref = ""432345_base01""
ID = e74bf314 - e943 - 4830 - bd93 - 36aba8c5a66d
External = 1
";
            
            Assert.AreEqual(3, compiler.GetObjects(text).Length);
        }

        [TestCase("[KTA_NDS]", true)]
        [TestCase("KTA_NDS]", false)]
        [TestCase("[KTA_NDS", false)]
        [TestCase("[]", false)]
        [TestCase("[ ]", false)]
        public void IsHeadValidTest(string header, bool expectedValue) {
            Assert.AreEqual(compiler.IsHeadValid(header), expectedValue);
        }

        [TestCase("External=1", true)]
        [TestCase("External=", false)]
        [TestCase("=1", false)]
        public void IsParameterValidTest(string param, bool expectedValue) {
            Assert.AreEqual(compiler.IsPairValid(param), expectedValue);
        }

        [TestCase(@"Srvr=""host371: 1741"";Ref=""432345_base01:""", true)]
        [TestCase(@"=""host371: 1741"";Ref=""432345_base01:""", false)]
        [TestCase(@"Srvr=""host371: 1741"";=""432345_base01:""", false)]
        public void IsServerValidTest(string path, bool expectedValue) {
            Assert.AreEqual(compiler.IsServerValid(path), expectedValue);  
        }

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(@"""s:\usersdata\643343\МХТ"";", true)]
        [TestCase(@"""\\clusterfs126\users\91776\DB\Accounting3"";", true)]
        public void IsPathValidTest(string path, bool expectedValue) {
            Assert.AreEqual(expectedValue, compiler.IsPathValid(path));
        }
    }
}
