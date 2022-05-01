using FeninetsApp.Models;
using FeninetsApp.ViewModels;
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
    public partial class AddContact : ContentPage
    {
        public Contact Contact { get; set; }
        public AddContact()
        {
            InitializeComponent();
            BindingContext = new AddContactViewModel();
        }
    }
}