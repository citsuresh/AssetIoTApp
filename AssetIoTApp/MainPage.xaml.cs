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
using AssetIoTApp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AssetIoTApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.AssetCountForClients = new ObservableCollection<AssetCountForClient>();
        }

        public ObservableCollection<AssetCountForClient> AssetCountForClients { get; set; }

        private void ClickMe_OnClick(object sender, RoutedEventArgs e)
        {

            try
            {
                var countercount = 0;
                var countersByClients = RestServiceHelper.InvokeGet();
                //this.HelloMessage.Text = string.Empty;
                foreach (var countersByClient in countersByClients)
                {
                    var clientID = countersByClient.Key;
                    var assetCount = countersByClient.Value.Count();
                    //this.HelloMessage.Text += string.Format("Client '{0}' has {1} Assets; \n", clientID, assetCount);
                    this.AssetCountForClients.Add(new AssetCountForClient { ClientID = clientID, AssetCount = assetCount });
                    countercount += assetCount;
                }

                this.HelloMessage.Text = "Total number of assets = " + countercount;
            }
            catch (Exception exception)
            {
                this.HelloMessage.Text = exception.GetDisplayMessage();
            }
        }
    }
}
