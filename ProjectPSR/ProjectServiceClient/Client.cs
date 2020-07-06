using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectServiceClient.DiffFilesInterfaceRef;

namespace ProjectServiceClient
{
    public class CallbackHandler : IDiffFilesInterfaceCallback
    {
        public void exampleStartCallback(double result)
        {
            throw new NotImplementedException();
        }
    }


    static class Program
    {
        [STAThread]
        static void Main()
        {

            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
            DiffFilesInterfaceClient diffFilesInterfaceClient = new DiffFilesInterfaceClient(instanceContext);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
