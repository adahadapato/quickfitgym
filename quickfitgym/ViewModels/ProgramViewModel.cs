using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class ProgramViewModel:BaseViewModel
    {
        public ObservableCollection<Program> ProgramCollection { get; private set; }
        //private List<Program> _Programs;
        public ProgramViewModel()
        {
            Title = "Programs";
            ProgramCollection = new ObservableCollection<Program>();
            GetProgrames();
        }

        private async void GetProgrames()
        {
            var result = await ApiService.GetPrograms();
            if (result != null)
            {
                //_Programs = result;
                foreach (var p in result)
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

        public ICommand SearchCommand => new Command<string>((string query) =>
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                ProgramCollection.Where(x => x.Name.Contains(query));
            }
        });

    }
}
