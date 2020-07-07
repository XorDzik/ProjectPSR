using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectServiceLibary
{
    [ServiceContract]
    public interface IDiffFilesInterface
    {
        [OperationContract]
        double calculateLevenhstein(String s, String t);

        [OperationContract]
        double percentCalculate(double distanceLevenhstein, double firstTextLenght);
    }
}
