namespace PlateReader.ViewModel
{
    public class Wells96ViewModel : Wells48ViewModel
    {
        private string _columnSeven;
        public string ColumnSeven
        {
            get { return _columnSeven; }
            set
            {
                _columnSeven = value;
                RaisePropertyChanged("ColumnSeven");
            }
        }

        private string _columnEight;
        public string ColumnEight
        {
            get { return _columnEight; }
            set
            {
                _columnEight = value;
                RaisePropertyChanged("ColumnEight");
            }
        }

        private string _columnNine;
        public string ColumnNine
        {
            get { return _columnNine; }
            set
            {
                _columnNine = value;
                RaisePropertyChanged("ColumnNine");
            }
        }

        private string _columnTen;
        public string ColumnTen
        {
            get { return _columnTen; }
            set
            {
                _columnTen = value;
                RaisePropertyChanged("ColumnTen");
            }
        }

        private string _columnEleven;
        public string ColumnEleven
        {
            get { return _columnEleven; }
            set
            {
                _columnEleven = value;
                RaisePropertyChanged("ColumnEleven");
            }
        }

        private string _columnTwelve;
        public string ColumnTwelve
        {
            get { return _columnTwelve; }
            set
            {
                _columnTwelve = value;
                RaisePropertyChanged("ColumnTwelve");
            }
        }

    }
}