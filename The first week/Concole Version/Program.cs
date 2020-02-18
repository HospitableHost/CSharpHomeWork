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
            bool flag;//用来指示string转int或double是否成功

            while (true)
            {
                Console.Write("请输入您要进行何种运算，输入1为加法，输入2为减法，输入3为乘法，输入4为除法   ");
                s = Console.ReadLine();
                flag = Int32.TryParse(s, out cultype);
                while (flag == false || cultype > 4 || cultype < 1)//运算种类不合法
                {

                    Console.WriteLine();
                    Console.Write("输入不符合条件，请重新输入   ");
                    s = Console.ReadLine();
                    flag = Int32.TryParse(s, out cultype);
                }
                Console.WriteLine();
                Console.Write("输入第一个操作数   ");
                s = Console.ReadLine();
                flag = Double.TryParse(s, out a);
                while (flag == false)//转换失败
                {

                    Console.WriteLine();
                    Console.Write("输入不符合条件，请重新输入   ");
                    s = Console.ReadLine();
                    flag = Double.TryParse(s, out a);
                }
                Console.WriteLine();
                Console.Write("输入第二个操作数   ");
                s = Console.ReadLine();
                flag = Double.TryParse(s, out b);
                while (flag == false || (cultype == 4 && b == 0))//转换失败
                {

                    Console.WriteLine();
                    Console.Write("输入不符合条件，请重新输入   ");
                    s = Console.ReadLine();
                    flag = Double.TryParse(s, out b);
                }
                switch (cultype)
                {
                    case 1:
                        Console.Write($"{a + b}");
                        break;
                    case 2:
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
}
