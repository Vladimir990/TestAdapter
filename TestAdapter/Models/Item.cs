using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestAdapter.Models
{
    public class Item
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Quantity")]
        public string Quantity { get; set; }

        [XmlElement("Price")]
        public double Price { get; set; }

        [XmlElement("Modifiers")]
        public List<Modifiers> Modifiers { get; set; }
    }
}
