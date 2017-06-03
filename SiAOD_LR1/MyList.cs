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
        }

        //упрощение выражения
        public void Simplify()
        {
            //индексаторы нужны для того что бы пропуска
            //проверяемый элемент при сравнии
            int index = 0;
            bool isEnd = false, delete = false;
            Item item = new Item();
            //пока основной не кончился сверяю его с локальным
            //и объединяю члены с одинаковыми степенями
            while (!isEnd)
            {
                ReverseBegin();
                index++;
                //проходим в глуь списка по индексу
                for (int i = 0; i < index; i++)
                {
                    if (List.Next != null)
                        List = List.Next;
                    else
                        isEnd = true;
                }
                //записываем в предыдущий перебираемый элемент
                //получившуюся сумму
                List.Back.Number += item.Number;
                //счётчик для вложенного цикла
                //стартовый индекс
                int localIndex = index;
                item = new Item()
                {
                    Number = 0,
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
                        try
                        {
                            local.Next = List.Next.Next;
                            List.Next.Back = local;
                            List = local;
                            localIndex--;
                        }
                        catch
                        {
                            //создание буферного элемента списка
                            //для корректного извлечения последнего
                            List = local;
                            List.Next = new Item()
                            {
                                Back = List
                            };
                            List = List.Next;
                            delete = true;
                            break;
                        }
                    }
                }
            }
            //удаление буферного элемента списка (последнего)
            if (delete)
            {
                DeleteEnd();
            }
            ReverseBegin();
        }

        //удаление последнего
        public void DeleteEnd()
        {
            ReverseEnd();
            List = List.Back;
            List.Next = null;
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

        public string GetPolynomial()
        {
            ReverseBegin();
            string result = "";
            while (List.Next != null)
            {
                List = List.Next;
                result += GenerateMember(List.Number, List.Power);
            }
            result += GenerateMember(List.Number, List.Power);
            return result;
        }

        public string GenerateMember(int number, int power)
        {
            return number.ToString() + "+(X^" + power.ToString() + ")";
        }
    }
}