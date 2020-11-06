using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlateReader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateReader.Helper
{
    public static class JsonHelper
    {
        /// <summary>
        /// This public static method will read the Json file and convet to a Root object 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static Root GetPlateDropletInfo(string filepath)
        {
            var jobj = ReadJson(filepath);
            if (jobj != null)
            {
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    var data = (Root)serializer.Deserialize(new JTokenReader(jobj), typeof(Root));
                    return data;
                }
                catch (Exception ex)
                {
                    // Log serialization exceptions, chances are file might have corrupted date and serialization throws exception
                }
            }

            // Log here that the jobj is null
            return null;
        }

        /// <summary>
        /// This private method will read the Json file and convert to JObject
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private static JObject ReadJson(string filepath)
        {
            JObject jobj = null;

            using (StreamReader r = new StreamReader(filepath))
            {
                try
                {
                    var json = r.ReadToEnd();
                    jobj = JObject.Parse(json);
                }
                catch( Exception ex)
                {
                    // Log exceptions 
                }
                    
                return jobj;

            }

        }

    }
}
