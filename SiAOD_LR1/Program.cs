using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = Math.Pow(0, 2);
            MyList first = new MyList(), second = new MyList(), third = new MyList();
            Random rnd = new Random();
            int number1 = 2, power1 = 1, number2 = 3, power2 = 1, number3 = 2, power3 = 1;
            first.Add(number1, power1);
            first.Add(number2, power2);
            first.Add(number3, power3);
            int number4 = 2, power4 = 2, number5 = 2, power5 = 2, number6 = 2, power6 = 2;
            second.Add(number4, power4);
            second.Add(number5, power5);
            second.Add(number6, power6);
            //Meaning(first, 5);
            Add(ref third, first, second);
            Console.ReadKey();
        }

        // процедуру Add(p,q,r) вычисления суммы многочленов q и r, результат – многочлен  p
        static public void Add(ref MyList p, MyList q, MyList r)
        {
            p.ReverseEnd();
            q.ReverseBegin();
            p.List.Next = q.List.Next;
            q.List.Next.Back = p.List;

            p.ReverseEnd();
            r.ReverseBegin();
            p.List.Next = r.List.Next;
            r.List.Next.Back = r.List;

            p.Simplify();
        }

        //логическую функцию Equality(p,q), проверяющую равенство многочленов p и q
        static public bool Equality(MyList p, MyList q)
        {
            return true;
        }

        //функцию Meaning(p, x), вычисляющую значение многочлена в целочисленной точке х
        static public double Meaning(MyList p, int x)
        {
            double result = 0;
            p.ReverseBegin();
            while(!p.IsEnd())
            {
                p.List = p.List.Next;
                result += Math.Pow(x * p.List.Number, p.List.Power);
            }
            return result;
        }
    }
}
