using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HWAsyncAwait
{
    class Program
    {
        private static async Task WriteToTextToFile()
        {
            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(@"c:\temp\WriteTextAsync.txt"))
            {
                for (int i = 1; i <= 1000; i++)
                {
                    await outputFile.WriteAsync($"{i.ToString()} ");
                    Thread.Sleep(2);
                }
            }
        }
        static void Main(string[] args)
        {
            Task task = WriteToTextToFile();

            while (!task.Wait(100))
            {
                Console.Write(".");
            }

        }
    }
}
