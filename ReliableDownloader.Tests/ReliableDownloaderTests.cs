using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ReliableDownloader.Tests
{
    [TestFixture]
    public class ReliableDownloaderTests
    {
        private WebSystemCalls _webSystemCalls;

        [SetUp]
        public void Setup()
        {
            _webSystemCalls = new WebSystemCalls();
        }

        [Test]
        public async Task TestGetHeadersAsync()
        {
            // Arrange
            string url = "https://www.accurx.com/"; 

            // Act
            var response = await _webSystemCalls.GetHeadersAsync(url, CancellationToken.None);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsNotNull(response.Headers);
        }

        [Test]
        public async Task TestDownloadContentAsync()
        {
            // Arrange
            string url = "https://www.accurx.com/";

            // Act
            var response = await _webSystemCalls.DownloadContentAsync(url, CancellationToken.None);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(content);
        }

        [Test]
        public async Task TestDownloadPartialContentAsync()
        {
            // Arrange
            string url = "https://www.accurx.com/"; 
            long fromByte = 0;
            long toByte = 1000;

            // Act
            var response = await _webSystemCalls.DownloadPartialContentAsync(url, fromByte, toByte, CancellationToken.None);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.IsSuccessStatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual(toByte - fromByte + 1, content.Length);
        }
    }
}
