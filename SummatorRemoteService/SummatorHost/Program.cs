using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using SummatorRemoteService;
using static System.Runtime.Remoting.Channels.ChannelServices;

namespace SummatorHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Назначение порта сервису
            var tcpChanel = new TcpChannel(51495);
            // Регистрация канала
            RegisterChannel(tcpChanel, false);

            // Запуск экземпляра
            //var service = new SummatorRemoteService.SummatorRemoteService();
            // Регистрация сервиса, запускает определёный экземпляр сервиса, в соответствие с режимами WellKnownObjectMode
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SummatorRemoteService.SummatorRemoteService), "Summator", WellKnownObjectMode.SingleCall);

            Console.WriteLine("Service started");
            Console.ReadLine();
        }
    }
}
