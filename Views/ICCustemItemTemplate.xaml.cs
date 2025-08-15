using SELF_KBM_DESIGN.Models;
using SELF_KBM_DESIGN.ViewModels;
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
using System.Windows.Shapes;

namespace SELF_KBM_DESIGN.Views
{
    /// <summary>
    /// Interaction logic for ICCustemItemTemplate.xaml
    /// </summary>
    public partial class ICCustemItemTemplate : Window
    {
        public ICCustemItemTemplate()
        {
            InitializeComponent();
            DataContext = new ItemControlViewModel();
            //DataContext = new ListBoxViewModel();
            var vm = new ListBoxViewModel();
           var items = vm.iListBoxes;
            MyListBox.ItemsSource = items;
        }
    }
}
