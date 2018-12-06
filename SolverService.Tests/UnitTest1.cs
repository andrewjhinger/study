using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SolverService.Tests
{
    public class SolverTests
    {
        [TestFixture]
        public class AllTheTests
        {
            [Test]
            [TestCase(new string[] { "1 2 3", "4 5 6", "9 8 9" }, 2, TestName = "Test1")]
            [TestCase(new string[] { "11 2 4", "4 5 6", "10 8 -12" }, 15, TestName = "Test2")]
            public void DiagDiff(string[] stringArr, int expected)
            {
                int[][] arr = new int[3][];

                for (int i = 0; i < 3; i++)
                    arr[i] = Array.ConvertAll(stringArr[i].Split(' '), arrTemp => Convert.ToInt32(arrTemp));


                var diff = Solver.DiagonalDifference(arr);
                Assert.AreEqual(expected, diff);
            }

           
            [TestCase("-4 3 -9 0 4 1", "0.500000\r\n0.333333\r\n0.166667\r\n", TestName = "Test3")]
            public void PlusMinus(string stringNums, string expected)
            {
                int[] arr = Array.ConvertAll(stringNums.Split(' '), Convert.ToInt32);

                using (var consoleOutput = new ConsoleOutput())
                {
                    Solver.PlusMinus(arr);
                    Assert.AreEqual(expected, consoleOutput.GetOuput());
                }
            }

            [Test]
            public void StairCase()
            {
                var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var expected = System.IO.File.ReadAllText(Path.Combine(
                    "C:\\Users\\edv1eku\\Desktop\\study\\SolverService.Tests\\TestFiles", 
                    "Staircase.txt"));
                using (var consoleOutput = new ConsoleOutput())
                {
                    Solver.Staircase(6);
                    var test = consoleOutput.GetOuput();
                    Assert.AreEqual(expected, consoleOutput.GetOuput());
                }
            }
            //100000000
            [TestCase(new int[]{1,2,3,4,5},"10 14\r\n")]
            [TestCase(new int[]{ 7, 69, 2, 221, 8974 }, "299 9271\r\n")]
            [TestCase(new int[] { 100000000, 100000000, 100000000, 100000000, 100000000 }, "400000000 400000000\r\n")] //big num
            public void MinMaxSum(int[] ints, string expected)
            {
                using (var consoleOutput = new ConsoleOutput())
                {
                    Solver.MinMaxSum(ints);
                    var test = consoleOutput.GetOuput();
                    Assert.AreEqual(expected, consoleOutput.GetOuput());
                }
            }

            //[TestCase(new int[] { 3, 2, 1, 3 }, "2")]
            [Test]
            //public void BirthdayCandles(int[] ints, string expected)
            public void BirthdayCandles()
            {
                var testArray = Enumerable.Repeat(10000, 10000).ToArray();
                var result = Solver.BirthdayCakeCandles(testArray);
                Assert.AreEqual(1, result);
                
            }

            [TestCase("07:05:45PM", "19:05:45")]
            public void TimeConversion(string time, string expected)
            {
                var result = Solver.TimeConversion(time);
                Assert.AreEqual(expected, result);

            }

            [TestCase("saveChangesInTheEditor", 5)]
            public void CountCamelCase(string camelCase, int expected)
            {
                var result = Solver.CountCamelCase(camelCase);
                Assert.AreEqual(expected, result);
            }

            [TestCase(new int[]{73,67,38,33}, new int[]{75,67,40,33})]
            public void GradingStudents(int[] grades, int[] expected)
            {
                var result = Solver.GradingStudents(grades);
                Assert.AreEqual(expected, result);
            }

            [TestCase(7,11,5,15, new int[]{-2,2,1}, new int[]{5,-6}, "1\r\n1\r\n")]
            public void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges, string expected)
            {
                using (var consoleOutput = new ConsoleOutput())
                {
                    Solver.CountApplesAndOranges(s, t, a, b, apples, oranges);
                    Assert.AreEqual(expected, consoleOutput.GetOuput());
                }
            }

            [TestCase(0,2,5,3,"NO")]
            [TestCase(0,3,4,2,"YES")]
            [TestCase(42,3,94,2,"YES")]
            public void Kangaroo(int x1, int v1, int x2, int v2,string expected)
            {
                var result = Solver.Kangaroo(x1,v1,x2,v2);
                Assert.AreEqual(expected, result);
            }
        }

    }
}
