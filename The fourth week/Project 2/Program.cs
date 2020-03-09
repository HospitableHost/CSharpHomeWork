using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Misson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Form的构造方法的6个参数分别是闹钟的初始时间和闹钟设置的响铃时间
            Form form = new Form(16,25,30,16,25,50);
            form.myclock.Start();
        }
    }

    class Clock
    {
        //闹钟当前的时间
        public int hour{ get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        //闹钟所设置的时间
        public int Alarmhour { get; set; }
        public int Alarmminute { get; set; }
        public int Alarmsecond { get; set; }
        public Clock(int hour,int minute,int second, int Alarmhour,int Alarmminute,int Alarmsecond)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.Alarmhour = Alarmhour;
            this.Alarmminute = Alarmminute;
            this.Alarmsecond = Alarmsecond;
        }
        public event Action Tick;//Tick事件
       public event Action Alarm;//Alarm事件
       public void Start()
        {
            while(true)
            {
                System.Threading.Thread.Sleep(1000);
                second = (second + 1) % 60;
                if (second == 0)
                {
                    minute = (minute + 1) % 60;
                    if(minute==0)
                        hour=(hour+1)%24;
                }
                Tick();
                Alarm();
                
            }
        }//每1s触发一次Tick事件和Alarm事件

    }
    class Form
    {

        public Clock myclock;
        //Form的构造方法的6个参数分别是闹钟的初始时间和闹钟设置的响铃时间
        public Form(int hour1, int minute1, int second1, int Alarmhour1, int Alarmminute1, int Alarmsecond1)
        {
            myclock = new Clock(hour1, minute1,second1,Alarmhour1,Alarmminute1,Alarmsecond1);
            myclock.Tick += TickHandler;
            myclock.Alarm += AlarmHandler;
        }
        public void TickHandler()
        {
            Console.WriteLine($"当前时间为 {myclock.hour}:{myclock.minute}:{myclock.second}");
        }
        public void AlarmHandler()
        {
            if (myclock.Alarmhour == myclock.hour && myclock.Alarmminute == myclock.minute && myclock.Alarmsecond == myclock.second)
                Console.WriteLine("Alarm，闹钟响了");
        }
    }

}
