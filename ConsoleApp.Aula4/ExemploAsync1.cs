using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    public class ExemploAsync1
    {
        public ExemploAsync1()
        {
            Console.WriteLine("Exemplo Async 1:");

            ExecutaTasks();
            ExecutaTasks1();
            ExecutaTasks2Async().GetAwaiter().GetResult();
        }

        public void ExecutaTasks()
        {
            var task1 = new Task<string>(() =>
            {
                return ObtemConteudoUrl("https://www.bcb.gov.br");
            });
            var task2 = new Task<string>(() =>
            {
                return ObtemConteudoUrl("https://www.gov.br/pt-br");
            });
            var task3 = new Task<string>(() =>
            {
                return ObtemConteudoUrl("https://www.gov.br/saude/pt-br");
            });

            Console.WriteLine("Iniciando tasks para download dos sites....");
            var cronometro = new Stopwatch();
            cronometro.Start();

            task1.Start();
            task2.Start();
            task3.Start();

            //Espera todas as tasks
            Task.WhenAll(task1, task2, task3).Wait();

            //pausa o cronometro
            cronometro.Stop();

            Console.WriteLine($"O total do download das páginas levou: {cronometro.Elapsed.TotalSeconds} segundos");
            //O total do download das páginas levou: 13,8051061 segundos
        }

        public void ExecutaTasks1()
        {
            var task1 = ObtemConteudoUrlAsync("https://www.bcb.gov.br");
            var task2 = ObtemConteudoUrlAsync("https://www.gov.br/pt-br");
            var task3 = ObtemConteudoUrlAsync("https://www.gov.br/saude/pt-br");

            Console.WriteLine("Iniciando tasks para download dos sites, usando GetStringAsync....");
            var cronometro = new Stopwatch();
            cronometro.Start();

            //Espera todas as tasks
            Task.WhenAll(task1, task2, task3).Wait();

            //pausa o cronometro
            cronometro.Stop();

            Console.WriteLine($"O total do download das páginas levou: {cronometro.Elapsed.TotalSeconds} segundos");
            //O total do download das páginas levou: 2,6077242 segundos
        }

        public async Task ExecutaTasks2Async()
        {
            var task1 = ObtemConteudoUrlAsync("https://www.bcb.gov.br");
            var task2 = ObtemConteudoUrlAsync("https://www.gov.br/saude/pt-br");

            Console.WriteLine("Iniciando tasks para download dos sites, usando Async/Await....");
            var cronometro = new Stopwatch();
            cronometro.Start();

            //Espera todas as tasks usando a palavra reservada: await
            //o resultado é uma string retornada pela Task<string>:
            string resultadoTask1 = await task1;
            string resultadoTask2 = await task2;

            //pausa o cronometro
            cronometro.Stop();

            Console.WriteLine($"O total do download das páginas levou: {cronometro.Elapsed.TotalSeconds} segundos");
            Console.WriteLine($"A página 1 retornou: {resultadoTask1.Length} caracteres");
            Console.WriteLine($"A página 2 retornou: {resultadoTask2.Length} caracteres");

            //Output no console:
            //O total do download das páginas levou: 2,7308623 segundos
            //A página 1 retornou: 4756 caracteres
            //A página 2 retornou: 224537 caracteres
        }

        public string ObtemConteudoUrl(string url)
        {
            WebClient webClient = new WebClient();
            return webClient.DownloadString(url);
        }


        public Task<string> ObtemConteudoUrlAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            return httpClient.GetStringAsync(url);
        }
    }
}
