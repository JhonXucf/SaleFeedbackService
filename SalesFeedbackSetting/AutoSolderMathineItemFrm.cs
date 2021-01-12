using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SalesFeedbackSetting
{
    public enum MathineType
    {
        DW800 = 1,
        ID900 = 2
    }

    public partial class AutoSolderMathineItemFrm : Form
    {
        public MathineType _MathineType;
        public string[] _Result = new string[6];
        public AutoSolderMathineItemFrm(string[] result, MathineType mathineType)
        {
            InitializeComponent();
            System.Net.IPHostEntry ips = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            var ip = ips.AddressList.FirstOrDefault(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            if (!string.IsNullOrEmpty(ip.ToString()))
            {
                this.textBox5.Text = ip.ToString();
            }
            else
            {
                this.textBox5.Text = "127.0.0.1";
            }
            if (mathineType == MathineType.DW800)
            {
                this.label2.Text = "DW800机器";
                this.textBox6.Text = "1234";
            }
            else
            {
                this.label2.Text = "DW900机器";
                this.textBox6.Text = "502";
            }
            if (result != null && result.Length > 0)
            {
                this.textBox1.Text = result[0];
                this.textBox2.Text = result[1];
                this.textBox3.Text = result[2];
                this.textBox4.Text = result[3];
                this.textBox5.Text = result[4];
                this.textBox6.Text = result[5];
            }
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            var reg = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
            if (!reg.IsMatch(this.textBox5.Text))
            {
                MessageBox.Show("IP地址输入有误，请重新输入！");
                return;
            }
            _Result[0] = this.textBox1.Text;
            _Result[1] = this.textBox2.Text;
            _Result[2] = this.textBox3.Text;
            _Result[3] = this.textBox4.Text;
            _Result[4] = this.textBox5.Text;
            _Result[5] = this.textBox6.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
