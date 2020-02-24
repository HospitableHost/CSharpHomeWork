using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 输出所有素数因子
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            int num;
            bool flag;
            Console.WriteLine("请输入待求素数因子的数据：");
            str=Console.ReadLine();
            flag = int.TryParse(str, out num);
            while(!flag)
            {
                Console.WriteLine("数据非整数，请重新输入：");
                flag = int.TryParse(str, out num);
            }
            int count;
            for (int i=2;i<=num;i++)
            {
                count = 0;
                for(int j=2;j<=i;j++)//计算i的因子数
                {
                    if (i % j == 0)
                        count++;
                }
                if (count == 1 && num % i == 0)//i是质数且是因子
                    Console.WriteLine($"素数因子{i},");
            }
        }
    }
}
