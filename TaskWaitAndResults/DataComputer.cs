using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TaskWaitAndResults
{
    /// <summary>
    /// A dummy class to simulate random delays in the methods
    /// </summary>
    public class DataComputer
    {
        public int FirstInt { get; set; }
        public int SecondInt { get; set; }
        public int ThirdInt { get; set; }

        public DataComputer(int FirstInt =0, int SecondInt = 0, int ThirdInt=0)
        {
            this.FirstInt = FirstInt;
            this.SecondInt = SecondInt;
            this.ThirdInt = ThirdInt;
        }


        public int ComputeFirstInt()
        {
            Random rd = new Random();
            int waitTime = rd.Next(1,5) * 1000;

            Thread.Sleep(waitTime);
            
            return FirstInt + 10;
        }

        public int ComputeSecondInt()
        {
            Thread.Sleep(new Random().Next(1, 5) * 1000);
            return SecondInt + 20;
        }

        public int ComputeThirdInt()
        {
            Thread.Sleep(new Random().Next(1, 5) * 1000);
            return ThirdInt + 30;
        }
    }
}
