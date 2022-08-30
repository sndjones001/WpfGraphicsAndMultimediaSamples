using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGraphicsAndMultimediaSamples.GraphicsEffects;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public class MainViewModel : BaseViewModel, INavigatorViewModel
    {
        private IPageViewModel _selectedView;
        public NavigationBarViewModel NavigationBarView { get; protected set; }

        public IPageViewModel SelectedView
        {
            get { return _selectedView; }
            set { _selectedView = value; OnPropertyChanged(); }
        }

        public void NavigateTo(EPageViewControl viewType)
        {
            SelectedView = NavigationBarView.PageViewModels[viewType];
        }

        public MainViewModel(NavigationBarViewModel navigationBarView)
        {
            NavigationBarView = navigationBarView;
            NavigationBarView.SetNavigator(this);
        }
    }
}
