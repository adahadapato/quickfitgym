using System;
using System.Collections.ObjectModel;
using quickfitgym.Models;

namespace quickfitgym.ViewModels
{
    public class JoinProgramViewModel:BaseViewModel
    {
        public ObservableCollection<ProgramSchedule> ScheduleCollection { get; private set; }
        public JoinProgramViewModel(Program program)
        {
            ScheduleCollection = new ObservableCollection<ProgramSchedule>(program.ProgramSchedules);
        }

        public JoinProgramViewModel()
        {
        }
    }
}
