using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using quickfitgym.Models;
using quickfitgym.Services;

namespace quickfitgym.ViewModels
{
    public class AdminMembersListViewModel:BaseViewModel
    {
        public ObservableCollection<Members> MembersCollection { get; private set; }
        public AdminMembersListViewModel()
        {
            MembersCollection = new ObservableCollection<Members>();
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
            if(members!=null)
            {
                foreach(var m in members)
                {
                    m.RegistrationDate = m.JoinDate.ToString("dd/MM/yyyy");
                    MembersCollection.Add(m);
                }
            }  
        }
    }
}
