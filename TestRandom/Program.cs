using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 10000000;
            int[] a = new int[41];
            for (int i = 1; i <= max; i++) a[GetRandomNumber(0,40)]++ ;
            for (int j = 0; j <= 40; j++) Console.WriteLine(a[j]);
        }
        public static int GetRandomNumber(int min, int max)
        {
            int rtn = 0;
            Random r = new Random();
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            r = new Random(iSeed);
            rtn = r.Next(min, max + 1);
            return rtn;
        }
    }
}
