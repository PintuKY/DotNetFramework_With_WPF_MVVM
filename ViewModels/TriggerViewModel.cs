using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELF_KBM_DESIGN.ViewModels
{
    class TriggerViewModel : INotifyPropertyChanged
    {
        private bool _isActive;
        public bool IsActive 
        {
            get 
            {
                if (_isActive == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                    
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
