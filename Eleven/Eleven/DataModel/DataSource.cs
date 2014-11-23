using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace Eleven.Data
{


    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class DataClassArtist
    {
        public DataClassArtist(String uniqueId, String artist, String period, String title, String imagePath, String threeDPath, String description, String content)
        {
            this.UniqueId = uniqueId;
            this.Artist = artist;
            this.Period = period;
            this.Title = title;
            this.Description = description;
            this.ImagePath = imagePath;
            this.ThreeDPath = threeDPath;
            this.Content = content;
        }


        public string UniqueId { get; private set; }
        public string Artist { get; private set; }
        public string Period { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string ThreeDPath { get; private set; }
        public string Content { get; private set; }

        public override string ToString()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add(this.UniqueId);
            list.Add(this.Artist);
            list.Add(this.Period);
            list.Add(this.Title);
            list.Add(this.Content);

            return String.Concat(list);
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class DataSource
    {
        private static DataSource _DataSource = new DataSource();

        private ObservableCollection<DataClassArtist> _groups = new ObservableCollection<DataClassArtist>();

        public ObservableCollection<DataClassArtist> Groups
        {
            get { return this._groups; }
        }

        public static async Task<IEnumerable<DataClassArtist>> GetGroupsAsync()
        {
            await _DataSource.GetSampleDataAsync();

            return _DataSource.Groups;
        }

        public static async Task<DataClassArtist> GetGroupAsync(string uniqueId)
        {
            await _DataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _DataSource.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetSampleDataAsync()
        {
            if (this._groups.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/Database.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Groups"].GetArray();

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                DataClassArtist group = new DataClassArtist(groupObject["UniqueId"].GetString(),
                                                            groupObject["Artist"].GetString(),
                                                            groupObject["Period"].GetString(),
                                                            groupObject["Title"].GetString(),
                                                            groupObject["ImagePath"].GetString(),
                                                            groupObject["ThreeDPath"].GetString(),
                                                            groupObject["Description"].GetString(),
                                                            groupObject["Content"].GetString());

                this.Groups.Add(group);
            }
        }
    }
}