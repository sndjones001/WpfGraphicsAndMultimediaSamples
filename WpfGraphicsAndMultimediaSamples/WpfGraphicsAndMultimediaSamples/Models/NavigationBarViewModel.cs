using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGraphicsAndMultimediaSamples.GraphicsBrushes;
using WpfGraphicsAndMultimediaSamples.GraphicsEffects;
using WpfGraphicsAndMultimediaSamples.GraphicsOverview;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public class NavigationBarViewModel : BaseViewModel
    {
        private INavigatorViewModel _navigator;

        public ICommand MenuCommand2 => new RelayCommand(() => _navigator.NavigateTo(SelectedItem.GetViewModel()));

        public ObservableCollection<NavigationMenuItem> MenuItems { get; set; }
        public NavigationMenuItem SelectedItem { get; set; }

        public NavigationBarViewModel()
        {
            CreateMenuItems();

            SelectedItem = MenuItems[0];
        }

        public void SetNavigator(INavigatorViewModel navigator) => _navigator = navigator;

        public void CreateMenuItems()
        {
            MenuItems = new()
            {
                new NavigationMenuItem("Graphics", () => new WpfGraphicsViewModel())
                    .AddChildren
                    (
                        new NavigationMenuItem("Effects", () => new WpfGraphicsEffectViewModel())
                            .AddChildren
                            (
                                new("Blur", () => new WpfGraphicsBlurEffectViewModel()),
                                new("Drop Shadow", () => new WpfGraphicsDropShadowEffectViewModel())
                            ),
                        new NavigationMenuItem("Brush", () => new WpfGraphicsBrushViewModel())
                            .AddChildren
                            (
                                new NavigationMenuItem("Solid", () => new WpfGraphicsSolidBrushViewModel()),
                                new NavigationMenuItem("Linear Gradient", () => new WpfGraphicsLinearGradientBrushViewModel()),
                                new NavigationMenuItem("Radial Gradient", () => new WpfGraphicsRadialGradientBrushViewModel()),
                                new NavigationMenuItem("Image", () => new WpfGraphicsImageBrushViewModel())
                            )
                     )
            };
        }
    }
}
