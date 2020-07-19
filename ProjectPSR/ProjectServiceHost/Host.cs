using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectServiceLibary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ProjectServiceHost
{
    class Host
    {
        static void Main(string[] args)
        {
            var uris = new Uri[1];
            string adr = "net.tcp://192.168.0.24:8232/DiffFilesInterfaceImpl";
            uris[0] = new Uri(adr);
           // Uri baseAddress = new Uri("http://localhost:8001/DiffFilesInterfaceImpl/");
            ServiceHost selfHost = new ServiceHost(typeof(DiffFilesInterfaceImpl), uris);

            try
            {
                var binding = new NetTcpBinding(SecurityMode.None);
                selfHost.AddServiceEndpoint(typeof(IDiffFilesInterface), binding, "DiffFilesService");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = false;

              

              //  selfHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
              //  selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("Host working....");
                Console.WriteLine("Press <ENTER> to finish work.");
                Console.WriteLine();
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("I catch exception: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
