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
        public EPageViewControl PageType { get; set; }
        public string Content { get; set; }

        public NavigationMenuItem()
        {
            Items = new();
        }
    }
}
