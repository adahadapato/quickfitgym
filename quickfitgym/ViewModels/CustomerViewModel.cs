using System;
using System.Collections.ObjectModel;
using System.Linq;
using quickfitgym.Models;
using quickfitgym.Services;

namespace quickfitgym.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public ObservableCollection<Members> MembersCollection { get; private set; }
        public ObservableCollection<Members> TrainersCollection { get; private set; }
        public CustomerViewModel()
        {
            MembersCollection = new ObservableCollection<Members>();
            TrainersCollection = new ObservableCollection<Members>();
            GetMembers();
        }

        private Members _selectedMember;
        public Members SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                SetProperty(ref _selectedMember, value);
                OnPropertyChanged(nameof(SelectedMember));
            }
        }

        private async void GetMembers()
        {
            var members = await ApiService.GetMembers();
            if (members != null)
            {
                members.ForEach(x => { x.RegistrationDate = x.JoinDate.ToString("dd/MM/yyyy");
                    x.PhotoUrl = (string.IsNullOrWhiteSpace(x.PhotoUrl)) ? "NormalProfile.png" : x.PhotoUrl;
                });
                
                foreach (var m in members)
                {
                    //if (string.IsNullOrWhiteSpace(m.PhotoUrl))
                    //    m.PhotoUrl = "NormalProfile.png";

                    //m.RegistrationDate = m.JoinDate.ToString("dd/MM/yyyy");
                    
                    var trainer = m.Roles.Any(x=> x=="Trainer" || x=="Admin");
                    var member = m.Roles.Any(x => x == "Member");
                   if(member)
                      MembersCollection.Add(m);

                    if (trainer)
                        TrainersCollection.Add(m);
                }
            }
        }
    }
}
