using Gaming_U.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace Gaming_U.ViewModels
{
    class NameDataSource
    {


        //public static Task<ObservableCollection<string>> FFNames = GetFNames();
  
       
        public async static Task<List<string>> GetFNames()
        {
            //Finding the folder the app is intalled to
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //The location For each Name flile
            string FFfile = @"Assets\Names\Female\Human_Names_-_Fantasy_Female.csv";
            
            StorageFile FFF = await InstallationFolder.GetFileAsync(FFfile);
            var FFlines = await FileIO.ReadLinesAsync(FFF);
            //ObservableCollection<Names> FFN = (ObservableCollection<Names>)FFlines;

            List<string> FFNames = FFlines.ToList();
            return FFNames;
        }



        public async static Task<List<string>> GetMNames()
        {
             //Finding the folder the app is intalled to
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //The location For each Name flile
            string FFfile = @"Assets\Names\Male\Human_Names_-_Fantasy_Male.csv";

            StorageFile MFF = await InstallationFolder.GetFileAsync(FFfile);
            var MFlines = await FileIO.ReadLinesAsync(MFF);
            //ObservableCollection<Names> FFN = (ObservableCollection<Names>)FFlines;

            List<string> MFNames = MFlines.ToList();
            return MFNames;
        }

    }

    
   
}

