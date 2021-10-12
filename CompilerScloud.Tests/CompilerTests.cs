using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerScloud.Tests {
    [TestFixture]
    public class CompilerTests {
        [Test]
        public void CorrectParseObjectsTest() {
            string text = @"[KTA_NDS]
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
            Compiler compiler = new Compiler();
            Assert.AreEqual(3, compiler.GetObjects(text).Length);
        }
        [Test]
        public void IsHeadValidTest() {
            string header = "[KTA_NDS]";
            Compiler compiler = new Compiler();
            Assert.IsTrue(compiler.IsHeadValid(header));
            header = "KTA_NDS]";
            Assert.IsFalse(compiler.IsHeadValid(header));
            header = "[KTA_NDS";
            Assert.IsFalse(compiler.IsHeadValid(header)); 
            header = "[]";
            Assert.IsFalse(compiler.IsHeadValid(header));
            header = "[  ]";
            Assert.IsFalse(compiler.IsHeadValid(header));
        }

        [Test]
        public void IsParameterValidTest() {
            string param = "External=1";
            Compiler compiler = new Compiler();
            Assert.IsTrue(compiler.IsPairValid(param));
            param = "External=";
            Assert.IsFalse(compiler.IsPairValid(param));
            param = "=1";
            Assert.IsFalse(compiler.IsPairValid(param));

        }
        [Test]
        public void IsServerValidTest() {             
            Compiler compiler = new Compiler();               
            string path = @"Srvr=""host371: 1741"";Ref=""432345_base01:""";
            Assert.IsTrue(compiler.IsServerValid(path));            
            path = @"=""host371: 1741"";Ref=""432345_base01:""";
            Assert.IsFalse(compiler.IsServerValid(path));
            path = @"Srvr=""host371: 1741"";=""432345_base01:""";
            Assert.IsFalse(compiler.IsServerValid(path));                
        }

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(@"""s:\usersdata\643343\МХТ"";", true)]
        [TestCase(@"""\\clusterfs126\users\91776\DB\Accounting3"";", true)]
        public void IsPathValidTest(string path, bool expectedValue) {
            Compiler compiler = new Compiler();
            Assert.AreEqual(expectedValue, compiler.IsPathValid(path));
        }
    }
}
