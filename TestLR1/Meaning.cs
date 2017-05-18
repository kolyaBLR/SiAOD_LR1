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
            int number1 = 2, power1 = 3, number2 = 3, power2 = 3;
            double expected = 280;
            MyList list = new MyList();
            list.Add(number1, power1);
            list.Add(number2, power2);

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
            int number1 = -1, power1 = 0, number2 = 0, power2 = 1, number3 = 1, power3 = 0;
            double expected = 2;
            MyList list = new MyList();
            list.Add(number1, power1);
            list.Add(number2, power2);
            list.Add(number3, power3);

            //act
            double result = Program.Meaning(list, x);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}