using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ReliableDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var webSystemCalls = new WebSystemCalls();
            var cancellationToken = CancellationToken.None;

            // Accurx URL
            string url = "https://www.accurx.com/";

            // Get HTTP headers for the URL
            var headersResponse = await webSystemCalls.GetHeadersAsync(url, cancellationToken);
            Console.WriteLine("HTTP Headers:");
            foreach (var header in headersResponse.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }

            // Download whole content
            var contentResponse = await webSystemCalls.DownloadContentAsync(url, cancellationToken);
            var content = await contentResponse.Content.ReadAsStringAsync();
            Console.WriteLine("\nDownloaded Content:");
            Console.WriteLine(content);

            // Partial content download
            long fromByte = 0;
            long toByte = 1000;
            var partialContentResponse = await webSystemCalls.DownloadPartialContentAsync(url, fromByte, toByte, cancellationToken);
            var partialContent = await partialContentResponse.Content.ReadAsStringAsync();
            Console.WriteLine("\nPartial Content (0-1000 bytes):");
            Console.WriteLine(partialContent);
        }
    }
}
