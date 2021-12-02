using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Lab_21
{
    /*
     * Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
     * Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
     * Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
     * Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
     * Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. 
     * Создать многопоточное приложение, моделирующее работу садовников.
     */
    class Program
    {
        static int n, m;
        static int[,] eath;
        //static object locker = new object();
        static void Gardener1()
        {
            //lock (locker)
            //{
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (eath[i, j] == 0)
                        {
                            eath[i, j] = 1;
                        }
                        Thread.Sleep(1);
                    }
                }
            //}
        }
        static void Gardener2()
        {
            //lock (locker)
            //{
                for (int j = m - 1; j >= 0; j--)
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        if (eath[i, j] == 0)
                        {
                            eath[i, j] = 2;
                        }
                        Thread.Sleep(1);
                    }
                }
            //}
        }

        static void Main(string[] args)
        {
            m = 5;  
            n = 5;
            eath = new int[n, m];

            ThreadStart threadStart1 = new ThreadStart(Gardener1);
            ThreadStart threadStart2 = new ThreadStart(Gardener2);
            Thread thread1 = new Thread(threadStart1);
            Thread thread2 = new Thread(threadStart2);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(new string(' ', 2) + eath[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
