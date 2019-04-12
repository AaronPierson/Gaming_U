using Gaming_U.Models;
using Gaming_U.ViewModels;
using Gaming_U.Views;
using Gaming_U.Views.Inputs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gaming_U
{
    /// <summary>
    /// Progammer: Aaron Pierson
    ///
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //get the data from the sources
        public Task<List<string>> FNames = NameDataSource.GetFNames();
        public Task<List<string>> MNames = NameDataSource.GetMNames();
        public ObservableCollection<Player> _playersViewModel =
            PlayerDataSource.GetPlayers();

        public ObservableCollection<Player> PlayersViewModel
        {
            get { return this._playersViewModel; }
            set { }
        }
        //add some default values
        public MainPage()
        {
            this.InitializeComponent();
            //applying defaults
            PlayerDataSource.dice.maxNum = 12;
            PlayerDataSource.dice.minNum = 1;
            txtRange.Text = PlayerDataSource.dice.minNum + " - " + PlayerDataSource.dice.maxNum;
        }

        //code for the listview
        #region code for the listview
        //Adding Player
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PlayerDataSource.AddPlayer();
        }
        //Removing Player
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var btnRemove = (Button)sender;
            var btnPlayer = (Player)btnRemove.DataContext;
            PlayerDataSource.RemovePlayer(btnPlayer);
        }
        //editing the players info
        private void lstofPlayers_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Player = (Player)e.ClickedItem;
            this.Frame.Navigate(typeof(InputDialog), Player);
        }
        //removing everbody
        private void btnRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            PlayerDataSource.RemoveAllPlayers(PlayersViewModel);
        }
        //nav for the players
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = e.Parameter;

        }
        #endregion

        //code for the appbar
        #region appbarcode
            //showing the timer
        //private void btnTimer_Click(object sender, RoutedEventArgs e)
        //{
        //    if (stkTime.Visibility == Visibility.Visible)
        //    {
        //        stkTime.Visibility = Visibility.Collapsed;
        //        btnClearTimer.Visibility = Visibility.Collapsed;
        //        btnStartTimer.Visibility = Visibility.Collapsed;
        //        btnStopTimer.Visibility = Visibility.Collapsed;
        //    }
        //    else if (stkTime.Visibility == Visibility.Collapsed)
        //    {
        //        stkTime.Visibility = Visibility.Visible;
        //        btnClearTimer.Visibility = Visibility.Visible;
        //        btnStartTimer.Visibility = Visibility.Visible;
        //        btnStopTimer.Visibility = Visibility.Visible;
        //    }

        //}
        //code for add team options
        private void btnTeams_Click(object sender, RoutedEventArgs e)
        {

        }
        //showing the number roll
        private void btnShowRoll_Click(object sender, RoutedEventArgs e)
        {
            if (stkRoll.Visibility == Visibility.Visible)
            {
                stkRoll.Visibility = Visibility.Collapsed;
                btnRollNumber.Visibility = Visibility.Collapsed;

            }
            else if (stkRoll.Visibility == Visibility.Collapsed)
            {
                stkRoll.Visibility = Visibility.Visible;
                btnRollNumber.Visibility = Visibility.Visible;


            }
        }
        //showing the name gen
        private void btnShowName_Click(object sender, RoutedEventArgs e)
        {
            if (stkNames.Visibility == Visibility.Visible)
            {
                stkNames.Visibility = Visibility.Collapsed;
                btnGenName.Visibility = Visibility.Collapsed;

            }
            else if (stkNames.Visibility == Visibility.Collapsed)
            {
                stkNames.Visibility = Visibility.Visible;
                btnGenName.Visibility = Visibility.Visible;

            }
        }
        int checker = 1;
        private async void btnGenName_Click(object sender, RoutedEventArgs e)
        {

            if(checker == 1)
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(2, MNames.Result.Count);
                txtName.Text = MNames.Result[rndNum];
            }
           else if(checker == 2)
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(2, FNames.Result.Count);
                txtName.Text = FNames.Result[rndNum];
            }
            
            //var diolag = new MessageDialog(FNames.Result[5]);
            //await diolag.ShowAsync();
           
        }
        //gen a random number
        private void btnRollNumber_Click(object sender, RoutedEventArgs e)
        {
            //gen a random number
            Random rnd = new Random();
            int Rnumber = rnd.Next(PlayerDataSource.dice.minNum, PlayerDataSource.dice.maxNum + 1);
            txtRoll.Text = Rnumber.ToString();
        }
        //code to get user input for the dice roll
        private async void txtRoll_Tapped(object sender, TappedRoutedEventArgs e)
        {

            ContentDialogDice dialog = new ContentDialogDice();
            await dialog.ShowAsync();
            txtRange.Text = PlayerDataSource.dice.minNum + " - " + PlayerDataSource.dice.maxNum;
        }
        //get user input for the name gen
        private async void txtName_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentDialogNames dialog = new ContentDialogNames();
            await dialog.ShowAsync();
            checker = dialog.checknumber();
        }

        #region code fo the timer
        //Timer
        //private int time = 0;
        //public static DispatcherTimer Timer = new DispatcherTimer();
        //starting the timer
        //private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        //{
            
        //    Timer.Interval = new TimeSpan(0, 0, 1);
        //    Timer.Tick += Timer_tick;
        //    Timer.Start();
        //    TimerDataSource TDS = new TimerDataSource();
        //    TDS.DispatcherTimerSetup();
        //}
        //incrmenting the timer
        //private void Timer_tick(object sender, object e)
        //{
        //    time++;
        //    txtTimer.Text = string.Format("0:{0}:{1}", time / 60, time % 60);
        //}
        ////Pasuing the timer
        //private void btnStopTimer_Click(object sender, RoutedEventArgs e)
        //{
        //    Timer.Stop();
        //}
        ////stoping and clearing the timer
        //private void btnClearTimer_Click(object sender, RoutedEventArgs e)
        //{
        //    Timer.Stop();
        //    txtTimer.Text = "0:0:0";
        //}
        #endregion

    }
    #endregion
}
