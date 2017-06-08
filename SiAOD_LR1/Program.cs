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

            int[,,] array = new int[2, 5, 8]
                {
                    {
                    { 7, 3, -1, 2, -2, 2, 1, -6 },
                    { -8, -5, 1, 6, 3, 5, 1, -5 },
                    { 6, 2, -1, -9, -7, -4, 1, 2 },
                    { -9, -4, 1, 3, 6, 5, -1, -4 },
                    { 3, 7, -1, 4, -4, 8, 1, -3 },
                    },
                    {
                    { 4, 2, 1, 0, 5, 3, 1, 0 },
                    { 7, 4, 1, 0, 4, 2, 1, 0 },
                    { 3, 2, 1, 0, 6, 4, 1, 0 },
                    { 6, 5, 1, 0, 9, 8, 1, 0 },
                    { 5, 4, 1, 0, 7, 5, 1, 0 },
                    }
                };

            for (int i = 0; i < 5; i++)
            {
                first = new MyList();
                second = new MyList();
                third = new MyList();
                for (int j = 0; j < 4; j++)
                    first.Add(array[0, i, j], array[1, i, j]);
                for (int j = 4; j < 8; j++)
                    second.Add(array[0, i, j], array[1, i, j]);
                Add(ref third, first, second);
                Console.WriteLine("Number of equation {0}", i + 1);
                Console.WriteLine("p {0}", third.GetPolynomial());
                Console.WriteLine("Meaning {0} ", Meaning(first, 5));
                Console.WriteLine("Equality {0}", Equality(first, second));
                Console.WriteLine();
            }
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
            while (!p.IsEnd())
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