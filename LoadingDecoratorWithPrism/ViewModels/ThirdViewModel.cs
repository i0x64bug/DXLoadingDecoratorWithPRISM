
using DevExpress.Mvvm;

namespace LoadingDecoratorWithPrism.ViewModels
{
    public class ThirdViewModel : ViewModelBase
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { SetValue(ref text, value); }
        }

        public ThirdViewModel()
        {
            Text = "Third View";
        }
    }
}