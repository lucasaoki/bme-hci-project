using Eleven.Common;
using Eleven.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            ObservableCollection<DataClassArtist> obCollec = new ObservableCollection<DataClassArtist>();
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = await DataSource.GetGroupsAsync();
            var RandomDataGroups = await DataSource.GetRandomGroupsAsync();
            var periodDataGroups = DataSource.GetPeriodGroup((ObservableCollection<DataClassArtist>)sampleDataGroups);
            var artistDataGroups = DataSource.GetArtistGroup((ObservableCollection<DataClassArtist>)sampleDataGroups);
            var sculptureDataGroups = DataSource.GetSculptureGroup((ObservableCollection<DataClassArtist>)sampleDataGroups);
            var paintingDataGroups = DataSource.GetPaintingGroup((ObservableCollection<DataClassArtist>)sampleDataGroups);

            obCollec.Add(RandomDataGroups);
            this.DefaultViewModel["Groups"] = sampleDataGroups;
            this.DefaultViewModel["RandomGroup"] = obCollec;

            this.defaultViewModel["PeriodGroup"] = periodDataGroups;
            this.defaultViewModel["ArtistGroup"] = artistDataGroups;
            this.defaultViewModel["SculptureGroup"] = sculptureDataGroups;
            this.defaultViewModel["PaintingGroup"] = paintingDataGroups;
            
        }
        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((DataClassArtist)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemViewer), itemId);

            //this.Frame.Navigate(typeof(ItemViewer), (DataClassArtist)e.ClickedItem);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        /// 




        private void ArtWork_Select_Click(object sender, RoutedEventArgs e)
        {
           

            SectionRandom.Visibility = Visibility.Collapsed;
            SectionFavorite.Visibility = Visibility.Collapsed;
            SectionPeriod.Visibility = Visibility.Collapsed;
            SectionArtist.Visibility = Visibility.Collapsed;
            SectionPainting.Visibility = Visibility.Visible;
            SectionSculpture.Visibility = Visibility.Collapsed;
            //this.Frame.Navigate(typeof(SearchResults), "painting");
        }

        private void Artist_Select_Click(object sender, RoutedEventArgs e)
        {

            SectionRandom.Visibility = Visibility.Collapsed;
            SectionFavorite.Visibility = Visibility.Collapsed;
            SectionPeriod.Visibility = Visibility.Collapsed;
            SectionArtist.Visibility = Visibility.Visible;
            SectionPainting.Visibility = Visibility.Collapsed;
            SectionSculpture.Visibility = Visibility.Collapsed;

            //this.Frame.Navigate(typeof(SearchResults), "artist");
        }

        private void Period_Select_Click(object sender, RoutedEventArgs e)
        {

            SectionRandom.Visibility = Visibility.Collapsed;
            SectionFavorite.Visibility = Visibility.Collapsed;
            SectionPeriod.Visibility = Visibility.Visible;
            SectionArtist.Visibility = Visibility.Collapsed;
            SectionPainting.Visibility = Visibility.Collapsed;
            SectionSculpture.Visibility = Visibility.Collapsed;

            //this.Frame.Navigate(typeof(SearchResults), "period");
        }

        private void Sculpture_Select_Click(object sender, RoutedEventArgs e)
        {

            SectionRandom.Visibility = Visibility.Collapsed;
            SectionFavorite.Visibility = Visibility.Collapsed;
            SectionPeriod.Visibility = Visibility.Collapsed;
            SectionArtist.Visibility = Visibility.Collapsed;
            SectionPainting.Visibility = Visibility.Collapsed;
            SectionSculpture.Visibility = Visibility.Visible;

            //this.Frame.Navigate(typeof(SearchResults), "sculpture");
        }

        private void Home_Select_Click(object sender, RoutedEventArgs e)
        {

            SectionRandom.Visibility = Visibility.Visible;
            SectionFavorite.Visibility = Visibility.Visible;
            SectionPeriod.Visibility = Visibility.Collapsed;
            SectionArtist.Visibility = Visibility.Collapsed;
            SectionPainting.Visibility = Visibility.Collapsed;
            SectionSculpture.Visibility = Visibility.Collapsed;

        }
        
        private void searchBox_Input(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            this.Frame.Navigate(typeof(SearchResults), args.QueryText);
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


    }
}
