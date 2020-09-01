using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Services;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class RolesViewModel : BaseViewModel
    {
        public ObservableCollection<object> _selectedRoles;
        public ObservableCollection<Role> RolesCollection { get; private set; }
        public RolesViewModel()
        {
            Title = "Roles";
            RolesCollection = new ObservableCollection<Role>();
            _selectedRoles = new ObservableCollection<object>();
            GetRoles();
        }

        public ObservableCollection<object> SelectedRoles
        {
            get { return _selectedRoles; }
            set
            {
                SetProperty(ref _selectedRoles, value);
                OnPropertyChanged(nameof(SelectedRoles));
            }
        }

        public ICommand DeleteRoleCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var role = e as Role;
                });
            }
        }

        public ICommand EditRoleCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var role = e as Role;
                });
            }
        }

        private async void GetRoles()
        {
            var roles = await ApiService.GetRoles();
            if(roles!=null)
            {
                if (roles.Count > 0)
                {
                    foreach (var r in roles)
                    {
                        RolesCollection.Add(r);
                    }
                }
            }
        }

        public ICommand SaveRoleCommand
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
