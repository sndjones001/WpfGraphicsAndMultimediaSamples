using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public class NavigationMenuItem
    {
        public ObservableCollection<NavigationMenuItem> Items { get; set; }
        public string Content { get; set; }

        private IPageViewModel _viewModel;
        private Func<IPageViewModel> _viewModelFactory;

        public NavigationMenuItem(string content, Func<IPageViewModel> viewModelFactory)
        {
            Content = content;
            _viewModelFactory = viewModelFactory;
        }

        public IPageViewModel GetViewModel() => _viewModel = _viewModel ?? _viewModelFactory();

        public NavigationMenuItem AddChildren(params NavigationMenuItem[] children)
        {
            Items = new ObservableCollection<NavigationMenuItem>(children);
            return this;
        }
    }
}
