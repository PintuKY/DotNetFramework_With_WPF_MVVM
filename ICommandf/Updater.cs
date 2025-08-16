using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SELF_KBM_DESIGN.ICommandf
{
    class Updater : ICommand
    {
        #region ICommand Members

        public void Execute(object parameter)
        {
            //Your Code
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }       
        #endregion
    }
}
