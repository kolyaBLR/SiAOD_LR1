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

            first.Add(1, 2);
            first.Add(3, 3);
            first.Add(1, 1);
            first.Add(1, 1);
            first.Add(3, 3);

            second.Add(1, 2);
            second.Add(2, 3);
            second.Add(1, 3);
            second.Add(2, 1);
            second.Add(3, 3);

            Equality(first, second);

            double result = Meaning(first, 5);
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
            p.List.Next.Back = p.List;

            p.Simplify();
        }

        //логическую функцию Equality(p,q), проверяющую равенство многочленов p и q
        static public bool Equality(MyList p, MyList q)
        {
            p.Simplify();
            q.Simplify();
            while (!p.IsEnd())
            {
                p.List = p.List.Next;
                q.ReverseBegin();
                while (!q.IsEnd())
                {
                    q.List = q.List.Next;
                    if (q.List.Number == p.List.Number && q.List.Power == p.List.Power)
                    {
                        Delete(ref p);
                        Delete(ref q);
                        break;
                    }
                }
            }
            return Comparison(p, q);
        }

        static private bool Comparison(MyList p, MyList q)
        {
            bool result = true;
            p.ReverseBegin();
            q.ReverseBegin();
            while(!p.IsEnd())
            {
                if (p.List != q.List)
                {
                    result = false;
                }
                p.List = p.List.Next;
                q.List = q.List.Next;
            }
            return result;
        }

        //функцию Meaning(p, x), вычисляющую значение многочлена в целочисленной точке х
        static public double Meaning(MyList p, int x)
        {
            double result = 0;
            p.ReverseBegin();
            while (!p.IsEnd())
            {
                p.List = p.List.Next;
                result += p.List.Number * Math.Pow(x, p.List.Power);
            }
            return result;
        }

        static private void Delete(ref MyList index)
        {
            Item local = index.List = index.List.Back;
            try
            {
                local.Next = index.List.Next.Next;
                index.List.Next.Back = local;
                index.List = local;
            }
            catch { }
        }
    }
}