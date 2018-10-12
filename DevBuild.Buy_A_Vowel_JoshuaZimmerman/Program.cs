using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.Buy_A_Vowel_JoshuaZimmerman
{
    class Program
    {
        public static Dictionary<char, int> inputVowels = new Dictionary<char, int>() { { 'a', 0 },
                                                                                        { 'e', 0 },
                                                                                        { 'i', 0 },
                                                                                        { 'o', 0 },
                                                                                        { 'u', 0 } };
        static void Main(string[] args)
        {
            YesNoAnswer userAnswer = YesNoAnswer.AnswerNotGiven;

            Console.Write(  "***********************************************************\n" +
                            "*            Dev.Build(2.0) - Count the Vowels            *\n" +
                            "***********************************************************\n\n");
            while (true)
            {
                //Have user enter string
                Console.Write("Please enter some text, and I'll count the vowels: ");
                string userString = Console.ReadLine();

                //sent string to CountVowels to determine number of vowels present
                CountVowels(userString);

                //display number of vowels present
                DisplayVowels();

                //reset vowel counters in our Dictionary
                inputVowels['a'] = 0;
                inputVowels['e'] = 0;
                inputVowels['i'] = 0;
                inputVowels['o'] = 0;
                inputVowels['u'] = 0;

                //ask user if they would like to continue
                userAnswer = UserInput.GetYesOrNoAnswer("Would you like to enter another string? ");
                switch (userAnswer)
                {
                    case YesNoAnswer.Yes: userAnswer = YesNoAnswer.AnswerNotGiven; continue;
                    case YesNoAnswer.No: userAnswer = YesNoAnswer.AnswerNotGiven; return;
                }
            }
        }

        public static void CountVowels(string userString)
        {
            if (inputVowels != null)
            {
                foreach (char c in userString.ToCharArray())
                {
                    char tmp = char.ToLower(c);
                    if (inputVowels.ContainsKey(tmp))
                    {
                        inputVowels[tmp]++;
                    }
                }
            }
        }

        public static void DisplayVowels()
        {
            if (inputVowels != null)
            {
                foreach (char c in inputVowels.Keys)
                {
                    Console.WriteLine(char.ToUpper(c).ToString() + " | " + inputVowels[c]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
