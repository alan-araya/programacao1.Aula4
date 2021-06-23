using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    public class ExemploTask4
    {
        public ExemploTask4()
        {
            Console.WriteLine("Exemplo Task Encadeadas:");

            var task4 = Task.Run(() =>
            {
                Thread.Sleep(500);
                return 100;

            }).ContinueWith((taskAnterior) => 
            {
                Thread.Sleep(500);
                return taskAnterior.Result * 5;
            }).ContinueWith((taskAnterior)=> 
            {
                Thread.Sleep(500);
                return taskAnterior.Result * 5;
            });

            Console.WriteLine("Resultado encadeado:" + task4.Result);
        }
    }
}
