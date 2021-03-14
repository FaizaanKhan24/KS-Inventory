using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace KSInventory.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Private variables

        private bool isBusy;

        #endregion

        #region Commands

        public ICommand BackCommand { get; set; }

        #endregion

        #region Constructors

        public BaseViewModel()
        {
            InitializeCommands();
        }

        #endregion

        #region Properties

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            BackCommand = new Command(PopPage);
        }

        private async void PopPage()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion

        #region INotify Properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
