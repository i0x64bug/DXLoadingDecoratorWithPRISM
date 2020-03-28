using DevExpress.Mvvm;
using System;

namespace LoadingDecoratorWithPrism.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string currentDate;
        public string CurrentDate
        {
            get { return currentDate; }
            set
            {
                SetValue(ref currentDate, value);
            }
        }

        public MainWindowViewModel()
        {
            CurrentDate = DateTime.Now.ToShortDateString();
        }
    }
}