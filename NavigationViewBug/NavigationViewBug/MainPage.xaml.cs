using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NavigationViewBug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FrameContent.Navigate(typeof(Page1));
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            base.OnNavigatedTo(e);
        }

        private void OnItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            switch (args.InvokedItemContainer.Tag)
            {
                case "Page #1":
                    FrameContent.Navigate(typeof(Page1));
                    break;
                case "Page #2":
                    FrameContent.Navigate(typeof(Page2));
                    break;
                default:
                    Frame.Navigate(typeof(Page3));
                    break;
            }
        }
    }
}
