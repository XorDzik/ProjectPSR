using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectServiceLibary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class DiffFilesInterfaceImpl : IDiffFilesInterface
    {


        public void exampleOperationForStartHost()
        {
            Console.WriteLine("This is example operation for host because without it host cannot start work.");
        }

        IDiffFilesInterfaceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IDiffFilesInterfaceCallback>();
            }
        }
    }
}
