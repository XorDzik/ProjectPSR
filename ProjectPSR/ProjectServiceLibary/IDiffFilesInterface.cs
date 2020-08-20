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
        int compareFileLetterByLetter(string firstFileName, string secondFileName, int pattern);

        [OperationContract]
        double compareFileLetterByLetterAndCalculateProbability(string firstFileName, string secondFileName, int pattern);

    }
}
