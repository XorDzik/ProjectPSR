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
        IDictionary<int, string> compareFileLetterByLetter(string firstFileName, string secondFileName, int pattern);

        [OperationContract]
        IDictionary<int, string> compareFileWordByWord(string firstFileName, string secondFileName, int pattern);

        [OperationContract]
        double compareFileLetterByLetterAndCalculateProbability(string firstFileName, string secondFileName, int pattern);

        [OperationContract]
        double percentCalculate(double howManyTheSameLetters, double firstFileLength);

        [OperationContract]
        IDictionary<int, string> getTheSameElementsPosSecondFile();

        [OperationContract]
        void clearTheSameElementsPosSecondFile();
    }
}
