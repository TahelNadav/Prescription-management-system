using DAL.ConvertRxHelper;
using DAL.DrugConflictHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class DrugConflict
    {
      
        public List<string> DrugConflictchecklist(string ndc1, List<string> ndc2)
        {
            List<string> result = new List<string>();
            if (ndc2.Count() != 0)
            {
                //bool result = false;
                var ConvertToRxUrlnx1 = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + ndc1;


                WebClient wc = new WebClient();
                List<string> nxlist = new List<string>();
                foreach (string itemndc in ndc2)
                {
                    var ConvertToRxUrlnx2 = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + itemndc;
                    var xml2 = wc.DownloadString(ConvertToRxUrlnx2);
                    XmlDocument doc2 = new XmlDocument();
                    doc2.LoadXml(xml2);

                    string myJsonResponse2 = JsonConvert.SerializeXmlNode(doc2);
                    Root myDeserializedClass2 = JsonConvert.DeserializeObject<Root>(myJsonResponse2);
                    string rxnormId2 = myDeserializedClass2.rxnormdata.idGroup.rxnormId;
                    if (rxnormId2 != null)
                    {
                        nxlist.Add(rxnormId2);
                    }
                }

                //////////////////////////////////////////////convert rx
                var xml1 = wc.DownloadString(ConvertToRxUrlnx1);
                XmlDocument doc1 = new XmlDocument();
                doc1.LoadXml(xml1);

                string myJsonResponse1 = JsonConvert.SerializeXmlNode(doc1);
                Root myDeserializedClass1 = JsonConvert.DeserializeObject<Root>(myJsonResponse1);
                string rxnormId1 = myDeserializedClass1.rxnormdata.idGroup.rxnormId;

                String InteractionURL = "https://rxnav.nlm.nih.gov/REST/interaction/list?rxcuis=";

                //////////////////////////////////////////////convert rx
                if (rxnormId1 != null)
                {

                     InteractionURL += rxnormId1;
                }
                

                foreach (string rxitem in nxlist)
                {
                    InteractionURL += "+" + rxitem;
                }
                WebClient client = new WebClient();

                string myXmlResponse = client.DownloadString(InteractionURL);
                XmlDocument docre = new XmlDocument();
                docre.LoadXml(myXmlResponse);
                string jsonre = JsonConvert.SerializeXmlNode(docre);
                ConflictRoot myDeserializedClass = JsonConvert.DeserializeObject<ConflictRoot>(jsonre);

                try
                {

                    string comment = myDeserializedClass.interactiondata.fullInteractionTypeGroup.fullInteractionType.comment;
                    result.Add("cpmment:" + comment);
                    foreach (var item in myDeserializedClass.interactiondata.fullInteractionTypeGroup.fullInteractionType.interactionPair)
                    {
                        result.Add("severity:" + item.severity);
                        result.Add("description:" + item.description);

                    }
                }
                catch (Exception)
                {
                    result.Add("המרשם עודכן בהצלחה");
                }

                return result;
            }
            else
               return result;

        }
    }
}
