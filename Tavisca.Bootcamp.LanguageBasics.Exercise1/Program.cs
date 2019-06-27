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
            Test("42*?47=1974",-1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        { 
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static float giveMeMissingNumber(int firstNumber, int secondNumber, string operatorUsed){
                
                if(operatorUsed.Equals("/")){
                    return (float) firstNumber / (float)secondNumber ;  
                }else
                {
                    return (float)firstNumber * (float)secondNumber;
                }
        }

        public static int FindDigit(string equation)
        {
            string[] number = equation.Split("*");
            string first = "" ,second= "",third = "";
            
            if(number.Length >= 1){
                string[] number1 = number[1].Split("=");
                first = number[0];
                
                second = number1[0];
                third = number1[1];
            }
			
            float assumedNumber = 0.0F; 
            string numberToBeFound = "";

            if(first.Contains("?")){
                assumedNumber = giveMeMissingNumber(int.Parse(third),int.Parse(second),"/");
                numberToBeFound = first;
                if(assumedNumber % 1 != 0)
                    return -1;
            }
            else if(second.Contains("?")){
                assumedNumber =giveMeMissingNumber(int.Parse(third),int.Parse(first),"/");; 
                numberToBeFound = second;
                if(assumedNumber % 1 != 0)
                    return -1;
            }
            else{
                assumedNumber =giveMeMissingNumber(int.Parse(first),int.Parse(second),"*");
                numberToBeFound = third;
            }

            if(assumedNumber.ToString().Length.Equals(numberToBeFound.Length))
                return int.Parse(assumedNumber.ToString()[numberToBeFound.IndexOf("?")].ToString());
            else
                return -1;
        }
    }
}
