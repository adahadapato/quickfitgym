using System;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class AddProgramViewModel : BaseViewModel
    {
        public AddProgramViewModel()
        {
        }
        private string _programName;
        public string ProgramName
        {
            get { return _programName; }
            set { SetProperty(ref _programName, value);
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
        public ICommand SubmitCommand
         {
            get
            {
                return new Command(async() =>
                {
                    if(string.IsNullOrWhiteSpace(ProgramName) || string.IsNullOrWhiteSpace(Description))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Incomplete Program details", "CANCEL");
                        return;
                    }
                    var program = new Program()
                    {
                        Name = ProgramName,
                        Description = Description
                    };
                    var result = await ApiService.AddProgram(program);
                    if(result!=null)
                    {
                        ProgramId = result.ProgramId;
                    }
                });
            }
         }

        public ICommand ScheduleCommand
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }

    }
}
