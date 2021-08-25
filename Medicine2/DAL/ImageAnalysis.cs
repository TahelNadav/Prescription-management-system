using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImageAnalysis
    {
        public Dictionary<string,double> GetTags(ImageDetails CurrentImage)
        {
            string apiKey = "acc_b8acaa3605b1e28";
            string apiSecret = "6dcca611850678f8cdef3d2c81121811";
            string image =@"C:\Users\tahel\Desktop\דטה בייס\Medicine2\Medicine"+CurrentImage.ImagePath;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            request.AddFile("image", image);

            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            ImaggaRoot myDeserializedClass = JsonConvert.DeserializeObject<ImaggaRoot>(response.Content);
            foreach (var item in myDeserializedClass.result.tags)
            {
                CurrentImage.Details.Add(item.tag.en,item.confidence);
            }
            return CurrentImage.Details;

        }
    }
}
