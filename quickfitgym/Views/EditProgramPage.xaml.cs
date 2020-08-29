using System;
using System.Collections.Generic;
using quickfitgym.Models;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class EditProgramPage : ContentPage
    {
        public EditProgramPage(Program program)
        {
            InitializeComponent();
            this.BindingContext = new EditProgramViewModel(program);
        }
    }
}
