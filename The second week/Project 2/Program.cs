using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 任务2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("本程序将求一个整数数组的最大值、最小值、平均值和所有数组元素的和。");
            Console.Write("请输入所求整数数组的长度：");
            int lengthOfArray;//待求整数数组长度
            string str;
            str=Console.ReadLine();
            Console.WriteLine("");
            while (!Int32.TryParse(str, out lengthOfArray))
            {
                Console.Write("输入不合法，请重新输入：");
                str = Console.ReadLine();
                Console.WriteLine("");
            }
            int[] a = new int[lengthOfArray];
            int data;
            int max=0, min=0, sum=0;
            for(int i=0;i<lengthOfArray;i++)//输入数组的所有元素值,并且在过程中计算max，min和sum
            {
                Console.Write($"请输入数组第{i}个元素的值：");
                str = Console.ReadLine();
                Console.WriteLine("");
                while (!Int32.TryParse(str, out data))
                {
                    Console.Write("输入不合法，请重新输入：");
                    Console.WriteLine("");
                    str = Console.ReadLine();
                }
                a[i] = data;
                if (i == 0)//先给max，min和sum初始化
                {
                    max = data;
                    min = data;
                    sum = data;
                }
                else
                {
                    max=max>data? max : data;
                    min=min<data? min : data;
                    sum += data;
                }
            }
            Console.WriteLine($"这个数组的最大值是{max},最小值是{min},平均值是{(double)sum/lengthOfArray},所有数组元素的和是{sum}");
        }
    }
}
