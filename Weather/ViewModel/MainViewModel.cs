using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using Weather.Model;

namespace Weather.ViewModel
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
        public const string DayListPropertyName = "DayList";

        private ObservableCollection<Day> _dayList = null;

        public ObservableCollection<Day> DayList
        {
            get { return _dayList; }
            set { _dayList = value; }
        }
        

        public const string CurrentDayPropertyName = "CurrentDay";

        private Day _currentDay = null;

        public Day CurrentDay
        {
            get { return _currentDay; }
            set { _currentDay = value; }
        }

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                DayList = new ObservableCollection<Day>();
                DayList.Add(new Day { temp = 20, Time = DateTime.Now, weather = new System.Collections.Generic.List<Model.Weather> { new Model.Weather { icon = "01d" }} });
                DayList.Add(new Day { temp = 20, Time = DateTime.Now.AddDays(1) });
                DayList.Add(new Day { temp = 20, Time = DateTime.Now.AddDays(2) });
                DayList.Add(new Day { temp = 20, Time = DateTime.Now.AddDays(3) });
                DayList.Add(new Day { temp = 20, Time = DateTime.Now.AddDays(4) });
                CurrentDay = DayList[0]; //De huidige dag is nu de de eerste dag in de array
                //Deze waardes zijn valse waardes, ze zijn enkel om de designer view voor te stellen
            }
            else
            {
                WebClient client = new WebClient();
                client.DownloadStringCompleted += (s, e) => //lambda
                    {
                        if (e.Error == null)
                        {
                            RootObject result = JsonConvert.DeserializeObject<RootObject>(e.Result);
                            DayList = new ObservableCollection<Day>(result.list);
                            CurrentDay = DayList[0];
                        }
                        else
                        {
                            MessageBox.Show("Sorry, try again.");
                        }
                    };
                client.DownloadStringAsync(new Uri("http://api.openweathermap.org/data/2.2/forecast/city?q=hasselt&mode=daily_compact&units=metric"));
            }
        }
    }
}