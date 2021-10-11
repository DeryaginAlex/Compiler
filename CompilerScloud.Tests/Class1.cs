using NUnit.Framework;
using System;

namespace CompilerScloud.Tests {    
    [TestFixture]
    public class Class1 {
        [Test]
        public void Test1() {
            int i = 1;
            Assert.AreEqual(1, i);
        }
    }
}
