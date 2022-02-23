using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TestAdapter.Models;

namespace TestAdapter.UserControls
{
    /// <summary>
    /// Interaction logic for JsonPreviewUserControl1.xaml
    /// </summary>
    public partial class JsonPreviewUserControl1 : UserControl
    {
        private string _jsonDocument;
        public JsonPreviewUserControl1()
        {
            InitializeComponent();          
        }

        public string jsonDocument
        {
            get { return _jsonDocument; }
            set
            {
                _jsonDocument = value;
                tBlock.Text = value;
            }
        }
    }
}
