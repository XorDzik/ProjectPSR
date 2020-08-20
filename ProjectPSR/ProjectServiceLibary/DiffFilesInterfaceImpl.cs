using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
            int howManyTheSameLetters = 0;

            char[] firstFileContent = File.ReadAllText(firstFileName).ToCharArray();
            char[] secondFileContent = File.ReadAllText(secondFileName).ToCharArray();

            List<string> firstFileContentList = new List<string>();
            List<string> secondFileContentList = new List<string>();
            List<int> list = new List<int>();

            var position = new Dictionary<string, string>();

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
       
            int firstCounter = 0;
            int secondCounter = 0;

            if (pattern == 1 || pattern == 2)
            {
                pattern = 1;
            }
            
            foreach (string firstFileTxt in firstFileContentList)
            {
                foreach (string secondFileTxt in secondFileContentList)
                {
                    secondCounter++;
                    if (firstFileTxt == secondFileTxt)
                    {
                        int lastPositionFirstFile = firstCounter + pattern;
                        int lastTheSamePositionSecondFile = secondCounter + pattern;

                        position.Add(firstCounter.ToString() + ";" + lastPositionFirstFile.ToString(), secondCounter.ToString() + ";" + lastTheSamePositionSecondFile.ToString());
                    }
                }
                firstCounter++;
            }

            string[] keys;
            foreach (var x in position)
            {
                keys = x.Key.Split(';');
                for (int i = 0; i < keys.Length; i++)
                {
                    list.Add(int.Parse(keys[i]));
                }
            }

            for (int i = 0; i < list.Count(); i = i + 2)
            {
                if (list[i + 1] - list[i] == 1)
                {
                    howManyTheSameLetters += 2;
                }
                else if (i > 0 && list[i] < list[i - 1])
                {
                    howManyTheSameLetters = (list[i + 1] - list[i - 1]) + howManyTheSameLetters;
                }
                else
                {
                    howManyTheSameLetters = (list[i + 1] - list[i]) + howManyTheSameLetters;
                }
            }

            return howManyTheSameLetters;
        }

        public double compareFileLetterByLetterAndCalculateProbability(string firstFileName, string secondFileName, int pattern)
        {
            int firstFileLength = File.ReadAllText(firstFileName).Length;

            int howManyTheSameLetters = compareFileLetterByLetter(firstFileName, secondFileName, pattern);
            return percentCalculate(howManyTheSameLetters, firstFileLength);
        }

        public double percentCalculate(double howManyTheSameLetters, double firstFileLength)
        {
            return Math.Round((howManyTheSameLetters / firstFileLength) * 100, ROUND_RESULT);
        }
    }
}
