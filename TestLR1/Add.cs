using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiAOD_LR1;

namespace TestLR1
{
    [TestClass]
    public class Add
    {
        [TestMethod]
        public void Sum1()
        {
            //arrange
            int number1 = 2, power1 = 1, number2 = 3, power2 = 1, number3 = 2, power3 = 1;
            MyList list1 = new MyList();
            list1.Add(number1, power1);
            list1.Add(number2, power2);
            list1.Add(number3, power3);

            int number4 = 2, power4 = 1, number5 = 3, power5 = 1, number6 = 2, power6 = 1;
            MyList list2 = new MyList();
            list2.Add(number4, power4);
            list2.Add(number5, power5);
            list2.Add(number6, power6);

            int x = 1;
            int expected = 14;

            MyList resultList = new MyList();

            //act
            Program.Add(ref resultList, list1, list2);
            double result = Program.Meaning(resultList, x);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
