using System;
using System.Windows.Input;
using quickfitgym.Models;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class EditProgramViewModel : BaseViewModel
    {
        public EditProgramViewModel()
        {
            
        }

        public EditProgramViewModel(Program program)
        {
            Title = $"EDIT {program.Name.ToUpper()}";
            ProgramName = program.Name;
            ProgramId = program.Id;
            Description = program.Description;
        }

        private string _programName;
        public string ProgramName
        {
            get { return _programName; }
            set
            {
                SetProperty(ref _programName, value);
                OnPropertyChanged(nameof(ProgramName));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
                OnPropertyChanged(nameof(Description));
            }
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

        public ICommand SwipeLeftCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var program = e as Program;
                });
            }
        }
    }
}
