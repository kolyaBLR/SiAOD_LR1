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
            MyList list1 = new MyList();
            list1.Add(1, 2);
            list1.Add(3, 3);
            list1.Add(2, 1);

            MyList list2 = new MyList();
            list2.Add(0, 2);
            list2.Add(1, 0);
            list2.Add(2, 2);

            int x = 1;
            int expected = 9;

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
            int expected = 21;

            MyList resultList = new MyList();

            //act
            Program.Add(ref resultList, list1, list2);
            double result = Program.Meaning(resultList, x);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
