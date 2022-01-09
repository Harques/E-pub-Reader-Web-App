using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VersOne.Epub;

namespace SoftwareEngineering
{
    public class Epub
    {
        public async Task<EpubBook> ReadFile()
        {
            Uri uri = new Uri(@"https://sebooks.blob.core.windows.net/ebooks/ursula-k-le-guin-dunyanin-dogum-gunu.epub");
            var net = new System.Net.WebClient();
            var data = await net.DownloadDataTaskAsync(uri);
            var content = new System.IO.MemoryStream(data);

            EpubBook book = await EpubReader.ReadBookAsync(content);
            return book;
        }


    }
}
