using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.IO;

namespace SoftwareEngineering
{
    public class AzureFileClient
    {
        public static void ReadFile()
        {

            //ShareDirectoryClient sharedirectoryclient = shareclient.GetDirectoryClient(directoryname);
            string myconnectionString = "DefaultEndpointsProtocol=https;AccountName=sebooks;AccountKey=lFyZn1ZQQqN06uF5MbPSlb1syfFurc2oRowZTz421cr2J+Ceyz/4/ijRZIPAMGmLTU9f6TJCqqd5n2ITEgdT7A==;EndpointSuffix=core.windows.net";
            string myshareName = "https://sebooks.file.core.windows.net/ebookshare";
            string mydirName = "sebooks/ebooks";
            string myfileName = "Franz Kafka - Dönüşüm (İş Bankası).epub";
            string localFilePath = "asd";

            ShareClient myshare = new ShareClient(myconnectionString, myshareName);
            ShareDirectoryClient directory = myshare.GetDirectoryClient(mydirName);
            ShareFileClient file = directory.GetFileClient(myfileName);
            // Download the file
            ShareFileDownloadInfo download = file.Download();
            FileStream stream = File.OpenWrite(localFilePath);
            download.Content.CopyTo(stream);
        }


    }
}
