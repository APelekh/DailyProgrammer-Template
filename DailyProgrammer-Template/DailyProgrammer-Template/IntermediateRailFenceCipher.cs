﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: 
///     Challenge Name:
///     Challenge #: 
///     Challenge URL: 
///     Brief Description of Challenge:
///
/// 
///
///     What was difficult about this challenge?
/// 
///
///     
///
///     What was easier than expected about this challenge?
///     
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.

namespace DailyProgrammer_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            RailFenceEnc("REDDITCOMRDAILYPROGRAMMER");

            Console.ReadKey();
        }

        /// <summary>
        /// Simple function to illustrate how to use tests
        /// </summary>
        /// <param name="inputInteger"></param>
        /// <returns></returns>
        public static int MyTestFunction(int inputInteger)
        {
            return inputInteger;
        }

        public static void RailFenceEnc(string input)
        {
            string one = string.Empty;
            string two = string.Empty;
            string three = string.Empty;
            int counter1 = 1;
            string counter2 = "up";
            for (int i = 0; i < input.Length; i++)
            {
                if (counter2 == "up")
                {
                    if (counter1 == 1)
                    {
                        one = one + input[i];
                        //counter1 = 2;
                        counter1++;
                    }
                    else if (counter1 == 2)
                    {
                        two = two + input[i];
                        //counter1 = 3;
                        counter1++;
                    }
                    else if (counter1 == 3)
                    {
                        three = three + input[i];
                        //counter1 = 2;
                        counter1--;
                        counter2 = "down";
                    }
                }
                else if (counter2 == "down")
                {
                    if (counter1 == 2)
                    {
                        two = two + input[i];
                        //counter1 = 1;
                        counter1--;
                    }
                    else if (counter1 == 1)
                    {
                        one = one + input[i];
                        //counter1 = 2;
                        counter1++;
                        counter2 = "up";
                    }
                }
            }
            Console.WriteLine(string.Join("", one, two, three));

        }
    }

    class RailFenceEnc
    {
        public RailFenceEnc{
    }
    
    class String
    {
        private string _string;
        public string String
        {
            get { return _string; }
            set { _string = value; }
        }
        public String()
        {
            _string = string.Empty;
        }
    }


    #region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidTest()
        {
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            int result = Program.MyTestFunction(15);  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result == 15, "This is the message that displays if it does not pass");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTest()
        {
            int result = Program.MyTestFunction(15);
            Assert.IsFalse(result == 14);
        }
    }
    #endregion
}
