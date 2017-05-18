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
            ReverseBegin();
            //отдаём локальному основной, оба списка в начале
            MyList clone = new MyList()
            {
                List = List
            };

            //индексаторы нужны для того что бы пропускать
            //одинаковые члены при сравнении с локальной копией
            int index = 0, localIndex = 0;

            //пока основной не кончился сверяю его с локальным
            //и объединяю члены с одинаковыми степенями
            while (!IsEnd())
            {
                List = List.Next;
                index++;
                localIndex = 0;
                while (!clone.IsEnd())
                {
                    clone.List = clone.List.Next;
                    localIndex++;
                    if (clone.List.Power == List.Power && index != localIndex)
                    {
                        List.Number += clone.List.Number;
                        //удаление записанного члена многочлена у клона
                        Item local = clone.List.Next;
                        local.Back = clone.List.Back;
                        clone.List.Back.Next = local;
                        clone.List = local;
                        //переход на предыдущий член И ЕЩЁ УМЕНЬШИТЬ ИНДЕКС!!!
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