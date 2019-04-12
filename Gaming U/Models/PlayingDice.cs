using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_U.Models
{
  public  class PlayingDice : ObservableObjects
    {
        private int _diceAmount;

        public int DiceAmount
        {
            get
            {
                if (_diceAmount <= 0)
                {
                    return 1;
                }
                return _diceAmount; }
            set { _diceAmount = value; }
        }

        private int _diceSides;

        public int DiceSides
        {
            get { if (_diceSides <= 0)
                {
                    return 6;
                }
                return _diceSides;
            }
            set { _diceSides = value; }
        }


    }
}
