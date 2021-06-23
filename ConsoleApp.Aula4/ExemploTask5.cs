using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    public class ExemploTask5
    {
        public ExemploTask5()
        {
            Console.WriteLine("Exemplo Tasks com WhenAll:");

            //cria um array de cronometros para mensurarmos os tempos decorridos
            //no processamento das tasks
            var cronometros = new Stopwatch[4];
            cronometros[0] = new Stopwatch();
            cronometros[1] = new Stopwatch();
            cronometros[2] = new Stopwatch();
            cronometros[3] = new Stopwatch();

            var task1 = new Task<int>(() =>
            {
                var qtd = CalculaPrimos(500000);
                cronometros[0].Stop();
                return qtd;
            });

            var task2 = new Task<int>(() =>
            {
                var qtd = CalculaPrimos(2000000);
                cronometros[1].Stop();
                return qtd;
            });

            var task3 = new Task<int>(() =>
            {
                var qtd = CalculaPrimos(4000000);
                cronometros[2].Stop();
                return qtd;
            });

            //cronometros geral
            cronometros[3].Start();

            //Vamos iniciar as tasks na ordem inversa
            cronometros[2].Start();
            task3.Start();
            cronometros[1].Start();
            task2.Start();
            cronometros[0].Start();
            task1.Start();

            Task.WhenAll(task1, task2, task3).Wait();

            //cronometros geral
            cronometros[3].Stop();

            Console.WriteLine("Conjunto finalizado. Tempo total:" + cronometros[3].Elapsed.TotalSeconds);
            Console.WriteLine($"Tempo Task1: {cronometros[0].Elapsed.TotalSeconds} Resultado: {task1.Result}");
            Console.WriteLine($"Tempo Task2: {cronometros[1].Elapsed.TotalSeconds} Resultado: {task2.Result}");
            Console.WriteLine($"Tempo Task3: {cronometros[2].Elapsed.TotalSeconds} Resultado: {task3.Result}");

            //Output no console:
            //Conjunto finalizado. Tempo total:6,5563376
            //Tempo Task1: 0,5660922 Resultado: 41538
            //Tempo Task2: 2,9045921 Resultado: 148933
            //Tempo Task3: 6,5558066 Resultado: 283146

        }


        public int CalculaPrimos(int intervalo)
        {
            var rangeValores = Enumerable.Range(2, intervalo);
            var qtd = rangeValores.Count(v => Enumerable.Range(2, (int)Math.Sqrt(v) - 1)
                                                        .All(i => v % i > 0));

            return qtd;
        }
    }
}
