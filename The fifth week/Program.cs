using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 订单管理程序
{
    class Program
    {
        static void Main(string[] args)
        {
            //下边均为测试代码,先生成4个顾客，5个订单项,6个订单项List和6个订单
            Customer customer1 = new Customer("党自强","男","洪山区武汉大学信息学部学生宿舍13舍",20,"17396156570");
            Customer customer2 = new Customer("方正", "男", "洪山区武汉大学信息学部学生宿舍13舍", 20, "17396156571");
            Customer customer3 = new Customer("王涛", "男", "洪山区武汉大学信息学部学生宿舍13舍", 20, "17396156572");
            Customer customer4 = new Customer("沈志豪", "男", "洪山区武汉大学信息学部学生宿舍13舍", 20, "17396156573");
            OrderItem orderItem1 = new OrderItem("AK47",600,3);
            OrderItem orderItem2 = new OrderItem("UZI", 400, 1);
            OrderItem orderItem3 = new OrderItem("AK74", 500, 5);
            OrderItem orderItem4 = new OrderItem("M4A1", 550, 2);
            OrderItem orderItem5 = new OrderItem("巴雷特", 900, 1);
            List<OrderItem> orderItems1 = new List<OrderItem>();
            List<OrderItem> orderItems2 = new List<OrderItem>();
            List<OrderItem> orderItems3 = new List<OrderItem>();
            List<OrderItem> orderItems4 = new List<OrderItem>();
            List<OrderItem> orderItems5 = new List<OrderItem>();
            List<OrderItem> orderItems6 = new List<OrderItem>();
            orderItems1.Add(orderItem1); orderItems1.Add(orderItem2);
            orderItems2.Add(orderItem1); orderItems2.Add(orderItem2); orderItems2.Add(orderItem3);
            orderItems3.Add(orderItem4); orderItems3.Add(orderItem5);
            orderItems4.Add(orderItem5);
            orderItems5.Add(orderItem1); orderItems5.Add(orderItem2); orderItems5.Add(orderItem3); orderItems5.Add(orderItem5);
            orderItems6.Add(orderItem1);
            OrderService.AddOrder(1, orderItems1, customer1);
            OrderService.AddOrder(5, orderItems5, customer3);
            OrderService.AddOrder(6, orderItems6, customer4);
            OrderService.AddOrder(2, orderItems2, customer1);
            OrderService.AddOrder(3, orderItems3, customer1);
            OrderService.AddOrder(4, orderItems4, customer2);
            //测试AddOrder函数
            try
            {
                OrderService.AddOrder(2, orderItems1, customer1);
            }
            catch(OrderManagementException e)
            {
                Console.WriteLine("测试1：测试添加订单时，订单号重复，抛出异常。");
                Console.WriteLine("error code:" + e.Code + ",error message:" + e.Message);
            }
            //测试ModifyOrder函数
            try
            {
                OrderService.ModifyOrder(15,customer1,orderItems1);
            }
            catch (OrderManagementException e)
            {
                Console.WriteLine("测试2：修改订单时，订单不存在，抛出异常。");
                Console.WriteLine("error code:" + e.Code + ",error message:" + e.Message);
            }
            //测试DeleteOrder函数
            try
            {
                OrderService.DeleteOrder(15);
            }
            catch(OrderManagementException e)
            {
                Console.WriteLine("测试3：删除订单时，订单不存在，抛出异常。");
                Console.WriteLine("error code:" + e.Code + ",error message:" + e.Message);

            }
            //测试SearchOrder(int orderid)函数
            Console.WriteLine("测试4：根据订单号查询订单。");
            Console.WriteLine(OrderService.SearchOrder(5));
            //测试SearchOrder(string customer_name)函数
            Console.WriteLine("测试5：根据顾客名查询订单，返回订单List按总价值排序。");
            foreach (Order o in OrderService.SearchOrder("党自强"))
                Console.WriteLine(o);
            //测试SearchOrderByGoodsName(string goods_name)函数
            Console.WriteLine("测试6：根据商品名查询订单，返回订单List按总价值排序。");
            List<Order> ordertest = OrderService.SearchOrderByGoodsName("AK47");
            foreach (Order o in ordertest)
                Console.WriteLine(o);
            //测试无参数的排序函数
            Console.WriteLine("测试7：对订单表排序，默认按照订单号排序。");
            OrderService.Sort();
            foreach (Order o in OrderService.orders)
                Console.WriteLine(o);
            //测试参数为委托实例的排序函数
            Console.WriteLine("测试8：对订单表排序，按照Lamda表达式进行排序。");
            OrderService.Sort((q1,q2)=> { return (int)((q1.TotalPrice - q2.TotalPrice)*1000); });
            foreach (Order o in OrderService.orders)
                Console.WriteLine(o);

        }
    }

    class Order:IComparable
    {
        public int Orderid { get; set; }
        public DateTime CreateTime;
        public List<OrderItem> Orderitem;
        public Customer customer;
        public double TotalPrice;

        public Order(int orderid, List<OrderItem> orderitem, Customer customer)
        {
            Orderid = orderid;
            CreateTime = DateTime.Now;
            Orderitem = orderitem;
            this.customer = customer;
            TotalPrice = 0;
            foreach (OrderItem item in Orderitem)
                TotalPrice += item.goods.Price * item.quantity;


        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null &&
                   Orderid == order.Orderid;
        }

        public override int GetHashCode()
        {
            var hashCode = 275291625;
            hashCode = hashCode * -1521134295 + Orderid.GetHashCode();
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(Orderitem);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(customer);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string str = "订单号：" + Orderid + "     订单创建时间：" + CreateTime + "     订单总价："+TotalPrice+"\n" + customer;
            for (int i = 0; i < Orderitem.Count; i++)
                str += Orderitem[i];
            return str;
        }

        public bool ContainGoods (string goods_name)//判断某个商品是否在订单中
        {

            foreach (OrderItem item in Orderitem)
            {
                if (item.goods.Name == goods_name)
                    return true;
            }
            return false;
        }

        public double CalculateTotalprice()
        {
            double sum=0;
            foreach (OrderItem item in Orderitem)
                sum += item.goods.Price * item.quantity;
            return sum;
        }

        public int CompareTo(object obj)
        {
            Order o = obj as Order;
            if(o==null)
                throw new System.ArgumentException();
            return this.Orderid - o.Orderid;
        }
    }

    class OrderItem
    {
        public Goods goods;
        public double quantity;

        public OrderItem(string name,double price, double quantity)
        {
            goods = new Goods(price,name);
            this.quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            OrderItem item = obj as OrderItem;
            return item != null && item.goods.Name == this.goods.Name;
                  
        }

        public override int GetHashCode()
        {
            var hashCode = -664957775;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(goods);
            hashCode = hashCode * -1521134295 + quantity.GetHashCode();
            return hashCode;
        }

        public override string ToString ()
        {
            return goods + ",购买数量:" + quantity+"\n";
        }
        
    }

    class OrderService
    {
        public static List<Order> orders=new List<Order> (); 
        public static bool AddOrder (int orderid,List<OrderItem> orderitem,Customer customer)
        {
            if (SearchOrder(orderid) != null)
                throw new OrderManagementException("订单号已存在，添加订单失败。",1);
            Order order = new Order(orderid,orderitem,customer);
            orders.Add(order);
            return true;
        }
        public static bool ModifyOrder(int orderid,Customer customer, List<OrderItem> orderitem)//修改订单只支持通过订单号修改，返回值表示是否修改成功,只能修改顾客信息和订单项
        {
            Order order= SearchOrder(orderid);
            if (order == null)
                throw new OrderManagementException("订单不存在，修改订单失败。",2);
            order.customer = customer;
            order.Orderitem = orderitem;
            order.TotalPrice = order.CalculateTotalprice();
            return true;
        }
        public static bool DeleteOrder(int orderid)//删除订单只支持通过订单号删除，返回值表示是否删除成功
        {
          Order order =  SearchOrder(orderid);
            if (order == null)
                throw new OrderManagementException("订单不存在，删除订单失败。",3);
            orders.Remove(order);
            return true;
        }
        public static Order SearchOrder(int orderid)//订单号与订单是一对一的关系，返回值是订单的地址，可能为null
        {
            var query = from o in orders
                        where o.Orderid == orderid
                        select o;
            if (query.Count() == 0)
                return null;
            return query.First();
        }
        public static List<Order> SearchOrder(string customer_name)//通过顾客名查询订单，返回值是订单数组，且返回的数组中按照订单总金额排序，返回值可能为null
        {
            var query = from o in orders
                        where o.customer.Name == customer_name
                        select o;
            if (query.Count() == 0)
                return null;
            List<Order> orderlist = query.ToList();
            orderlist.Sort((p1, p2) => { return (int)((p1.TotalPrice - p2.TotalPrice)*1000); });
            return orderlist;
        }
        public static List<Order> SearchOrderByGoodsName(string goods_name)//通过商品名查询订单，返回值是订单数组，且返回的数组中按照订单总金额排序，返回值可能为null
        {
            var query = from o in orders
                        where o.ContainGoods(goods_name)
                        select o;
            if (query.Count() == 0)
                return null;
            List<Order> orderlist = query.ToList();
            orderlist.Sort((p1, p2) => { return (int)((p1.TotalPrice - p2.TotalPrice) * 1000); });
            return orderlist;

        }
        public static void Sort()//无参数的排序函数
        {
            orders.Sort();
        }
        public static void Sort(Func<Order, Order, int> func)//参数为委托实例的排序函数
        {
            orders.Sort((Order p1,Order p2)=> { return func(p1, p2); });
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; }

        public Customer(string name, string gender, string address, int age, string phoneNum)
        {
            Name = name;
            Gender = gender;
            Address = address;
            Age = age;
            PhoneNum = phoneNum;
        }
        public override string ToString ()
        {
            return "顾客姓名：" + Name + ",顾客性别：" + Gender + ",顾客年龄：" + Age + ",顾客地址：" + Address + ",顾客电话：" + PhoneNum+"\n";
        }
    }

    class Goods
    {
        public double Price { get; set; }
        public string Name { get; set; }

        public Goods(double price, string name)
        {
            Price = price;
            Name = name;
        }

        public override string ToString ()
        {
            return "货物名称：" + Name + ",货物单价：" + Price;
        }
    }

    class OrderManagementException:ApplicationException//自定义的异常类型
    {
        private int code;
        public int Code { get => code; }
        public OrderManagementException(string message,int code):base(message)
        {
            this.code = code;

         }

    }
}
