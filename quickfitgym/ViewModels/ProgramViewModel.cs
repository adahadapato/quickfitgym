using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using quickfitgym.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class ProgramViewModel : BaseViewModel
    {
        public ObservableCollection<Program> ProgramCollection { get; private set; }
        //private List<Program> _Programs;
        public ProgramViewModel()
        {
            Title = "Programs";
            IsAdmin =  Preferences.Get("IsAdmin", false);
            ProgramCollection = new ObservableCollection<Program>();
            GetProgrames();
        }

        private async void GetProgrames()
        {
            var result = await ApiService.GetPrograms();
            if (result != null)
            {
                foreach (Program p in result)
                {
                    ProgramCollection.Add(p);
                }
            }
        }

        private List<string> _searchResults;
        public List<string> Searchresults
        {
            get { return _searchResults; }
            set
            {
                SetProperty(ref _searchResults, value);
                OnPropertyChanged(nameof(Searchresults));
            }
        }

        private bool _IsAdmin;
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                SetProperty(ref _IsAdmin, value);
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public ICommand SearchCommand => new Command<string>((string query) =>
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                ProgramCollection.Where(x => x.Name.Contains(query));
            }
        });

        public ICommand AddCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await Shell.Current.Navigation.PushAsync(new AddProgramPage());
                });
            }
           
        }

        public ICommand JoinCommand
        {
            get
            {
                return new Command(async(e) =>
                {
                    var program = e as Program;
                    await Shell.Current.Navigation.PushAsync(new JoinProgramPage(program));
                });
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

        public ICommand SwipeRightCommand
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
