using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using SummatorRemoteService;//Указывается ссылка на проект с сервисом
using static System.Runtime.Remoting.Channels.ChannelServices;

namespace SummatorClient
{
    public partial class Form1 : Form
    {
        private readonly ISummatorRemoteService _instance;

        public Form1()
        {
            InitializeComponent();
            var chanel = new TcpChannel();
            //Регистрация канала клиента, без разницы какой у него будет порт.
            RegisterChannel(chanel, false);

            // Получаем экземпляр сервиса по юрл
            _instance = Activator.GetObject(typeof(ISummatorRemoteService), "tcp://localhost:51495/Summator") as ISummatorRemoteService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = _instance.GetSum(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
        }
    }
}
