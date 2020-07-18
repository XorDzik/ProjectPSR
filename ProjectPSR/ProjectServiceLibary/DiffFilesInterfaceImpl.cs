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
        public const int ROUND_RESULT = 2; 
        public double calculateLevenhstein(String firstText, String secondText)
        {
            int i, j;
            int firstTextLenght, secondTextLenght, cost;
            int[,] distanceLevenhstein;

            firstTextLenght = firstText.Length;
            secondTextLenght = secondText.Length;

            distanceLevenhstein = new int[firstTextLenght + 1, secondTextLenght + 1];

            for (i = 0; i <= firstTextLenght; i++)
                distanceLevenhstein[i, 0] = i;
            for (j = 1; j <= secondTextLenght; j++)
                distanceLevenhstein[0, j] = j;

            for (i = 1; i <= firstTextLenght; i++) {
                for (j = 1; j <= secondTextLenght; j++) {
                    if (firstText[i - 1] == secondText[j - 1])
                        cost = 0;
                    else
                        cost = 1;

                    distanceLevenhstein[i, j] = Math.Min(distanceLevenhstein[i - 1, j] + 1,   
                    Math.Min(distanceLevenhstein[i, j - 1] + 1,
                    distanceLevenhstein[i - 1, j - 1] + cost));
                }
            }
            return distanceLevenhstein[firstTextLenght, secondTextLenght];
        }

        public double percentCalculate(double distanceLevenhstein, double firstTextLenght)
        {
            return Math.Round((1.0 - (distanceLevenhstein / firstTextLenght)) * 100, ROUND_RESULT);
        }
    }
}
