using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        { 
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string[] number = equation.Split("*");
            string[] number1 = number[1].Split("=");
            
            string first = number[0];
            string second = number1[0];
            string third = number1[1];
    
            int assumedNumber = 0;
            string numberToBeFound = "";

            if(first.Contains("?")){
                int secondNumber = int.Parse(second);
                int result = int.Parse(third);

                assumedNumber = result / secondNumber;
                float assumedNumberCheck = (float) result / (float) secondNumber;

                if(assumedNumber != assumedNumberCheck)
                    return -1;
                
                numberToBeFound = first;
            }
            else if(second.Contains("?")){
                int firstNumber = int.Parse(first);
                int result = int.Parse(third);

                assumedNumber = result / firstNumber;
                float assumedNumberCheck = (float)result /(float)firstNumber ;

                if(assumedNumber != assumedNumberCheck)
                    return -1;

                numberToBeFound = second;
            }
            else{
                int firstNumber = int.Parse(first);
                int secondNumber = int.Parse(second);
                assumedNumber = firstNumber * secondNumber;
                
                numberToBeFound = third;
            }

            if(assumedNumber.ToString().Length.Equals(numberToBeFound.Length))
                return int.Parse(assumedNumber.ToString()[numberToBeFound.IndexOf("?")].ToString());
            else
                return -1;

            throw new NotImplementedException();




        }
    }
}
