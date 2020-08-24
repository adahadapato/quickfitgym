using System;
using System.Collections.Generic;
using quickfitgym.Models;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class ProgramSchedulePage : ContentPage
    {
        public ProgramSchedulePage(Program program)
        {
            InitializeComponent();
            BindingContext = new ProgramScheduleViewModel(program);
        }
    }
}
