using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program9
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("http://google.com");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream str = response.GetResponseStream();

            using (StreamReader sr = new StreamReader(str))
            {
                using (StreamWriter sw = new StreamWriter("HttpResponse.html"))
                {
                    sw.Write(sr.ReadToEnd());
                    sw.Flush();
                }
            }
        }
    }
}
