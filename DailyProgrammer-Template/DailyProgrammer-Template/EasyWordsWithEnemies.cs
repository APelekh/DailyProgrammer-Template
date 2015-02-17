using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: Andrii Pelekh
///     Challenge Name: [Easy] Words with Enemies
///     Challenge #: Challenge #198
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/2syz7y/20150119_challenge_198_easy_words_with_enemies/
///     Brief Description of Challenge:
///Program takes a string of two words, and eliminates the same letters in each word at ratio of 1 for 1.
///After that, the program announces the "winner" - the word that has the most letters left after elimination.
///If amounts of remaining letters are the same then it's a tie.
/// 
///
///     What was difficult about this challenge?
///Part with ratio 1 to 1 seems to be new for me to implement. As overall, this challenge seems to be easy and I want 
///to start with this one.
///
///
///
///     What was easier than expected about this challenge?
///Nothing.
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
            WordsWithEnemies("cause because");
            WordsWithEnemies("hello below");
            WordsWithEnemies("hit miss");
            WordsWithEnemies("rekt pwn");
            WordsWithEnemies("combo jumbo");
            WordsWithEnemies("critical optical");
            WordsWithEnemies("isoenzyme apoenzyme");
            WordsWithEnemies("tribesman brainstem");
            WordsWithEnemies("blames nimble");
            WordsWithEnemies("yakuza wizard");
            WordsWithEnemies("longbow blowup");
            WordsWithEnemies("12345467");

            //string text = "ABCDEFG";
            //string text1 = text.Remove(3,1);
            //Console.WriteLine("{0}\n{1}", text, text1);


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

        /// <summary>
        ///Program takes a string of two words, and eliminates the same letters in each word at ratio of 1 for 1.
        ///After that, the program announces the "winner" - the word that has the most letters left after elimination.
        ///If amounts of remaining letters are the same then it's a tie.
        /// </summary>
        /// <param name="inputString">String to be processed</param>
        /// <returns>Returns a string with a result</returns>
        public static string WordsWithEnemies(string inputString)
        {
            //checking if input is a number
            int result = 0;
            if (int.TryParse(inputString, out result) == true)
            {
                //if it's a number then returns below string
                Console.WriteLine("Input is invalid");
                return "Input is invalid";
            }
            //splitting input string into words
            List<string> listOfWords = inputString.Split(' ').ToList();
            string firstWord = listOfWords[0].ToLower();
            string secondWord = listOfWords[1].ToLower();
            //printing out original input before modifying it
            Console.WriteLine("Input was: {0} and {1}", firstWord, secondWord);
            //looping through each letter in the fist word
            for (int i = 0; i < firstWord.Length; i++)
            {
                //looping through each letter in the second word
                for (int j = 0; j < secondWord.Length; j++)
                {
                    //need to stop the loop if all letters from first word were eliminated
                    if (firstWord.Length == 0)
                    {
                        break;
                    }
                    //checking if a letter from first word appears in the second word
                    if (firstWord[i] == secondWord[j])
                    {
                        //NOTE
                        //Replace doesn't work here because it replaces all instances of a letter
                        //firstWord = firstWord.Replace(firstWord[i].ToString(), "");
                        
                        //if letter appears then removing it from both words and assigning new values to variables
                        firstWord = firstWord.Remove(i, 1);
                        secondWord = secondWord.Remove(j, 1);
                        //reseting counters to start again from the beginning of new modified words
                        i = 0;
                        j = 0;
                    }
                }
            }
            //checking the length of modified words and printing results
            if (firstWord.Length == secondWord.Length)
            {
                Console.WriteLine("That's a tie!, letter remained: {0} and {1}", firstWord, secondWord);
                Console.WriteLine("---------------------\n");
                return "Tie";
            }
            else if (firstWord.Length > secondWord.Length)
            {
                Console.WriteLine("First word wins, letter remained: {0} and {1}", firstWord, secondWord);
                Console.WriteLine("---------------------\n");
                return "First wins";
            }
            else if (firstWord.Length < secondWord.Length)
            {
                Console.WriteLine("Second word wins, letter remained: {0} and {1}", firstWord, secondWord);
                Console.WriteLine("---------------------\n");
                return "Second wins";
            }
            Console.WriteLine("---------------------\n");
            return "Input is invalid";
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
            ////inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            //int result = Program.MyTestFunction(15);  // this function should return 15 if it is working correctly
            ////now we test for the result.
            //Assert.IsTrue(result == 15, "This is the message that displays if it does not pass");
            //// The format is:
            //// Assert.IsTrue(some boolean condition, "failure message");
            //string myResult = Program.WordsWithEnemies("yakuza wizard");
            //Assert.IsTrue(myResult == "That's a tie! Letter remained: ykua and wird", "Test is failed");
            StringAssert.AreEqualIgnoringCase("Tie", Program.WordsWithEnemies("yakuza wizard"));
        }

        [Test]
        public void MyInvalidTest()
        {
            //string myResult = Program.WordsWithEnemies("123456");
            //Assert.IsFalse(myResult == "Input is invalid", "failure");
            StringAssert.AreEqualIgnoringCase("Input is invalid", Program.WordsWithEnemies("12345"));
        }
    }
#endregion
}
