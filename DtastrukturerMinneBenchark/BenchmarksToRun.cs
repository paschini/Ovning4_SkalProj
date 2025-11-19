using BenchmarkDotNet.Attributes;

namespace DatastrukturerMinneBenchark
{
    [MemoryDiagnoser]
    public class BenchmarksToRun
    {
        [Benchmark]
        public void RecursiveEvenRun()
        {
            RecursiveEven(100);
        }

        private int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return RecursiveEven(n - 1) + 2;
        }

        [Benchmark]
        public int IterativeEven()
        {
            int n = 100;
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        [Benchmark]
        public void RecursiveFibonnacci()
        {
            RecursiveFibonnacci(25);
        }

        private int RecursiveFibonnacci(int n)
        {
            if (n <= 1) return n;

            return RecursiveFibonnacci(n - 1) + RecursiveFibonnacci(n - 2);
        }

        [Benchmark]
        public void IterativeFibonnacci()
        {
            int n = 25;
            int[] resultList = [0, 1];
            for (int i = 0; i <= n; i++)
            {
                int result = 0;
                if (i <= 1)
                {
                    result = i;
                    //Console.Write(result + (i < n ? ", " : " "));
                }
                else
                {
                    result = (resultList[i - 1]) + (resultList[i - 2]);
                    resultList = resultList.Append(result).ToArray();
                    //Console.Write(result + (i < n ? ", " : " "));
                }
            }
        }

        [Benchmark]
        public int IterativeFibonnacciNoArray()
        {
            int n = 25;
            if (n <= 1) return n;
            int a = 0, b = 1, c = 0;

            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }
    }
}
