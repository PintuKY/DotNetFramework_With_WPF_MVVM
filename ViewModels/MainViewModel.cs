using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELF_KBM_DESIGN.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _name = "PintuKumarYadav";
        private string _names = "Pintukumar";
        private string _UserFeedback;
        public string UserFeedback
        {
            get { return _UserFeedback; }
            set { 
                _UserFeedback = value;
                OnPropertyChanged(nameof(_UserFeedback));
            }
        }
        public string Names
        {
            get { return _names; }
            set
            {
                _names = value;
                OnPropertyChanged(nameof(Names));
            }
        }
        public string Name
        {
            get { return _name; }
            //set { _name = value; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(_name));
            }
        }
        private string _fancyText = "Fancy!";
        private bool _showFancyText;
        public string FancyText
        {
            get { return _fancyText; }
            set
            {
                _fancyText = value;
                OnPropertyChanged(nameof(FancyText));
            }
        }
        public bool ShowFancyText
        {
            get { return _showFancyText; }
            set
            {
                _showFancyText = value;
                OnPropertyChanged(nameof(ShowFancyText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}



