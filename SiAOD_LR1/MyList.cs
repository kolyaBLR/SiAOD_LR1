using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR1
{
    class MyList
    {
        private Item list;

        public MyList() { list = new Item(); }

        public void add(int number, int power)
        {
            //reverseEnd();
            //Item local = new Item(number, power);
            //local.Back = list;
            //list.Next = local;
            //list = local;
        }

        //функция для перехода к концу списка
        public void reverseEnd()
        {
            while (list.Next != null)
            {
                list = list.Next;
            }
        }

        //функция для перехода к началу списка
        public void reverseBegin()
        {
            while (list.Back != null)
            {
                list = list.Back;
            }
            if (list.Back != null && list.Next != null)
                list = list.Next;
        }
    }
}