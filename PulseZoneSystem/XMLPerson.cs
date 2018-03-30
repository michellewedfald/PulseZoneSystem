using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PulseZoneSystem
{
    public class XMLPerson
    {
        //gem data som xml-fil via serialize
        public static void Save(Configuration configuration,
            string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);

            XmlSerializer serializer =
                new XmlSerializer(typeof(Configuration));

            serializer.Serialize(fs, configuration);
            fs.Close();
        }

        //hent data fra xml-fil via deserialize
        public static Configuration Load(string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Open);

            XmlSerializer serializer =
                new XmlSerializer(typeof(Configuration));

            Configuration configuration =
                (Configuration)serializer.Deserialize(fs);

            return configuration;
        }
    }
}
