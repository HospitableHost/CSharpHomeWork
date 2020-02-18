using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 四则运算计算器窗体版
{
    public partial class 四则运算计算器 : Form
    {
        public 四则运算计算器()
        {
            InitializeComponent();
        }
        double val1, val2;//两个操作数
        string cultype;//运算类型
        bool flag1;//指明string转double是否成功
        bool flag2;//指明string转double是否成功

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                val2 = 0;
            else
            {
                flag2 = Double.TryParse(textBox2.Text,out val2);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            cultype = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cultype)
            {
                case "+" :
                    textBox3.Text = $"{val1+val2}";
                    label2.Text = "计算正确";
                    break;
                case "-":
                    textBox3.Text = $"{val1-val2}";
                    label2.Text = "计算正确";
                    break;
                case "*":
                    textBox3.Text = $"{val1*val2}";
                    label2.Text = "计算正确";
                    break;
                case "/":
                    if (val2 == 0)
                    {
                        label2.Text = "被除数为0，不能计算，请重新输入被除数";
                        textBox3.Text = "error";
                    }
                    else
                    {
                        textBox3.Text = $"{val1 / val2}";
                        label2.Text = "计算正确";
                    }
                    break;
                default:
                    label2.Text = "运算符错误，只支持四则运算，请重新输入运算符";
                    textBox3.Text = "error";
                    break;
            }
            if (!(flag1 && flag2))//检测两个操作数是否正确
            {
                label2.Text = "操作数出错，请检查操作数";
                textBox3.Text = "error";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                val1 = 0;
            else
            {
                flag1 = Double.TryParse(textBox1.Text, out val1);
            }

        }
    }
}
