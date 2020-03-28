using DevExpress.Mvvm;

namespace LoadingDecoratorWithPrism.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { SetValue(ref text, value); }
        }

        public SecondViewModel()
        {
            Text = "Second View";
        }
    }
}