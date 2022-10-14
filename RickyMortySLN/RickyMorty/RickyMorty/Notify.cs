using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RickyMorty
{
    public abstract class Notify : INotifyPropertyChanged
    {
        private bool isBusy;
        public bool IsBusy { get => isBusy; set { isBusy = value; RaisePropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
