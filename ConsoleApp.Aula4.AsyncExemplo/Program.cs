using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4.AsyncExemplo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Exemplo Async/Await! Mini Server");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            var spinner = new ConsoleSpinner();
            MiniServer miniServer = new MiniServer();
            int max = 500;
            string urlDownload = "https://www.gov.br/pt-br";
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();


            for (int i = 0; i < max; i++)
            {
                miniServer.DownloadUrlAsync(urlDownload, $"client: {i}");
                //miniServer.DownloadUrlSync(urlDownload, $"client: {i}");
                await Task.Delay(500);

                var clientsCompletos = miniServer.downloaders.Count(d => d.StatusRequisicao == Downloader.Status.FINALIZADO);
                var clientsExecutando = miniServer.downloaders.Count(d => d.StatusRequisicao == Downloader.Status.EXECUTANDO);
                var clientsCriados = miniServer.downloaders.Count(d => d.StatusRequisicao == Downloader.Status.CRIADO);

                Console.WriteLine($"clientsExecutando: {clientsExecutando} | clientsCompletos: {clientsCompletos}");
                Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");
                Console.WriteLine($"Tempo decorrido: {cronometro.Elapsed.TotalSeconds}s");
                spinner.Turn();

                Console.SetCursorPosition(0, 2);
            }
        }
    }

    public class MiniServer
    {
        public List<Downloader> downloaders = new List<Downloader>(1000);

        public void DownloadUrlAsync(string url, string clientId)
        {
            var downloader = new Downloader(clientId);
            downloaders.Add(downloader);

            Task.Run(async () =>
            {
                var resultado = await downloader.ObtemConteudoUrlAsync(url);
                downloader.Resultado = resultado;
                downloader.StatusRequisicao = Downloader.Status.FINALIZADO;               
            });
        }

        public void DownloadUrlSync(string url, string clientId)
        {
            var downloader = new Downloader(clientId);
            downloaders.Add(downloader);

            Task.Run(() => 
            {
                var resultado = downloader.ObtemConteudoUrl2(url);
                downloader.Resultado = resultado;
                downloader.StatusRequisicao = Downloader.Status.FINALIZADO;
            });
        }
    }


    public class Downloader
    {
        public enum Status
        {
            CRIADO,
            EXECUTANDO,
            FINALIZADO
        }
        public Status StatusRequisicao { get; set; }
        public string ClientId { get; set; }
        public string Resultado { get; set; }

        public Downloader(string clientId)
        {
            StatusRequisicao = Status.CRIADO;
            ClientId = clientId;
        }
        public Task<string> ObtemConteudoUrlAsync(string url)
        {
            StatusRequisicao = Status.EXECUTANDO;

            HttpClient httpClient = new HttpClient();
            var resposta = httpClient.GetStringAsync(url);

            return resposta;
        }

        public string ObtemConteudoUrl(string url)
        {
            StatusRequisicao = Status.EXECUTANDO;

            WebClient webClient = new WebClient();
            return webClient.DownloadString(url);
        }

        public string ObtemConteudoUrl2(string url)
        {
            StatusRequisicao = Status.EXECUTANDO;

            var client = new HttpClient();
            var response = client.Send(new HttpRequestMessage(HttpMethod.Get, url));

            using var reader = new StreamReader(response.Content.ReadAsStream());

            return reader.ReadToEnd();
        }
    }

    public class ConsoleSpinner
    {
        int counter;

        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); counter = 0; break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}
