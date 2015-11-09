using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWPDataTriggerDemo
{
    public class MainPageViewModel : INotifyPropertyChanged {
        private String _userInput;
        public String UserInput {
            get { return _userInput; }
            set {
                if (_userInput == value) return;
                _userInput = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValidInteger));
            }
        }
        public Boolean IsValidInteger
        {
            get {
                int i = 0;
                return int.TryParse(UserInput, out i);
            }
        }
        #region "propertychanged"
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = ""){
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
