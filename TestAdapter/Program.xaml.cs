using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using TestAdapter.Models;

namespace TestAdapter
{
    /// <summary>
    /// Interaction logic for Program.xaml
    /// </summary>
    public partial class Program : Window
    {
        private readonly string path = @"C:\zadatak\zadatak.xml";

        public Program()
        {
            InitializeComponent();
        }

        private void zatvori_Click(object sender, RoutedEventArgs e)
        {
            // System.Windows.Application.Current.Shutdown(); // close the application
            Close(); // close this window
        }

        private void akcija_Click(object sender, RoutedEventArgs e)
        {           
            xmlPreviewControl.xmlDocument = GetXml();
            Order order = DeserializeXmlToObject();
            var jsonWithTotal = GetTotal(order);
            jsonPreviewControl.jsonDocument = jsonWithTotal;
            var burger = GetBurger(order);
            jsonOrderPreviewControl.BurgerOrder = burger;
        }

        private XmlDocument GetXml()
        {
            XmlDocument XMLdoc = new XmlDocument();

            try
            {
                XMLdoc.Load(path);

                foreach (XmlNode node in XMLdoc)
                {
                    if (node.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        XMLdoc.RemoveChild(node);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The directory " + path + " does not exists. This window will be closed");
                Close();
            }
            catch (XmlException)
            {
                MessageBox.Show("The XML file is invalid");
            }

            return XMLdoc;
        }

        //private string ConvertXmlToJson(XmlDocument xml)
        //{
        //    return JsonConvert.SerializeXmlNode(xml, Newtonsoft.Json.Formatting.Indented, false);
        //}

        private Order DeserializeXmlToObject()
        {
            var serializer = new XmlSerializer(typeof(Order));
            Order result = new Order();
            try
            {
                
                 var reader = new StreamReader(path);

                 result = (Order)serializer.Deserialize(reader);

                
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("The directory " + path + "does not exists. This window will be closed");
                Close();
            }
            catch(XmlException)
            {
                MessageBox.Show("The XML file is invalid");
            }

            return result;
            
        }

        private string GetTotal(Order order)
        {
            try
            {
                if (order.Items != null)
                {
                    foreach (var ord in order.Items)
                    {
                        order.Total += ord.Price;

                        foreach (var modifier in ord.Modifiers)
                        {
                            order.Total += modifier.Price;
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("The XML file is invalid");
            }

            var objectToJson = DeserializeObjectToJson(order);
            return objectToJson;
        }

        private string DeserializeObjectToJson(Object order)
        {
            string jsonString = "";
            if (order != null)
            {
                jsonString = JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented);
            }

            return jsonString;
        }

        private string GetBurger(Order order)
        {
            string burger = "";

            if (order.Items != null)
            {
                foreach (var item in order.Items)
                {
                    if (item.Name == "Burger")
                    {
                        burger = DeserializeObjectToJson(item);
                    }
                }
            }

            return burger;
        }
    }
}
