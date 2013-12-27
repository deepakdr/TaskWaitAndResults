/*
 * A program to demonstrate the tasks available in 4.0
 * Use the following methods in the MAIN method in the specified order to see the output of each feature
*           1. Without Task
                WithoutTask();
            2. Simple Wait
                SimpleWait();
            3. Wait All & Wait Any
                WithWaitAllAndWaitAny();
            4. Task with return type 
                TaskWithReturnType();
            5. Parameter Passing
                ParameterPassing();
 * 
 * TODO: Demonstrate AggregateException, UnobservedTaskException, Cancel Token, Flatten the exception
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWaitAndResults
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Console.ReadLine();

        }

        private static void WithWaitAllAndWaitAny()
        {
            DataComputer dc = new DataComputer(1, 2, 3);

            Console.WriteLine("Program Started. Processing....");

            int _first, _second, _third;
            _first = _second = _third = 0;

            Task t_first = Task.Factory.StartNew(() =>
            {
                _first = dc.ComputeFirstInt();
            });

            Task t_second = Task.Factory.StartNew(() =>
            {
                _second = dc.ComputeSecondInt();
            });

            Task t_third = Task.Factory.StartNew(() =>
            {
                _third = dc.ComputeThirdInt();
            });


            Task[] tasks = { t_first, t_second, t_third };

            Task.WaitAll(tasks);

            Task.WaitAny(tasks);

            t_first.Wait();
            t_second.Wait();
            int _firstSecondAdded = _first + _second;
            Console.WriteLine("First Second Added {0}", _firstSecondAdded);

            t_third.Wait();
            int _added = _first + _second + _third;
            Console.WriteLine("First Second Third Added {0}", _added.ToString()); //66

            double _divided = _added / 10;
            Console.WriteLine("First Second Third Added And Divided {0}", _divided); //6
        }

        private static void SimpleWait()
        {
            DataComputer dc = new DataComputer(1, 2, 3);

            Console.WriteLine("Program Started. Processing....");

            int _first, _second, _third;
            _first = _second = _third = 0;

            Task t_first = Task.Factory.StartNew(() =>
            {
                _first = dc.ComputeFirstInt();
            });

            Task t_second = Task.Factory.StartNew(() =>
            {
                _second = dc.ComputeSecondInt();
            });

            Task t_third = Task.Factory.StartNew(() =>
            {
                _third = dc.ComputeThirdInt();
            });


            t_first.Wait();
            t_second.Wait();
            int _firstSecondAdded = _first + _second;
            Console.WriteLine("First Second Added {0}", _firstSecondAdded);

            t_third.Wait();
            int _added = _first + _second + _third;
            Console.WriteLine("First Second Third Added {0}", _added.ToString()); //66

            double _divided = _added / 10;
            Console.WriteLine("First Second Third Added And Divided {0}", _divided); //6

            Console.ReadLine();
        }

        private static void WithoutTask()
        {
            DataComputer dc = new DataComputer(1, 2, 3);

            Console.WriteLine("Program Started. Processing....");

            int _first = dc.ComputeFirstInt();
            int _second = dc.ComputeSecondInt();
            int _third = dc.ComputeThirdInt();


            int _added = _first + _second + _third;
            Console.WriteLine(_added.ToString()); //66

            double _divided = _added / 10;
            Console.WriteLine(_divided); //6
        }

        private static void TaskWithReturnType()
        {
            DataComputer dc = new DataComputer(1, 2, 3);

            Console.WriteLine("Program Started. Processing....");
            List<Task<int>> tasklst = new List<Task<int>>();

            int _first, _second, _third;
            _first = _second = _third = 0;

            Task<int> t_first = Task.Factory.StartNew(() =>
            {
                int l_first;
                l_first = dc.ComputeFirstInt();
                return l_first;
            });



            Task<int> t_second = Task.Factory.StartNew(() =>
            {
                int l_second;
                l_second = dc.ComputeSecondInt();
                return l_second;
            });

            Task<int> t_third = Task.Factory.StartNew(() =>
            {
                int l_third;
                l_third = dc.ComputeThirdInt();
                return l_third;
            });


            _first = t_first.Result;
            _second = t_second.Result;
            int _firstSecondAdded = _first + _second;
            Console.WriteLine("First Second Added {0}", _firstSecondAdded);


            _third = t_third.Result;
            int _added = _first + _second + _third;
            Console.WriteLine("First Second Third Added {0}", _added.ToString()); //66

            double _divided = _added / 10;
            Console.WriteLine("First Second Third Added And Divided {0}", _divided); //6
        }

        static void ParameterPassing()
        {
           
            #region Wrong Method
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(i);

                });

            }
            #endregion

            #region Correct Method

          
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew((args) =>
                    {
                        int taskid = (int)args;
                        Console.WriteLine(taskid);

                    }, i);

            }
            #endregion
        }
    }
}
