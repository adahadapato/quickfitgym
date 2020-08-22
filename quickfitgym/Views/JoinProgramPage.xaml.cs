using System;
using System.Collections.Generic;
using quickfitgym.Models;
using quickfitgym.ViewModels;
using Xamarin.Forms;

namespace quickfitgym.Views
{
    public partial class JoinProgramPage : ContentPage
    {
        public JoinProgramPage(Program program)
        {
            InitializeComponent();
            BindingContext = new JoinProgramViewModel(program);
        }
    }
}
