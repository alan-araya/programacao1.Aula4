using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    public class ExemploTask1
    {
        public ExemploTask1()
        {

            //Os dois trehcos de código abaixo são equivalentes:
            Task.Run(() => { Console.WriteLine("Hello World!"); });
            new Thread(() => Console.WriteLine("Hello World!")).Start();



            Task task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task 1 terminando...");
            });

            Console.WriteLine(task1.IsCompleted); // False
            task1.Wait(); // Espera até que a Task finalize
        }
    }
}
