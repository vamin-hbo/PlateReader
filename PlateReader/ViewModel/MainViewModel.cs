using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PlateReader.Helper;
using PlateReader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace PlateReader.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private int _threshold = 100;
        private List<WellsModel> sortedWells = null;
        private int _totalLowCount;
        private int _totalWellCount;
        private bool _isExtendedGrid;
        private ObservableCollection<Wells48ViewModel> wellsCollection = new ObservableCollection<Wells48ViewModel>();
        public ObservableCollection<Wells48ViewModel> WellsCollection
        {
            get { return wellsCollection; }
            set
            {
                wellsCollection = value;
                RaisePropertyChanged("WellsCollection");
            }
        }
        public int Threshold
        {
            get { return _threshold; }
            set
            {
                _threshold = value;
                RaisePropertyChanged("Threshold");
                CreateWellsViewModel();
            }
        }

        public int TotalLowCount
        {
            get { return _totalLowCount; }
            set
            {
                _totalLowCount = value;
                RaisePropertyChanged("TotalLowCount");
            }
        }

        public int TotalWellCount
        {
            get { return _totalWellCount; }
            set
            {
                _totalWellCount = value;
                RaisePropertyChanged("TotalWellCount");
            }
        }

        public bool IsExtendedGrid
        {
            get { return _isExtendedGrid; }
            set
            {
                _isExtendedGrid = value;
                RaisePropertyChanged("IsExtendedGrid");
            }
        }
        

        /// <summary>
        /// Constructor of VM, Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            RegisterMessageForSelectedFile();
        }

        /// <summary>
        /// This method registers for message from other ViewModel
        /// </summary>
        private void RegisterMessageForSelectedFile()
        {
            MessengerInstance.Register<NotificationMessage>(this, SelectedFile_Changed);
        }

        /// <summary>
        /// The method is to handle the operation, when a new file has been selected by user
        /// </summary>
        /// <param name="notificationMessage"></param>
        private void SelectedFile_Changed(NotificationMessage notificationMessage)
        {
            string filePath = notificationMessage.Notification;

            if (string.IsNullOrEmpty(filePath))
                return;

            // Call the helper function to get a clr object of the contents of Json file
            var jsonObjectData = JsonHelper.GetPlateDropletInfo(filePath);
            sortedWells = SortWellsByIndex(jsonObjectData);
            CreateWellsViewModel();
        }

        /// <summary>
        /// This methods only responsiblity is to Sort the Wells 
        /// </summary>
        /// <param name="jsonObjectData"></param>
        /// <returns></returns>
        private List<WellsModel> SortWellsByIndex(Root jsonObjectData)
        {
            if (jsonObjectData == null)
            {
                // No data - Log Error or Display Error Message to user 
            }
            else
            {
                jsonObjectData?.PlateDropletInfo?.DropletInfo?.Wells?.Sort();
            }

            return jsonObjectData?.PlateDropletInfo?.DropletInfo?.Wells;
        }

        /// <summary>
        /// Here we create the Wells View Models are created based on the number of wells
        /// ToDo - this method can be optimized further
        /// </summary>
        private void CreateWellsViewModel()
        {
            // Clear the wells observable collection,else new rows get added
            wellsCollection.Clear();

            if (sortedWells.Count == 48)
            {
                // When count is 48 use WellsBaseViewModel
                TotalWellCount = 48;
                TotalLowCount = 0;
                IsExtendedGrid = false;
                for (int i = 0; i < sortedWells.Count; i += 6)
                {
                    var wellVM = new Wells48ViewModel
                    {
                        RowHeader = sortedWells[i].WellName[0].ToString(), // Add data validation as we are using index 
                        ColumnOne = CompareThreshold(sortedWells[i].DropletCount),
                        ColumnTwo = CompareThreshold(sortedWells[i + 1].DropletCount),
                        ColumnThree = CompareThreshold(sortedWells[i + 2].DropletCount),
                        ColumnFour = CompareThreshold(sortedWells[i + 3].DropletCount),
                        ColumnFive = CompareThreshold(sortedWells[i + 4].DropletCount),
                        ColumnSix = CompareThreshold(sortedWells[i + 5].DropletCount)
                    };

                    wellsCollection.Add(wellVM);
                }
            }
            else
            {
                // When count is 96 use WellsExtendedViewModel
                TotalWellCount = 96;
                TotalLowCount = 0;
                IsExtendedGrid = true;
                for (int i = 0; i < sortedWells.Count; i += 12)
                {
                    var wellVM = new Wells96ViewModel
                    {
                        RowHeader = sortedWells[i].WellName[0].ToString(), // Add data validation as we are using index 
                        ColumnOne = CompareThreshold(sortedWells[i].DropletCount),
                        ColumnTwo = CompareThreshold(sortedWells[i + 1].DropletCount),
                        ColumnThree = CompareThreshold(sortedWells[i + 2].DropletCount),
                        ColumnFour = CompareThreshold(sortedWells[i + 3].DropletCount),
                        ColumnFive = CompareThreshold(sortedWells[i + 4].DropletCount),
                        ColumnSix = CompareThreshold(sortedWells[i + 5].DropletCount),
                        ColumnSeven = CompareThreshold(sortedWells[i+ 6].DropletCount),
                        ColumnEight = CompareThreshold(sortedWells[i + 7].DropletCount),
                        ColumnNine = CompareThreshold(sortedWells[i + 8].DropletCount),
                        ColumnTen = CompareThreshold(sortedWells[i + 9].DropletCount),
                        ColumnEleven = CompareThreshold(sortedWells[i + 10].DropletCount),
                        ColumnTwelve = CompareThreshold(sortedWells[i + 11].DropletCount)
                    };

                    wellsCollection.Add(wellVM);
                }
            }
        
        }

        /// <summary>
        /// method returns 'n' if the wellcount is greater then threshold or else 'L'
        /// </summary>
        /// <param name="wellCount"></param>
        /// <returns></returns>
        private string CompareThreshold(int wellCount)
        {
            if (wellCount > _threshold)
            {
                return "n";
            }
            else
            {
                TotalLowCount++;
                return "L";
            }
        }

    }
}