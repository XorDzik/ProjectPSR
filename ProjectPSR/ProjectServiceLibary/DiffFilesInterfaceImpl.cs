using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;

namespace ProjectServiceLibary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    public class DiffFilesInterfaceImpl : IDiffFilesInterface
    {
        public const int ROUND_RESULT = 2;
        IDictionary<int, string> theSameElementsPosSecondFile = new Dictionary<int, string>();


        public IDictionary<int, string> compareFileLetterByLetter(char[] firstFileContent, char[] secondFileContent, string secondFile, int pattern)
        {

            List<string> firstFileContentList = charTabToList(firstFileContent, pattern);
            List<string> secondFileContentList = charTabToList(secondFileContent, pattern);
            List<int> indexList = new List<int>();

            IDictionary<int, string> position = new Dictionary<int, string>();
            int firstCounter = 0;

            if (pattern == 1 || pattern == 2)
            {
                pattern = 1;
            }
            
            foreach (string firstFileTxt in firstFileContentList)
            {
                foreach (string secondFileTxt in secondFileContentList)
                {
                    if (firstFileTxt == secondFileTxt)
                    {
                        int lastPositionFirstFile = firstCounter + pattern;
                        int index = secondFile.IndexOf(secondFileTxt);

                        if (position.Count() == 0)
                        {
                            if (!position.ContainsKey(firstCounter))
                                position.Add(firstCounter, firstFileTxt);

                            if (!theSameElementsPosSecondFile.ContainsKey(index))
                                theSameElementsPosSecondFile.Add(index, secondFileTxt);

                            if (!indexList.Contains(firstCounter))
                                indexList.Add(firstCounter);
                            
                            break;
                        }

                        if (!position.ContainsKey(firstCounter))
                        {
                            foreach (int tmp in indexList)
                            {
                                int lastPosition = tmp + pattern;
                                int result = lastPositionFirstFile - lastPosition;
                                if (result > pattern)
                                {
                                    position.Add(firstCounter, firstFileTxt);
                                    if (!theSameElementsPosSecondFile.ContainsKey(index))
                                        theSameElementsPosSecondFile.Add(index, secondFileTxt);
                                    break;
                                }
                            }

                            if (!indexList.Contains(firstCounter))
                                indexList.Add(firstCounter);
                        }
                    }
                }
                firstCounter++;
            }

            return position;
        }

        public IDictionary<int, string> compareFileWordByWord(string firstFileContent, string secondFileContent, int pattern)
        {
            char[] delimiterChars = { ' ' };
            IDictionary<int, string> theSameElementsPosFirstFile = new Dictionary<int, string>();


            string[] secondFileContentSpit = secondFileContent.Split(delimiterChars);
            int newLineFirstText = 0;
            int newLineSecondText = 0;

            for (int i = 0; i < secondFileContentSpit.Length; i += pattern)
            {
                string secondFileWord = "";
                if (i > 1)
                { 
                    for (int j = i - pattern; j < i; j++)
                        secondFileWord += secondFileContentSpit[j] + " ";

                    string patternx = @"\b" + secondFileWord + @"\b";

                    Regex rgx;
                    if (secondFileWord.Contains("\r\n"))
                        rgx = new Regex(patternx, RegexOptions.Singleline); 
                    else
                        rgx = new Regex(patternx, RegexOptions.IgnoreCase);

                    if (rgx.IsMatch(secondFileContent))
                        foreach (Match match in rgx.Matches(firstFileContent))
                            if (!theSameElementsPosFirstFile.ContainsKey(match.Index))
                                if (secondFileWord.Contains("\r\n"))
                                {
                                    string[] wordToAddTmp = secondFileWord.Split('\r');
                                    string wordToAdd = "";
                                    for (int tabIndex = 0; tabIndex < wordToAddTmp.Length; tabIndex++)
                                        wordToAdd += wordToAddTmp[tabIndex];

                                    theSameElementsPosFirstFile.Add(match.Index, wordToAdd);
                                    newLineFirstText++;
                                }
                                else
                                {
                                    if (newLineFirstText > 0)
                                        theSameElementsPosFirstFile.Add(match.Index - newLineFirstText, match.Value);
                                    else
                                        theSameElementsPosFirstFile.Add(match.Index, match.Value);
                                }


                    if (rgx.IsMatch(firstFileContent))
                        foreach (Match matchSecondFile in rgx.Matches(secondFileContent))
                            if (!theSameElementsPosSecondFile.ContainsKey(matchSecondFile.Index))
                                if (secondFileWord.Contains("\r\n"))
                                {
                                    string[] wordToAddTmp = secondFileWord.Split('\r');
                                    string wordToAdd = "";
                                    for (int tabIndex = 0; tabIndex < wordToAddTmp.Length; tabIndex++)
                                        wordToAdd += wordToAddTmp[tabIndex];

                                    theSameElementsPosSecondFile.Add(matchSecondFile.Index, wordToAdd);
                                    newLineSecondText++;
                                }
                                else
                                {
                                    if (newLineSecondText > 0)
                                        theSameElementsPosSecondFile.Add(matchSecondFile.Index - newLineSecondText, matchSecondFile.Value);
                                    else
                                        theSameElementsPosSecondFile.Add(matchSecondFile.Index, matchSecondFile.Value);
                                }

                }

                if (i + pattern == secondFileContentSpit.Length)
                {
                    string tmp = "";
                    for (int j = i; j < i + pattern; j++)
                        tmp += secondFileContentSpit[j] + " ";

                    string secondFileWordAfter = tmp.TrimEnd();
                
                    if (firstFileContent.Contains(secondFileWordAfter) && secondFileContent.Contains(secondFileWordAfter))
                    {
                        if (!theSameElementsPosFirstFile.ContainsKey(firstFileContent.Length - secondFileWordAfter.Length))
                        {
                            if (newLineFirstText > 0)
                                theSameElementsPosFirstFile.Add(firstFileContent.Length - secondFileWordAfter.Length - newLineFirstText, secondFileWordAfter);
                            else
                                theSameElementsPosFirstFile.Add(firstFileContent.Length - secondFileWordAfter.Length, secondFileWordAfter);
                        }


                        if (!theSameElementsPosSecondFile.ContainsKey(secondFileContent.Length - secondFileWordAfter.Length))
                        {
                            if (newLineSecondText > 0)
                                theSameElementsPosSecondFile.Add(secondFileContent.Length - secondFileWordAfter.Length - newLineSecondText, secondFileWordAfter);
                            else
                                theSameElementsPosSecondFile.Add(secondFileContent.Length - secondFileWordAfter.Length, secondFileWordAfter);
                        }

                    }
                        
                }

                if (i + pattern > secondFileContentSpit.Length)
                {
                    string tmp = "";

                    for (int j = i; j < secondFileContentSpit.Length; j++)
                        tmp += secondFileContentSpit[j] + " ";

                    string secondFileWordAfter = tmp.TrimEnd();

                    if (firstFileContent.Contains(secondFileWordAfter) && secondFileContent.Contains(secondFileWordAfter))
                    {
                        if (!theSameElementsPosFirstFile.ContainsKey(firstFileContent.Length - secondFileWordAfter.Length))
                        {
                            if (newLineFirstText > 0)
                                theSameElementsPosFirstFile.Add(firstFileContent.Length - secondFileWordAfter.Length - newLineFirstText, secondFileWordAfter);
                            else
                                theSameElementsPosFirstFile.Add(firstFileContent.Length - secondFileWordAfter.Length, secondFileWordAfter);
                        }

                        if (!theSameElementsPosSecondFile.ContainsKey(secondFileContent.Length - secondFileWordAfter.Length))
                        {
                            if (newLineSecondText > 0)
                                theSameElementsPosSecondFile.Add(secondFileContent.Length - secondFileWordAfter.Length - newLineSecondText, secondFileWordAfter);
                            else
                                theSameElementsPosSecondFile.Add(secondFileContent.Length - secondFileWordAfter.Length, secondFileWordAfter);
                        }
                    }
                }
            }

            return theSameElementsPosFirstFile;
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

            int howManyTheSameLetters = 0;
            return percentCalculate(howManyTheSameLetters, firstFileLength);
        }

        public double percentCalculate(double howManyTheSameLetters, double firstFileLength)
        {
            return Math.Round((howManyTheSameLetters / firstFileLength) * 100, ROUND_RESULT);
        }

        public IDictionary<int, string> getTheSameElementsPosSecondFile()
        {
            return theSameElementsPosSecondFile;
        }

        public void clearTheSameElementsPosSecondFile()
        {
            theSameElementsPosSecondFile.Clear();
        }
    }
}
