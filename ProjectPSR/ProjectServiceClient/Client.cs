using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectServiceClient.DiffFilesInterfaceRef;

namespace ProjectServiceClient
{
    static class Client
    {
        [STAThread]
        static void Main()
        {
            var uri = "net.tcp://192.168.0.24:8232/DiffFilesInterfaceImpl";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<IDiffFilesInterface>(binding);
            var endPoint = new EndpointAddress(uri);
            var proxy = channel.CreateChannel(endPoint);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
