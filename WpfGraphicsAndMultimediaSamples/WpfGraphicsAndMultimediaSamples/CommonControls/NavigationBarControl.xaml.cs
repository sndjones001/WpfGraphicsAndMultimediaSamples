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
using WpfGraphicsAndMultimediaSamples.Models;

namespace WpfGraphicsAndMultimediaSamples.CommonControls
{
    /// <summary>
    /// Interaction logic for NavigationBarControl.xaml
    /// </summary>
    public partial class NavigationBarControl : UserControl
    {
        public NavigationBarViewModel NavigationBarViewModel { get; set; } = new NavigationBarViewModel();

        public NavigationBarControl()
        {
            InitializeComponent();

            trvNavigationMenu.ItemsSource = NavigationBarViewModel.MenuItems;
        }
    }
}
