using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Taschenrechner2.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {

        //For Updating UI (need to learn more)
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
