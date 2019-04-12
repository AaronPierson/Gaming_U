using Gaming_U.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gaming_U.ViewModels
{
    class PlayerDataSource
    {
       public static ObservableCollection<Player> _players =
            new ObservableCollection<Player>();

        public ICommand RemovePlayerCommand { get; set; }

        //get the current Players
        public static ObservableCollection<Player> GetPlayers()
        {
            if (_players.Count == 0)
            {
                int counter = _players.Count + 1;

                _players.Add(new Player() { Id = counter, Amount = 0, Name = "Player", PointType = "HP", TeamPlay = false});
            }
            return _players;
        }
        //Add a player
        public static ObservableCollection<Player> AddPlayer()
        {            
                int counter = _players.Count + 1;
                _players.Add(new Player() { Id = counter, Amount = 0, Name = "Player", PointType = "HP", TeamPlay = false });           
            return _players;
        }
        //remove a player
        public static ObservableCollection<Player> RemovePlayer(object obj)
        {

            if (_players.Count != 0)
            {
                _players.Remove((Player)obj);
            }
            return _players;
        }
        //delet all players
        public static ObservableCollection<Player> RemoveAllPlayers(ObservableCollection<Player> players)
        {
            if (_players.Count != 0)
            {
                players.Clear();
            }
            return _players;
        }
        //Edit a Player
        //public static Player EditPlayer(object obj, string name, int amount)
        //{
        //    Player 
        //}

        public static DiceNumModel dice = new DiceNumModel();




    }
}
