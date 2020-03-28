using DevExpress.Mvvm;
using System;
using System.Timers;

namespace LoadingDecoratorWithPrism.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { SetValue(ref text, value); }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                if (SetValue(ref isLoading, value))
                {
                    StopAndRunAgain();
                }
            }
        }

        private void StopAndRunAgain()
        {
            Timer timer = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds);
            timer.Elapsed += (s, e) =>
            {
                ((Timer)s).Dispose();
                IsLoading = !IsLoading;
            };

            timer.Start();
        }

        public FirstViewModel()
        {
            IsLoading = true;
            Text = "Firs View";
        }
    }
}