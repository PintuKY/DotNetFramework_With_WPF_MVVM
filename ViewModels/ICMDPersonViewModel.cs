using SELF_KBM_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SELF_KBM_DESIGN.ICommandf;
namespace SELF_KBM_DESIGN.ViewModels
{
    class ICMDPersonViewModel
    {
        private IList<IComdPerson> _personList;
        public ICMDPersonViewModel()
        {
            _personList = new List<IComdPerson>()
            {
                new IComdPerson(){Name="Prabhat", Address="Bangalore"},
                new IComdPerson(){Name="John",Address="Delhi"}
            };
        }
        public IList<IComdPerson> Persons
        {
            get { return _personList; }
            set { _personList = value; }
        }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
    }
}
