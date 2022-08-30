using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGraphicsAndMultimediaSamples.GraphicsEffects;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public class NavigationBarViewModel : BaseViewModel
    {
        private INavigatorViewModel _navigator;

        public ICommand MenuCommand => new RelayCommand<EPageViewControl>(x => _navigator.NavigateTo(x));

        public Dictionary<EPageViewControl, IPageViewModel> PageViewModels { get; private set; }
        public ObservableCollection<NavigationMenuItem> MenuItems { get; set; }

        public NavigationBarViewModel()
        {
            PageViewModels = new();

            RegisterGraphicsEffectViews();
            CreateMenuItems();
        }

        public void SetNavigator(INavigatorViewModel navigator) => _navigator = navigator;

        private void RegisterGraphicsEffectViews()
        {
            PageViewModels.Add(EPageViewControl.WpfGraphicsEffect, new WpfGraphicsEffectViewModel());
            PageViewModels.Add(EPageViewControl.WpfGraphicsBlurEffect, new WpfGraphicsBlurEffectViewModel());
            PageViewModels.Add(EPageViewControl.WpfGraphicsDropShadowEffect, new WpfGraphicsDropShadowEffectViewModel());
        }

        public void CreateMenuItems()
        {
            MenuItems = new()
            {
                new()
                {
                    Content = "Graphics",
                    Items = new()
                    {
                        new()
                        {
                            Content = "Effects",
                            PageType = EPageViewControl.WpfGraphicsEffect,
                            Items = new()
                            {
                                new()
                                {
                                    Content = "Blur",
                                    PageType = EPageViewControl.WpfGraphicsBlurEffect
                                },
                                new()
                                {
                                    Content = "Drop Shadow",
                                    PageType = EPageViewControl.WpfGraphicsDropShadowEffect
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
