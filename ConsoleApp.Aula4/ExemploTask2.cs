using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    public class ExemploTask2
    {
        public ExemploTask2()
        {
            Console.WriteLine("Exemplo Task Primos:");

            Task<int> taskNumerosPrimos = Task.Run(() =>
            {
                var rangeValores = Enumerable.Range(2, 3000000);
                var qtd = rangeValores.Count(v => Enumerable.Range(2, (int)Math.Sqrt(v) - 1)
                                                            .All(i => v % i > 0));

                return qtd;
            });

            Console.WriteLine("Task em execução...");
            Console.WriteLine("Quantidade números primos: " + taskNumerosPrimos.Result);
        }
    }
}
