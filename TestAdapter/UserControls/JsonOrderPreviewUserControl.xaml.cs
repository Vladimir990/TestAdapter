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
using TestAdapter.Models;

namespace TestAdapter.UserControls
{
    /// <summary>
    /// Interaction logic for JsonOrderPreviewUserControl.xaml
    /// </summary>
    public partial class JsonOrderPreviewUserControl : UserControl
    {
        private string _burgerOrder;
        public JsonOrderPreviewUserControl()
        {
            InitializeComponent();
        }

        public string BurgerOrder
        {
            get { return _burgerOrder; }
            set
            {
                _burgerOrder = value;
                tBlock.Text = value;

            }
        }
    }
}
