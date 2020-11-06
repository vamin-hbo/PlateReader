using GalaSoft.MvvmLight;

namespace PlateReader.ViewModel
{
    public class WellsBaseViewModel : ViewModelBase
    {
        private string _rowHeader;
        public string RowHeader
        {
            get { return _rowHeader; }
            set
            {
                _rowHeader = value;
                RaisePropertyChanged("RowHeader");
            }
        }
    }
}