using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Gaming_U.Views
{
    class ErrorCheck
    {
        public async Task<bool> IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
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
