using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四则运算计算器
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;//读入操作数或运算种类
            double a, b;//两个操作数
            int cultype;//运算种类，1是加法，2是减法，3是乘法，4是除法
            Console.Write("请输入您要进行何种运算，输入1为加法，输入2为减法，输入3为乘法，输入4为除法   ");
            s = Console.ReadLine();
            cultype = Int32.Parse(s);
            while (cultype > 4 || cultype < 1)//运算种类不合法
            {
                
                Console.WriteLine();
                Console.Write("输入不符合条件，请重新输入   ");
                s = Console.ReadLine();
                cultype = Int32.Parse(s);
            }
            Console.WriteLine();
            Console.Write("输入第一个操作数   ");
            s = Console.ReadLine();
            a = Double.Parse(s);
            Console.Write("输入第二个操作数   ");
            s = Console.ReadLine();
            b = Double.Parse(s);
            while(cultype==4&&b==0)
            {
                Console.WriteLine();
                Console.Write("输入不能为0，请重新输入   ");
                s = Console.ReadLine();
                b = Double.Parse(s);
            }
            switch (cultype)
            {
                case 1 :
                    Console.Write($"{a + b}");
                    break;
                case 2 :
                    Console.Write($"{a - b}");
                    break;
                case 3:
                    Console.Write($"{a * b}");
                    break;
                case 4:
                    Console.Write($"{a / b}");
                    break;

            }


        }
    }
}
