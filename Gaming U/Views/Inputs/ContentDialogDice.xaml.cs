using Gaming_U.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gaming_U.Views.Inputs
{
    public sealed partial class ContentDialogDice : ContentDialog
    {
        public ContentDialogDice()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //DiceDataSource dicesource = new DiceDataSource();
            //dicesource.minNum = Convert.ToInt32(txtmin.Text);
            //dicesource.maxNum = Convert.ToInt32(txtMax.Text);
            ErrorCheck checking = new ErrorCheck();
            try
            {
                if(await checking.IsInt(txtMax,"numbers") && await checking.IsInt(txtmin, "numbers"))
                PlayerDataSource.dice.maxNum = Convert.ToInt32(txtMax.Text);
                PlayerDataSource.dice.minNum = Convert.ToInt32(txtmin.Text);
            }
            catch (Exception ex)
            {
                //var diolog = new MessageDialog( "Enter a valid number ","error");
                //await diolog.ShowAsync();

            }
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
