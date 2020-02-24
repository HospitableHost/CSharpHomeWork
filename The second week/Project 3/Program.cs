using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 任务3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("本任务用“埃氏筛法”求2~ 100以内的素数。");
            Console.WriteLine("求得素数如下：");
            int extent = 100;//求extent以内的所有素数


            bool[] a = new bool[extent+1];//a[0]不用，a[i]的值表示i是否是素数
            for(int i=0;i<extent+1;i++)//将a数组的所有元素全部初始化为true
            {
                a[i] = true;
            }
            a[0] = a[1] = false;


            int count = 0;//记录因子对数
            for(int i=2;i*i<=extent;i++)//埃氏筛法
            {
                if (a[i] == false)//如果a[i]是false的话，那就意味着i一定不是素数，那就没必要执行下边的操作了，直接进入下一次循环
                    continue;
                count = 0;
                for(int j=2;j*j<=i;j++)//记录i的因子对数，以判断i是不是素数
                {
                    if (i % j == 0)
                        count++;
                }
                if(count==0)//i是素数，把i的倍数剔除
                {
                    for (int k = 2; i * k <= extent; k++)//将i的倍数都剔除
                        a[i * k] = false;
                }
                else//i不是素数，要记得把i剔除掉
                {
                    a[i] = false;
                }
            }


            for(int i = 0; i < extent + 1; i++)//输出extent以内的所有素数
            {
                if(a[i]==true)
                Console.WriteLine($"{i}");
            }
        }
    }
}
