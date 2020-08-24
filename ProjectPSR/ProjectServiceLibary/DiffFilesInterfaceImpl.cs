using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;

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

            List<string> firstFileContentList = charTabToList(firstFileContent, pattern);
            List<string> secondFileContentList = charTabToList(secondFileContent, pattern);
            List<int> list = new List<int>();

            var position = new Dictionary<string, string>();
       
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

                        if (position.ContainsKey(firstCounter.ToString() + ";" + lastPositionFirstFile.ToString()))
                            firstCounter++;

                        position.Add(firstCounter.ToString() + ";" + lastPositionFirstFile.ToString(), "");
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

        public void compareFileWordByWord(string firsFileName, string secondFileName, int pattern)
        {
            string[] firstFileContentTmp = File.ReadAllText(firsFileName).Split(' ');
            string[] secondFileContentTmp = File.ReadAllText(secondFileName).Split(' ');

            string[] firstFileContent = toLowerCase(firstFileContentTmp);
            string[] secondFileContent = toLowerCase(secondFileContentTmp);

        }

        public string[] toLowerCase(string[] fileContent)
        {
            string[] fileContentToReturn = new string[fileContent.Length];
            for (int i = 0; i < fileContent.Length; i++)
            {
                fileContentToReturn[i] = fileContent[i].ToLower();
            }

            return fileContentToReturn;
        }

        public List<string> charTabToList(char[] chars, int pattern)
        {
            string tmpStr = "";
            int securityLength = 0;

            List<string> contentList = new List<string>();
            for (int i = 0; i < chars.Length; i++)
            {
                securityLength = pattern + i;
                for (int j = i; j < securityLength; j++)
                {
                    if (securityLength <= chars.Length)
                        tmpStr += chars[j];
                }
                contentList.Add(tmpStr);

                if (securityLength >= chars.Length)
                    break;

                tmpStr = "";
            }

            return contentList;
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
