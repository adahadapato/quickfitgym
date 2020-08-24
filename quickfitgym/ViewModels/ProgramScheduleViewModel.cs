using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class ProgramScheduleViewModel:BaseViewModel
    {
        public ObservableCollection<string> DaysCollection { get; private set; }
        public ProgramScheduleViewModel(Program program)
        {
            ProgramId = program.Id;
            ProgramName = program.Name;

            var DaysList = new List<string>()
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wensday",
                "Thursday",
                "Friday",
                "Saturday"
            };

            DaysCollection = new ObservableCollection<string>(DaysList);
        }

        public ProgramScheduleViewModel()
        {
           
        }
        private int _programId;
        public int ProgramId
        {
            get { return _programId; }
            set
            {
                SetProperty(ref _programId, value);
                OnPropertyChanged(nameof(ProgramId));
            }
        }

        private string _programName;
        public string ProgramName
        {
            get
            {
                return _programName;
            }
            set
            {
                SetProperty(ref _programName, value);
                OnPropertyChanged(nameof(ProgramName));
            }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                SetProperty(ref _startTime, value);
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private DateTime _stopTime;
        public DateTime StopTime
        {
            get { return _stopTime; }
            set
            {
                SetProperty(ref _stopTime, value);
                OnPropertyChanged(nameof(StopTime));
            }
        }

        private string _selectedDay;
        public string SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                SetProperty(ref _selectedDay, value);
                OnPropertyChanged(nameof(SelectedDay));
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var schedule = new ProgramSchedule()
                    {
                        ProgramId = ProgramId,
                        DayOfWeek = SelectedDay,
                        StartTime = StartTime.ToString("hh:mm tt"),
                        StopTime = StopTime.ToString("hh:mm tt")
                    };
                    var result = await ApiService.CreateSchedule(schedule);
                    if (result)
                        await Shell.Current.Navigation.PopAsync();
                });
            }
        }

       
    }
}
