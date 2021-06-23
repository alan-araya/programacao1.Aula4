using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    public class ExemploTask3
    {
        public ExemploTask3()
        {
            //Inicia uma nova task que lança uma NullReferenceException:
            var task = Task.Run(() => { throw null; });
            try
            {
                task.Wait();
            }
            catch (AggregateException aggregateEx)
            {
                foreach (var ex in aggregateEx.InnerExceptions)
                {
                    Console.WriteLine($"Exception do tipo {ex.GetType()}. Message: {ex.Message}");
                }                   
            }
        }
    }
}
