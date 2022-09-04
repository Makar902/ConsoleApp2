using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

//Написать класс Money, предназначенный для хранения денежной суммы (в гривнах и копейках). Для класса
//реализовать перегрузку операторов + (сложение денежных сумм), – (вычитание сумм), / (деление суммы на целое
//число), *(умножение суммы на целое число), ++(сумма
//увеличивается на 1 копейку), --(сумма уменьшается на
//1 копейку), <, >, ==, !=.
//Класс не может содержать отрицательную сумму.
//В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует
//исключительную ситуацию «Банкрот».
//Программа должна с помощью меню продемонстрировать все возможности класса Money.
//Обработка исключительных ситуаций производится в программе.

namespace ConsoleApp1
{
    internal class Program
    {

        [DllImport("msvcrt.dll")]
        static extern int system(string command);

        static void Main(string[] args)
        {
           for(;;)
            {
                system("color 06");
                Console.WriteLine("Enter amount hrn and kop(example: 7,20)");
                Money m = new Money(Console.ReadLine());
                Console.WriteLine("1-+ "+ "2-'-' "+ "3-/ "+ "4-* "+ "5-++ "+
                    "6-'--' "+ "7- "+ "8-< "+ "9-== "+ "10-!= "+"\n");
                m.Print();
                Console.WriteLine("Enter number ");
                Money d = new Money(Console.ReadLine());
                dynamic copy = m.a;
                // dynamic menu=int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter value");
                //dynamic value=double.Parse(Console.ReadLine());
                m.a+=d.a;
                m.Print();
                m.a=copy;

                m.a-=d.a;
                m.Print();
                m.a=copy;


                m.a/=d.a;
                m.Print();
                m.a=copy;


                m.a*=d.a;
                m.Print();
                m.a=copy;

                m.a++;
                m.Print();
                m.a=copy;

                m.a--;
                m.Print();
                m.a=copy;

                bool a = m.a>d.a;
               Console.WriteLine(a);
               // m.a=copy;

                bool b = m.a<d.a;
                Console.WriteLine(b);
                //m.Print();
               // m.a=copy;

                bool c = m.a==d.a;
                Console.WriteLine(c);
                //m.Print();
                //m.a=copy;

                bool e = m.a!=d.a;
                Console.WriteLine(e);
               // m.Print();
                //m.a=copy;

            }
        }
    }
    public class Money
    {
        public double a;
        public Money(dynamic a)
        {
            try
            {
                this.a=double.Parse(a);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                this.a=1.1;
                Console.WriteLine("Money will have default value(1 hrn,1 cop)");
            }
        }
        public dynamic Print()
        {
            if (a<0)
            {
                throw new Exception("U have no money!Loser!");
            }
            else
            {
                Console.WriteLine("Money: "+a);
            }
            return 0;
        }
        static public dynamic operator+(Money c1, Money c2)
        {
           return new Money(c1.a+c2.a);
        }
        static public dynamic operator+(Money c1, double c2)
        {
            return new Money(c1.a+c2);
        }
        static public dynamic operator+(double c1, Money c2)
        {
            return new Money(c1+c2.a);
        }

        static public dynamic operator -(Money c1, Money c2)
        {
            return new Money(c1.a-c2.a);
        }
        static public dynamic operator -(Money c1, double c2)
        {
            return new Money(c1.a-c2);
        }
        static public dynamic operator -(double c1, Money c2)
        {
            return new Money(c1-c2.a);
        }

        static public dynamic operator /(Money c1, Money c2)
        {
            return new Money(c1.a/c2.a);
        }
        static public dynamic operator /(Money c1, double c2)
        {
            return new Money(c1.a/c2);
        }
        static public dynamic operator /(double c1, Money c2)
        {
            return new Money(c1/c2.a);
        }

        static public dynamic operator *(Money c1, Money c2)
        {
            return new Money(c1.a*c2.a);
        }
        static public dynamic operator *(Money c1, double c2)
        {
            return new Money(c1.a*c2);
        }
        static public dynamic operator *(double c1, Money c2)
        {
            return new Money(c1*c2.a);
        }

        static public Money operator ++(Money c1)
        {
            dynamic x = c1.a+0.1;
            return new Money(x);
        }
        static public Money operator --(Money c1)
        {
            dynamic x = c1.a-0.1;
            return new Money(x);
        }

        static public dynamic operator>(Money c1, Money c2)
        {
            return c1.a>c2.a;
        }
        static public dynamic operator <(Money c1, Money c2)
        {
            return c1.a<c2.a;
        }

        static public dynamic operator ==(Money c1, Money c2)
        {
            return c1.a==c2.a;
        }
        static public dynamic operator !=(Money c1, Money c2)
        {
            return c1.a!=c2.a;
        }

    }

}
