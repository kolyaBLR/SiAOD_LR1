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

        [TestMethod]
        public void Sum2()
        {
            //arrange
            MyList list1 = new MyList();
            list1.Add(1, 2);
            list1.Add(3, 4);
            list1.Add(5, 3);

            MyList list2 = new MyList();
            list2.Add(7, 2);
            list2.Add(4, 3);
            list2.Add(1, 2);

            int x = 1;
            int expected = 321;

            MyList resultList = new MyList();

            //act
            Program.Add(ref resultList, list1, list2);
            double result = Program.Meaning(resultList, x);

            //assert
            Assert.AreEqual(expected, result);
        }     

        [TestMethod]
        public void Sum3()
        {
            //arrange
            int x = 2;
            int number1 = 2, power1 = 3, number2 = 3, power2 = 3;
            double expected = 280;
            MyList list = new MyList();
            list.Add(number1, power1);
            list.Add(number2, power2);
            MyList resultList = new MyList();

            //act
            Program.Add(ref resultList, list, list);
            double result = Program.Meaning(list, x);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sum4()
        {
            //arrange
            int x = -2;
            int number1 = -1, power1 = 0, number2 = 0, power2 = 1, number3 = 1, power3 = 0;
            double expected = 2;
            MyList list = new MyList();
            list.Add(number1, power1);
            list.Add(number2, power2);
            list.Add(number3, power3);
            MyList resultList = new MyList();

            //act
            Program.Add(ref resultList, list, list);
            double result = Program.Meaning(list, x);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
