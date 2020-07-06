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
            Uri baseAddress = new Uri("http://localhost:8001/DiffFilesInterfaceImpl/");
            ServiceHost selfHost = new ServiceHost(typeof(DiffFilesInterfaceImpl), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IDiffFilesInterface), new WSDualHttpBinding(), "DiffFilesService");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                selfHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
                selfHost.Description.Behaviors.Add(smb);

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
