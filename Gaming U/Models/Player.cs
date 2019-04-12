using Gaming_U.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gaming_U.Models
{
    //Creating A player Object
    public class Player : ObservableObjects
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChange("Name");
            }
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChange("Amount"); }
        }

        private string _pointType;

        public string  PointType
        {
            get { return _pointType; }
            set { _pointType = value; OnPropertyChange("PointType"); }
        }

        private bool _teamplay;

        public bool TeamPlay
        {
            get { return _teamplay; }
            set { _teamplay = value; OnPropertyChange("TeamPlay"); }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChange("Color"); }
        }

        public ICommand GivePointsCommand { get; set; }
        public ICommand TakePointsCommand { get; set; }
        public ICommand ClearPointsCommand { get; set; }
        public ICommand RemovePlayerCommand { get; set; }
        public ICommand ChangePlayerNameCommand { get; set; }
        public ICommand TeamPlayCommand { get; set; }
        public Player()
        {
            GivePointsCommand = new GivePlayerPointsClick();
            TakePointsCommand = new TakePlayerPointsClick();
            ClearPointsCommand = new ClearPlayerPointsClick();
            RemovePlayerCommand = new RemovePlayerClick();
            ChangePlayerNameCommand = new ChangePlayerNameClick();
            TeamPlayCommand = new TeamPlayClick();
        }

        public void GiveInPoints()
        {
            this.Amount += 1;
            /*String.Format("{0:t}", DateTime.Now);*/
        }
        public void TakePoints()
        {
            this.Amount -= 1;
            /*String.Format("{0:t}", DateTime.Now);*/
        }

        public void ClearPoints()
        {
            this.Amount = 0;
        }

        public void RemovePlayer()
        {
            
        }

        public void ChangeName()
        {
            this.Name = "";
        }

        public void Teams()
        {
            if (this.TeamPlay == false)
            {
                this.TeamPlay = true;
            }
            else if (this.TeamPlay == true)
            {
                this.TeamPlay = false;
            }
            
        }
    }
}
