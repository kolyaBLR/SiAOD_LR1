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
            for (int i = 0; i < 3; i++)
            {
                first.Add(rnd.Next(0, 20), rnd.Next(0, 20));
                second.Add(rnd.Next(0, 20), rnd.Next(0, 20));
                //third.Add(rnd.Next(0, 20), rnd.Next(0, 20));
            }
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

            p.ReverseEnd();
            r.ReverseBegin();
            p.List.Next = r.List.Next;

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
