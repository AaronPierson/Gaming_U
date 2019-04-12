using Gaming_U.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gaming_U.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InputDialog : Page
    {
        Player player;
        public InputDialog()
        {
            this.InitializeComponent();

        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

           
             base.OnNavigatedTo(e);
            var param = (Player)e.Parameter;
            txtName.Text = param.Name.ToString();
            txtAmount.Text = param.Amount.ToString();
            
            player = param;
        }


        private void btnInputCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private  async void btnInputEdit_Click(object sender, RoutedEventArgs e)
        {

            //var Play = Player
            try
            {
                if (await IsPresent(txtName, "Name") && await IsInt(txtAmount, "numbers"))
                {
                    string Name = txtName.Text;
                    int Amount = Convert.ToInt32(txtAmount.Text);
                    player.Amount = Amount;
                    player.Name = Name;
                }
                
            }
            catch
            {
                var dialog = new MessageDialog("enter ");
                   await dialog.ShowAsync();
            }

           
            //int Amount = Convert.ToInt32( txtAmount.Text);
            this.Frame.Navigate(typeof(MainPage), player);
        }

        //public Task<bool> IsValidData()
        //{

        //    return
        //        IsPresent(txtName, "Names")
                
        //        IsInt(txtAmount, "Numbers");
            
        //}

        public async Task<bool> IsPresent(TextBox textBox, string name)
        {
            if(textBox.Text == "")
            {
                var dialog = new MessageDialog("Please Enter a Name");
                await dialog.ShowAsync();
                //textBox.Focus();
                return false;
            }
           return true;
        }

        public async Task<bool> IsInt(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
           
            var dialog = new MessageDialog("Please enter a valid number", "Invalid Number");
            await dialog.ShowAsync();
            
            //textBox.Focus();
            return false;
        }
    }
}
