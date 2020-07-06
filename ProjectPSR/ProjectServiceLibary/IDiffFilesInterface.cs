using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectServiceLibary
{
    [ServiceContract (SessionMode = SessionMode.Required, CallbackContract = typeof(IDiffFilesInterfaceCallback))]
    public interface IDiffFilesInterface
    {
        [OperationContract(IsOneWay = true)]
        void exampleOperationForStartHost();
    }

    public interface IDiffFilesInterfaceCallback
    {
        [OperationContract(IsOneWay = true)]
        void exampleStartCallback(double result);
    }
}
