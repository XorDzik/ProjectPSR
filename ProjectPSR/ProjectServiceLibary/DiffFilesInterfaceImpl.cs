using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace ProjectServiceLibary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class DiffFilesInterfaceImpl : IDiffFilesInterface
    {
        public const int ROUND_RESULT = 2; 
        public int compareFileLetterByLetter(string firstFileName, string secondFileName, int pattern)
        {
            int counter = 0;

            char[] firstFileContent = File.ReadAllText(firstFileName).ToCharArray();
            char[] secondFileContent = File.ReadAllText(secondFileName).ToCharArray();

            List<string> firstFileContentList = new List<string>();
            List<string> secondFileContentList = new List<string>();

            string tmpStr = "";
            int securityLength;

            for (int i = 0; i < firstFileContent.Length; i++)
            {
                securityLength = pattern + i;
                for (int j = i; j < securityLength; j++)
                {
                    if (securityLength <= firstFileContent.Length)
                        tmpStr += firstFileContent[j];
                }
                firstFileContentList.Add(tmpStr);

                if (securityLength >= firstFileContent.Length)
                    break;

                tmpStr = "";
            }

            tmpStr = "";
            for (int i = 0; i < secondFileContent.Length; i++)
            {
                securityLength = pattern + i;
                for (int j = i; j < securityLength; j++)
                {
                    if (securityLength <= secondFileContent.Length)
                        tmpStr += secondFileContent[j];
                }
                secondFileContentList.Add(tmpStr);

                if (securityLength >= firstFileContent.Length)
                    break;

                tmpStr = "";
            }

            foreach (string firstFileTxt in firstFileContentList)
            {
                foreach (string secondFileTxt in secondFileContentList)
                {
                    if (firstFileTxt == secondFileTxt)
                        counter++;
                }
            }

            int howManyTheSameLetters = counter + pattern;
            return howManyTheSameLetters;
        } 
       

        public double percentCalculate(double distanceLevenhstein, double firstTextLenght)
        {
            return Math.Round((1.0 - (distanceLevenhstein / firstTextLenght)) * 100, ROUND_RESULT);
        }
    }
}
