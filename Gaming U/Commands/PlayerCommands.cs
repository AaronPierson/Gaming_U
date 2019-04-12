using Gaming_U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gaming_U.Commands
{

    public class PlayerCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
        }
    }

    public class GivePlayerPointsClick : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            ((Player)parameter).GiveInPoints();
            //((Player)parameter).TakePoints();

        }

       
    }

    public class TakePlayerPointsClick : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            //((Player)parameter).GiveInPoints();
            ((Player)parameter).TakePoints();

        }
    }

    public class ClearPlayerPointsClick : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            //((Player)parameter).GiveInPoints();
            ((Player)parameter).ClearPoints();

        }
    }

    public class RemovePlayerClick : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            ((Player)parameter).RemovePlayer();
        }
    }

    public class ChangePlayerNameClick : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((Player)parameter).ChangeName();
        }
    }

    public class TeamPlayClick: ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ((Player)parameter).Teams();
        }
    }
}
