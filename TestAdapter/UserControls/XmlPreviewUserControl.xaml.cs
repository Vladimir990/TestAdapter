using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace TestAdapter.UserControls
{
    /// <summary>
    /// Interaction logic for XmlPreviewUserControl.xaml
    /// </summary>
    public partial class XmlPreviewUserControl : UserControl
    {
        private XmlDocument _xmlDocument;
        public XmlPreviewUserControl()
        {
            InitializeComponent();
        }

        public XmlDocument xmlDocument
        {
            get { return _xmlDocument; }
            set
            {
                _xmlDocument = value;
                BindXMLDocument();
            }
        }

        private void BindXMLDocument()
        {
            if (_xmlDocument == null)
            {
                xmlTree.ItemsSource = null;
                return;
            }

            XmlDataProvider provider = new XmlDataProvider();
            provider.Document = _xmlDocument;
            Binding binding = new Binding();
            binding.Source = provider;
            binding.XPath = "child::node()";
            xmlTree.SetBinding(TreeView.ItemsSourceProperty, binding);
        }
    }
}
