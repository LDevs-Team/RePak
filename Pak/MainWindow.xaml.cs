using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using PakCore;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Packaging;

namespace Pak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Package
        {
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;

            public string Image { get; set; } = "https://www.macworld.com/wp-content/uploads/2023/01/folder-icon-macos-1.png";
            // Other properties like download_url, screenshots, etc.
        }
        public List<Package> Packages { get; set; } = new List<Package>();
        private async void OnInitializeApp()
        {
            PakCore.PakCore core = new PakCore.PakCore("http://localhost:5555");
            JObject ServerPackages = await core.FetchPackages();
            LoadingBar.Visibility = Visibility.Hidden;
            foreach (var item in ServerPackages.GetValue("packages"))
            {
                Trace.WriteLine(item.ToString());
                Package? formattedItem = new Package { Name = ((JObject)item).GetValue("name").ToString(), Description = ((JObject)item).GetValue("description").ToString(), Image = ((JObject)item).GetValue("imageUrl").ToString() };
                Trace.WriteLine(formattedItem.Name);
                
                Packages.Add(formattedItem);
            };
            DataContext = this;
            ItemsController.Items.Refresh();

            return;
        }
        public MainWindow()
        {
            InitializeComponent();
            
            OnInitializeApp();
        }
    }
}
