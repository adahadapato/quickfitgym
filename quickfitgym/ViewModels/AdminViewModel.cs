﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quickfitgym.Models;
using quickfitgym.Views;
using Xamarin.Forms;

namespace quickfitgym.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public ObservableCollection<AdminMenu> MenuCollection { get; private set; }
        public AdminViewModel()
        {
            Title = "Admin";
            MenuCollection = new ObservableCollection<AdminMenu>() {

            new AdminMenu(){Title ="Program", route="program",ImageUrl="program.png"},
            new AdminMenu(){Title ="Videos" , route="videos",ImageUrl="Videos.png"},
            new AdminMenu(){Title ="Roles",route="roles" ,ImageUrl="Role.png"},
            new AdminMenu(){Title ="Home" , route="home",ImageUrl="xxx"},
            new AdminMenu(){Title ="About Us",route="aboutus" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Product" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Diets" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Challenges" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Trainers" ,ImageUrl="xxx"},
            new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
             new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
              new AdminMenu(){Title ="Transatcions" ,ImageUrl="xxx"},
            };
        }

        private AdminMenu _selectedMenu;
        public AdminMenu SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                SetProperty(ref _selectedMenu, value);
                OnPropertyChanged(nameof(SelectedMenu));
            }
        }

        public ICommand SelectedItemCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var item = SelectedMenu;
                    if (!string.IsNullOrWhiteSpace(item.route))
                        await Shell.Current.GoToAsync($"{item.route}");
                });
            }
        }
    }
}
