using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quickfitgym.Models;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class JoinProgramViewModel:BaseViewModel
    {
        public ObservableCollection<ProgramSchedule> ScheduleCollection { get; private set; }
        ObservableCollection<object> _selectedSchedule;
        public JoinProgramViewModel(Program program)
        {
            ScheduleCollection = new ObservableCollection<ProgramSchedule>(program.ProgramSchedules);
            _selectedSchedule = new ObservableCollection<object>();
            FTitle = $"Join {program.Name}";
        }

        public JoinProgramViewModel()
        {
        }

        private string _fTitle;
        public string FTitle
        {
            get { return _fTitle; }
            set
            {
                SetProperty(ref _fTitle, value);
                OnPropertyChanged(nameof(FTitle));
            }
        }

        //private ProgramSchedule _selectedSchedule;
        public ObservableCollection<object> SelectedSchedule
        {
            get { return _selectedSchedule; }
            set
            {
                SetProperty(ref _selectedSchedule, value);
                OnPropertyChanged(nameof(SelectedSchedule));
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                return new Command(() =>
                {
                    var k = SelectedSchedule.Count;
                });
            }
        }
    }
}
