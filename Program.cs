using NSoup;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebMobilenumberScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = NSoupClient.Parse(new WebClient().DownloadString(new Uri("https://receive-smss.com/")));
            var numbers = doc.GetElementsByAttributeValueContaining("class", "number-boxes-itemm-number");
            var countries = doc.GetElementsByAttributeValueContaining("class", "number-boxes-item-country");
            var sb = new StringBuilder();
            for (int i = 0; i < numbers.Count; i++)
            {
                sb.AppendLine($"\"{countries[i].Text()}\", \"{numbers[i].Text()}\",\"https://receive-smss.com/sms/{numbers[i].Text().Replace("+", "")}\"");
            }
            File.WriteAllText("numbers.csv", sb.ToString());
        }
    }
}
