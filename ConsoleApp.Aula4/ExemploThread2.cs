using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp.Aula4
{
    public class ExemploThread2
    {
        public ExemploThread2()
        {
            Thread.Sleep(1500);

            Thread t2 = new Thread(Execute);
            t2.Start();
            t2.Join();

            Console.WriteLine("fim da execução");

            //output no console:
            //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfim da execuçao



            var t3 = new Thread(ExecuteSleep);
            t3.Start();
            Thread.Sleep(100);

            Console.WriteLine("continuando a main Thread...");
            t3.Join();

            Console.WriteLine("fim da execução...");
            //Output no console:
            //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxcontinuando a main Thread...
            //fim Thread t3
            //fim da execuçao...
        }

        public void Execute()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("x");
            }
        }
        public void ExecuteSleep()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("x");
            }
            Thread.Sleep(500);
            Console.WriteLine("fim Thread t3");
        }
    }
}
