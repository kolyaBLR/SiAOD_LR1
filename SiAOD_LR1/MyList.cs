using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR1
{
    public class MyList
    {
        public Item List { get; set; }

        public MyList() { List = new Item(); }

        //добавление нового члена
        public void Add(int number, int power)
        {
            ReverseEnd();
            Item local = new Item()
            {
                Number = number,
                Power = power,
                Back = List
            };
            List.Next = local;
            List = local;
            //Simplify();
        }

        //упрощение выражения
        public void Simplify()
        {
            //индексаторы нужны для того что бы пропуска
            //проверяемый элемент при сравнии
            int index = 0;
            bool isEnd = false;
            Item item = new Item();
            //пока основной не кончился сверяю его с локальным
            //и объединяю члены с одинаковыми степенями
            while (!isEnd)
            {
                ReverseBegin();
                index++;
                for (int i = 0; i < index; i++)
                {
                    List = List.Next;
                    if (List.Next == null)
                        isEnd = true;
                }
                if (List.Back.Back != null)
                {
                    List.Back.Number = item.Number;
                    List.Back.Power = item.Power;
                }
                int localIndex = index;
                item = new Item()
                {
                    Number = List.Number,
                    Power = List.Power
                };
                while (!IsEnd())
                {
                    localIndex++;
                    List = List.Next;
                    if (List.Power == item.Power && index != localIndex)
                    {
                        item.Number += List.Number;
                        //удаление записанного члена многочлена
                        Item local = List = List.Back;
                        local.Next = List.Next;
                        List = local;
                        localIndex--;
                    }
                }
            }
        }

        //являемся ли мы в начале списка
        public bool IsBegin()
        {
            return List.Back == null && List.Next != null;
        }

        //являемся ли мы в конце списка
        public bool IsEnd()
        {
            return List.Next == null;
        }

        //функция для перехода к началу списка
        public void ReverseBegin()
        {
            while (List.Back != null)
            {
                List = List.Back;
            }
            if (List.Back != null && List.Next != null)
                List = List.Next;
        }

        //функция для перехода к концу списка
        public void ReverseEnd()
        {
            while (List.Next != null)
            {
                List = List.Next;
            }
        }
    }
}