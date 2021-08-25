using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ScrapHealthData
    {
        public string GetDoctorApproval(string mname,string license)
        {
            var Url = "https://practitioners.health.gov.il/Practitioners/1/search?name=&license=" + license;
            String url = "https://practitioners.health.gov.il/Practitioners/1/search?name=&license=" + license;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string re = sr.ReadToEnd();
            


            /*
            string result = "";
           
            var Url = "https://practitioners.health.gov.il/Practitioners/1/search?name=&license="+ license;
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
           var Result = req.GetResponse();
            System.IO.Stream RStream = Result.GetResponseStream();
            //
            //WebClient client = new WebClient();
            
              //  string htmlCode = client.DownloadString("https://practitioners.health.gov.il/Practitioners/1/search?name=&license=" + licence);
            
            //
            System.IO.StreamReader sr = new System.IO.StreamReader(RStream);
            //new System.IO.StreamReader(RStream);
           string Page_Source_Code = sr.ReadToEnd();
            if(Page_Source_Code.Contains("/assets/icons/status_valid.svg"))
                {
                result = "ok";
                }
            
            sr.Dispose();

            return result;
            */
            return re;
        }
    }
}
