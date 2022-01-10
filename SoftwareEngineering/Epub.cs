using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using SoftwareEngineering.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersOne.Epub;

namespace SoftwareEngineering
{
    public class Epub
    {
        private EBookApplicationContext ctx = null;
        public Epub()
        {
            ctx = new EBookApplicationContext();
        }
        public async Task<EpubBook> ReadFile(string link)
        {
            Uri uri = new Uri(@link);
            var net = new System.Net.WebClient();
            var data = await net.DownloadDataTaskAsync(uri);
            var content = new System.IO.MemoryStream(data);

            EpubBook book = await EpubReader.ReadBookAsync(content);
            content.Close();
            return book;
        }
        public async Task<EpubBook[]> ReadAllFiles()
        {
            var books = ctx.Books.OrderBy(b => b.Name).ToList();
            EpubBook[] epubArray = new EpubBook[books.Count];
            for(int i = 0; i< books.Count; i++)
            {
                EpubBook temp = await ReadFile(books[i].BookLink);
                epubArray[i] = temp;
            }
            return epubArray;
        }


    }
}
