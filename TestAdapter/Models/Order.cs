using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestAdapter.Models
{
    [XmlRoot("Order")]
    public class Order
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Total")]
        public double Total { get; set; }

        [XmlElement("Item")]
        public List<Item> Items { get; set; }
    }
}
