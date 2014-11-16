using Eleven.Common;
using Eleven.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Windows;
using System.Windows.Input;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace Eleven
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = await DataSource.GetGroupsAsync();
            this.DefaultViewModel["Groups"] = sampleDataGroups;
        }


        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((DataClassItem)e.ClickedItem).UniqueId;
            // this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void ArtWork_Select_Click(object sender, RoutedEventArgs e)
        {
            Home_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artwork_Grid.Background = new SolidColorBrush(Windows.UI.Colors.Firebrick);
            Artist_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Period_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Sculpture_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray); 
        }

        private void Artist_Select_Click(object sender, RoutedEventArgs e)
        {
            Home_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artwork_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artist_Grid.Background = new SolidColorBrush(Windows.UI.Colors.Firebrick);
            Period_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Sculpture_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray); 
        }

        private void Period_Select_Click(object sender, RoutedEventArgs e)
        {
            Home_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artwork_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artist_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Period_Grid.Background = new SolidColorBrush(Windows.UI.Colors.Firebrick);
            Sculpture_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray); 
        }

        private void Sculpture_Select_Click(object sender, RoutedEventArgs e)
        {
            Home_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artwork_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artist_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Period_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Sculpture_Grid.Background = new SolidColorBrush(Windows.UI.Colors.Firebrick); 
        }

        private void Home_Select_Click(object sender, RoutedEventArgs e)
        {
            Home_Grid.Background = new SolidColorBrush(Windows.UI.Colors.Firebrick);
            Artwork_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Artist_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Period_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
            Sculpture_Grid.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateGray);
        }

        private void Artwork_PointerMoved(object sender, RoutedEventArgs e)
        {
            Home_TextBox.Opacity = 0.25;
            ArtWork_TextBox.Opacity = 1;
            Artist_TextBox.Opacity = 0.25;
            Period_TextBox.Opacity = 0.25;
            Sculpture_TextBox.Opacity = 0.25;
        }

        private void Artist_PointerMoved(object sender, RoutedEventArgs e)
        {
            Home_TextBox.Opacity = 0.25;
            ArtWork_TextBox.Opacity = 0.25;
            Artist_TextBox.Opacity = 1;
            Period_TextBox.Opacity = 0.25;
            Sculpture_TextBox.Opacity = 0.25;
        }

        private void Period_PointerMoved(object sender, RoutedEventArgs e)
        {
            Home_TextBox.Opacity = 0.25;
            ArtWork_TextBox.Opacity = 0.25;
            Artist_TextBox.Opacity = 0.25;
            Period_TextBox.Opacity = 1;
            Sculpture_TextBox.Opacity = 0.25;
        }

        private void Sculpture_PointerMoved(object sender, RoutedEventArgs e)
        {
            Home_TextBox.Opacity = 0.25;
            ArtWork_TextBox.Opacity = 0.25;
            Artist_TextBox.Opacity = 0.25;
            Period_TextBox.Opacity = 0.25;
            Sculpture_TextBox.Opacity = 1;
        }
        private void Home_PointerMoved(object sender, RoutedEventArgs e)
        {
            Home_TextBox.Opacity = 1;
            ArtWork_TextBox.Opacity = 0.25;
            Artist_TextBox.Opacity = 0.25;
            Period_TextBox.Opacity = 0.25;
            Sculpture_TextBox.Opacity = 0.25;
        }

        private void ArtWork_TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
