using FeninetsApp.ViewModels;
using FeninetsApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FeninetsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddContact), typeof(AddContact));
            App.Database.CreateTable();
        }
    }
}
