using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//在使用随机数时设置产生的随机正整数小于101，当然也可以不设限制，但是最后10个形状的总面积会很大很大很大很大，所以还是对边的大小设置一定的限制吧
//另外产生随机的边大小时，通过随机的正整数+一个随机的0-1的浮点数可以保证边一定是非负的浮点数
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalArea = 0;
            Shape p;
            for(int i=0;i<10;i++)//随机创建10个Shape，累加计算总面积
            {
                p = ShapeFactory.CreateShape();
                totalArea += p.GetArea();
            }
            Console.WriteLine($"通过工厂模式随机创建10个形状之后，计算得到这10个形状的总面积为：{totalArea}");
        }
    }
    abstract class Shape
    {
        public abstract double GetArea();//计算面积
        public abstract bool IsLegal();//判断形状是否合法

    }
    class Triangle : Shape
    {
        private double a, b, c;
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }
        public Triangle(double a,double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double GetArea()
        {
            if(!IsLegal())
            {
                Console.WriteLine("此形状不是三角形，计算面积无意义");
                return 0;
            }
            double p = (a + b + c) / 2;//周长
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
        public override bool IsLegal()
        {
            if (((a + b > c) || (a + c > b) || (b + c > a))&&a>0&&b>0&&c>0)
                return true;
            return false;
        }
    }
    class Square : Shape
    {
        private double _sideLength;
        public double sideLength { get => _sideLength; set => _sideLength = value; }
        public Square(double _sideLength)
        {
            this._sideLength = _sideLength;
        }
        public override double GetArea()
        {
            if (!IsLegal())
                {
                    Console.WriteLine("此形状不是正方" +
                        "形，计算面积无意义");
                    return 0;
                }
            return _sideLength * _sideLength;
        }
        public override bool IsLegal()
        {
            if (_sideLength > 0)
                return true;
            return false;
        }

    }
    class Rectangle : Shape
    {
        private double _length,_width;
        public double length { get => _length; set => _length = value; }
        public double width { get => _width; set => _width = value; }
        public Rectangle(double _length, double _width)
        {
            this._length = _length;
            this._width = _width;
        }
        public override double GetArea()
        {
            if (IsLegal())
                 return _length*_width;
          
            Console.WriteLine("此形状不是长方形，计算面积无意义");
            return 0;

        }
        public override bool IsLegal()
        {
            if (_length>0&&_width>0)
                return true;
            return false;
        }

    }
    class ShapeFactory
    {
        public static Shape CreateShape()
        {
            Random rd = new Random();
            int type=rd.Next(1,4);//type为1时创建的是长方形，为2时创建的是正方形，为3时创建的是三角形
            if(type==1)//创建长方形
            {
                Rectangle rectangle = new Rectangle(rd.Next(101)+rd.NextDouble(), rd.Next(101) + rd.NextDouble());//通过随机的正整数+一个随机的0-1的浮点数可以保证边一定是非负的浮点数
                return (Shape)rectangle;
            }
            else if(type==2)//创建正方形
            {
                Square square = new Square(rd.Next(101) + rd.NextDouble());
                return (Shape)square;
            }
            else//创建三角形
            {
                Triangle triangle = new Triangle(rd.Next(101) + rd.NextDouble(), rd.Next(101) + rd.NextDouble(), rd.Next(101) + rd.NextDouble());
                return (Shape)triangle;
            }
        }
    }
}
