using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace SolverService
{
    public class Solver
    {
        // Complete the diagonalDifference function below.
        public static int DiagonalDifference(int[][] arr)
        {
            var leftDiag = 0;
            var rightDiag = 0;

            var length = arr.Length;

            for (var i = 0; i < length; i++)
            {
                //eg [0,0],[1,1],[2,2]
                leftDiag += arr[i][i];
                // [we need [0,2],[1,1],2,0]
                rightDiag += arr[i][(length- 1) -i];
                
            }
            return Math.Abs(leftDiag - rightDiag);
        }

        public static void PlusMinus(int[] arr)
        {
            decimal totalCount = arr.Length;
            decimal positveCount = 0;
            decimal negativeCount = 0;
            decimal zeros = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    positveCount++;
                    continue;
                }

                if (arr[i] < 0)
                {
                    negativeCount++;
                    continue;
                }

                if (arr[i] == 0)
                {
                    zeros++;
                    continue;
                }
            }

            var test = positveCount /  totalCount;
            Console.WriteLine(((decimal) (positveCount / totalCount)).ToString("N6"));
            Console.WriteLine(((decimal) (negativeCount / totalCount)).ToString("N6"));
            Console.WriteLine(((decimal) (zeros / totalCount)).ToString("N6"));
        }

        public static void Staircase(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                var test = new string('#', i);
                Console.WriteLine(test.PadLeft(n));
            }
        }

        public static void MinMaxSum(int[] arr)
        {
            try
            {
                var longList = arr.Select(item => (long) item).ToList<long>();
                var smallSum = longList.OrderBy(item => item).Take(arr.Length - 1).Sum();
                var largeSum = longList.OrderByDescending(item => item).Take(arr.Length - 1).Sum();
                Console.WriteLine($"{smallSum} {largeSum}");
            }
                catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static int BirthdayCakeCandles(int[] ar)
        {
            try
            {
                var count = 0;
                var age = ar.Max();
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] == age)
                    {
                        count++;
                    }
                }

                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return 0;
        }

        public static string TimeConversion(string s)
        {
            try
            {
                return Convert.ToDateTime(s).ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return "";
        }

        public static int CountCamelCase(string s)
        {

            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return r.Split(s).Length;
        }

        public static int[] GradingStudents(int[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                var grade = grades[i];
                var modValue = (int) (grade % 5);

                if (grade < 38) continue;
                if (modValue >= 3)
                {
                    grades[i] = grade + (5 - modValue);
                }

            }
            return grades;
        }

        public static void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            var houseLeft = s;
            var houseRight = t;
            var appleTree= a;
            var orangeTree = b;

            //Adding each apple distance to the position of the tree

            var applesHit = 0;
            var orangesHit = 0;

            for (int i = 0; i < apples.Length; i++)
            {
                var appleFallSpot = appleTree + apples[i];
                if (appleFallSpot >= houseLeft && appleFallSpot <= houseRight)
                {
                    applesHit++;
                }
            }

            for (int i = 0; i < oranges.Length; i++)
            {
                var orangeFallSpot = orangeTree + oranges[i];
                if (orangeFallSpot >= houseLeft && orangeFallSpot <= houseRight)
                {
                    orangesHit++;
                }
            }

            

            Console.WriteLine(applesHit);
            Console.WriteLine(orangesHit);
            //    s: integer, starting point of Sam's house location.
            //    t: integer, ending location of Sam's house location.
            //    a: integer, location of the Apple tree.
            //    b: integer, location of the Orange tree.
            //    apples: integer array, distances at which each apple falls from the tree.
            //    oranges: integer array, distances at which each orange falls from the tree.
        }

        public static string Kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x1 > x2 && v1 > v2) return "NO";
            if (x2 > x1 && v2 > v1) return "NO";
            if (x1 == x2) return "YES";

            var lcd = x1 != 0 ? x1 * x2 : x2;
            var largerMultiple = Math.Max(v1, v2);
            for (int i = 0; i < (lcd * largerMultiple); i++)
            {
                if (i % v1 != 1 % v2) continue;
                var x1Stop = (x1 + (v1 * i));
                var x2Stop = (x2 + (v2 * i));
                if (x1Stop == x2Stop)
                {
                    return "YES";
                }
            }
            return "NO";
        }
    }
}