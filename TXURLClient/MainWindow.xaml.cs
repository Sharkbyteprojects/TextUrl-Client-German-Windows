using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using RestSharp;
namespace TXURLClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var titles = title.Text;
            var mess = message.Text;
            //CODE
            var permut = "/new/query?title=" + titles + "&message=" + mess;
            Send(permut, false);
            //-CODE
        }
        private void Send(string addre, bool get)
        {
            bool ons = true;
            var url = addr.Text + addre;
            var output = "";
            if (url != "")
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                string result = System.Text.Encoding.UTF8.GetString(client.DownloadData(request));
                output = result;
            }
            else
            {
                ons = false;
                output = "Bitte geben sie eine serveraddresse ein!";
            }
            if (!get)
            {
                outn.Text = output;
                if (ons)
                {
                    var shulr= addr.Text + "/ang/show?get=" + output;
                    shurl.Text = "Url: " + shulr + "     In Zwischenablage kopiert";
                    Clipboard.Clear();
                    DataObject dataObject = new DataObject();
                    dataObject.SetData(DataFormats.Text, shulr);
                    Clipboard.SetDataObject(dataObject);
                }
            }
            else
            {
                //tilet.Text;
                //getimes.Text;
                //remtem.IsEnabled = true;
                //var tokens = output.Split("-- ||||||||| --".ToCharArray());
                tilet.Text = output;
                remtem.IsEnabled = true;
            }

        }

       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var idge = getid.Text;
            int i = 0;
            bool result = int.TryParse(idge, out i);
            if (!result)
            {
                getid.Text = "";
                idgew.Text = "Bitte geben sie einen Numerischen wert ein!";
            }
            else
            {
                var permut = "/userdef/seperate/" + idge;
                Send(permut,true);
            }
        }
        private void delete(string numberl)
        {
           
                var url = addr.Text + "/delete/" + numberl;
            
            if (url != "")
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                System.Text.Encoding.UTF8.GetString(client.DownloadData(request));
                //tilet.Text = "Removed";
                tilet.Text = "ID " + numberl + " Removed";
            }
            else
            {
                tilet.Text = "Bitte geben sie eine nummer zum Löschen ein!";
                //getimes.Text = "";
            }
            remtem.IsEnabled = false;
        }

        private void Remtem_Click(object sender, RoutedEventArgs e)
        {
            var idge = getid.Text;
            int i = 0;
            bool result = int.TryParse(idge, out i);
            if (!result)
            {
                getid.Text = "";
                idgew.Text = "Bitte geben sie einen Numerischen wert ein!";
            }
            else
            {
                delete(idge);
            }
        }

        private void Servs_Click(object sender, RoutedEventArgs e)
        {
            if (servs.IsChecked == true)
            {
                addr.Text = "https://morning-tor-58273.herokuapp.com";
                addr.IsEnabled = false;
                wiudgaziauaifw.IsEnabled = false;
            }
            else
            {
                addr.Text = "";
                addr.IsEnabled = true;
                wiudgaziauaifw.IsEnabled = true;
            }
        }
    }
}
