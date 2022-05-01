﻿using FeninetsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeninetsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailContact : ContentPage
    {
        public DetailContact()
        {
            InitializeComponent();
            BindingContext = new AddContactViewModel();
        }
    }
}