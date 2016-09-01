using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeleStarFramework.Deserializer
{
    [Serializable()]
    [XmlRoot("Testxml")]
    public class TestXML
    {
        [XmlElement("TestSet")]
        public List<TestSet> TestSets { get;  set;}
    }
}
