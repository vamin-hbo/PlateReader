namespace PlateReader.ViewModel
{
    public class Wells48ViewModel : WellsBaseViewModel
    {
        private string _columnOne;
        public string ColumnOne
        {
            get { return _columnOne; }
            set
            {
                _columnOne = value;
                RaisePropertyChanged("ColumnOne");
            }
        }

        private string _columnTwo;
        public string ColumnTwo
        {
            get { return _columnTwo; }
            set
            {
                _columnTwo = value;
                RaisePropertyChanged("ColumnTwo");
            }
        }

        private string _columnThree;
        public string ColumnThree
        {
            get { return _columnThree; }
            set
            {
                _columnThree = value;
                RaisePropertyChanged("ColumnThree");
            }
        }

        private string _columnFour;
        public string ColumnFour
        {
            get { return _columnFour; }
            set
            {
                _columnFour = value;
                RaisePropertyChanged("ColumnFour");
            }
        }

        private string _columnFive;
        public string ColumnFive
        {
            get { return _columnFive; }
            set
            {
                _columnFive = value;
                RaisePropertyChanged("ColumnFive");
            }
        }

        private string _columnSix;
        public string ColumnSix
        {
            get { return _columnSix; }
            set
            {
                _columnSix = value;
                RaisePropertyChanged("ColumnSix");
            }
        }

    }
}