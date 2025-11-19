using BenchmarkDotNet.Running;

namespace DatastrukturerMinneBenchark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarksToRun>();
        }
    }
}
