using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ImageTagsLogic
    {
        public bool GetTags(string imgpath)
        {
            //List<string> result = new List<string>();
            ImageAnalysis dal = new ImageAnalysis();
            ImageDetails DrugImage = new ImageDetails(imgpath);
            bool result = false;

            Dictionary<string, double> listimg= dal.GetTags(DrugImage);
            List<string> option = new List<string>() { "diet","pills", "bottle", "medicine", "medical","pill bottle", "pill","drug","drugs","cure","prescription drug"};
            List<string> listresult = new List<string>();
            foreach(var item in DrugImage.Details)
                if(item.Value>69)
                {
                    if (option.Contains(item.Key))
                        result = true;

                }

            /*  var listresult=from re in listimg
                             where re.Value>70&& option.Contains(re.Key)
                             select re.Key;*/
            //צריך לבדוק מה הkey
            //  List<string> Li = (List<string>)listresult;
            return result;

        }
    }
}
