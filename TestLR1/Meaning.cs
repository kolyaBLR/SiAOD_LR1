using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiAOD_LR1;

namespace TestLR1
{
    [TestClass]
    public class Meaning
    {
        [TestMethod]
        public void Computation1()
        {
            //arrange
            int x = 2;
            double expected = 40;
            MyList list = new MyList();
            list.Add(2, 3);
            list.Add(3, 3);

            //act
            double result = Program.Meaning(list, x);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Computation2()
        {
            //arrange
            int x = -2;
            double expected = 3;
            MyList list = new MyList();
            list.Add(1, 0);
            list.Add(1, 0);
            list.Add(1, 0);

            //act
            double result = Program.Meaning(list, x);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}