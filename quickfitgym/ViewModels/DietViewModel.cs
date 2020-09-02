using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using quickfitgym.Models;
using Xamarin.Essentials;

namespace quickfitgym.ViewModels
{
    public class DietViewModel : BaseViewModel
    {
        public ObservableCollection<Diet> DietCollection { get; set; }
        public DietViewModel()
        {
            Title = "Diet Plan";
            DietCollection = new ObservableCollection<Diet>
            {
                new Diet
                {
                     Title         = "Breakfast",
                     Content       ="Food and Cereal",
                     Description   = "Kefit, Yogurt, banana, apple, ...",
                     Hour          = "08:30 AM",
                     Features      = new List<Features>
                      {
                          new Features
                          {
                               Name = "Light",
                               BGColor = ColorConverters.FromHex("#f0fbf3"),
                               TxColor = ColorConverters.FromHex("#74d884")
                          },
                          new Features
                          {
                               Name = "Energised",
                               BGColor = ColorConverters.FromHex("#fefbec"),
                               TxColor = ColorConverters.FromHex("#fcd058")
                          },
                          new Features
                          {
                               Name = "Satisfied",
                               BGColor = ColorConverters.FromHex("#fceeeb"),
                               TxColor = ColorConverters.FromHex("#fe4134")
                          },
                          new Features
                          {
                               Name = "Healthy",
                               BGColor = ColorConverters.FromHex("#fefbec"),
                               TxColor = ColorConverters.FromHex("#fcd058")
                          },
                          new Features
                          {
                               Name = "Comfortable",
                               BGColor = ColorConverters.FromHex("#f0fbf3"),
                               TxColor = ColorConverters.FromHex("#74d884")
                          }
                      }
                },
                new Diet
                {
                     Title         = "Lunch",
                     Content = "Falafep wrap",
                     Description   = "Falafer, yoghurt, onions, tomatoes ...",
                     Hour          = "12:30 PM",
                     Features      = new List<Features>
                      {
                          new Features
                          {
                               Name = "Energised",
                               BGColor = ColorConverters.FromHex("#fefbec"),
                               TxColor = ColorConverters.FromHex("#fcd058")
                          },
                          new Features
                          {
                               Name = "Light",
                               BGColor = ColorConverters.FromHex("#f0fbf3"),
                               TxColor = ColorConverters.FromHex("#74d884")
                          },
                          new Features
                          {
                               Name = "Satisfied",
                               BGColor = ColorConverters.FromHex("#fceeeb"),
                               TxColor = ColorConverters.FromHex("#fe4134")
                          },
                          new Features
                          {
                               Name = "Healthy",
                               BGColor = ColorConverters.FromHex("#fefbec"),
                               TxColor = ColorConverters.FromHex("#fcd058")
                          },
                      }
                },
                new Diet
                {
                     Title         = "Dinner",
                     Content = "Bean chilli",
                     Description   = "Brown rice, Tomatoes, Kidney beans...",
                     Hour          = "08:30 PM",
                     Features      = new List<Features>
                      {
                          new Features
                          {
                               Name = "Light",
                               BGColor = ColorConverters.FromHex("#f0fbf3"),
                               TxColor = ColorConverters.FromHex("#74d884")
                          },
                          new Features
                          {
                               Name = "Satisfied",
                               BGColor = ColorConverters.FromHex("#fceeeb"),
                               TxColor = ColorConverters.FromHex("#fe4134")
                          }
                      }
                }
            };
        }
    }
}
