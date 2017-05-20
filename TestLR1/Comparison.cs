using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiAOD_LR1;

namespace TestLR1
{
    [TestClass]
    public class Comparison
    {
        [TestMethod]
        public void Comparison1()
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

            bool expected = false;

            MyList resultList = new MyList();

            //act
            bool result = Program.Equality(list1, list2);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Comparison2()
        {
            //arrange
            MyList list1 = new MyList();
            list1.Add(1, 2);
            list1.Add(3, 3);
            list1.Add(2, 1);

            MyList list2 = new MyList();
            list2.Add(1, 2);
            list2.Add(2, 1);
            list2.Add(3, 3);

            bool expected = true;

            MyList resultList = new MyList();

            //act
            bool result = Program.Equality(list1, list2);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Comparison3()
        {
            //arrange
            MyList list1 = new MyList();
            list1.Add(1, 2);
            list1.Add(3, 3);
            list1.Add(1, 1);
            list1.Add(1, 1);

            MyList list2 = new MyList();
            list2.Add(1, 2);
            list2.Add(2, 3);
            list2.Add(1, 3);
            list2.Add(2, 1);

            bool expected = true;

            MyList resultList = new MyList();

            //act
            bool result = Program.Equality(list1, list2);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Comparison4()
        {
            //arrange
            MyList list1 = new MyList();
            list1.Add(1, 2);
            list1.Add(3, 3);
            list1.Add(1, 1);
            list1.Add(1, 1);
            list1.Add(3, 3);

            MyList list2 = new MyList();
            list2.Add(1, 2);
            list2.Add(2, 3);
            list2.Add(1, 3);
            list2.Add(2, 1);
            list1.Add(3, 3);

            bool expected = true;

            MyList resultList = new MyList();

            //act
            bool result = Program.Equality(list1, list2);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
