using FeninetsApp.Models;
using FeninetsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FeninetsApp.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public Command AddContactCommand { get; }
        public Command LoadContactsCommand { get; }
        public ObservableCollection<Contact> Contacts { get; }
        public Command<Contact> ItemTapped { get; }
        public ContactsViewModel()
        {
            Title = "Contacts";
            this.Contacts = new ObservableCollection<Contact>();
            LoadContactsCommand = new Command(async () => await ExecuteLoadContactsCommand());
            ItemTapped = new Command<Contact>(OnItemSelected);

            AddContactCommand = new Command(OnAddContact);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            //SelectedItem = null;
        }

        async Task ExecuteLoadContactsCommand()
        {
            IsBusy = true;
            this.Contacts.Clear();
            var contacts = await App.database.GetItemsAsync();
            foreach (var contact in contacts)
            {
                this.Contacts.Add(contact);
            }
            IsBusy = false;
        }

        private async void OnAddContact(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddContact));
        }

        async void OnItemSelected(Contact item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(AddContact)}?{nameof(AddContactViewModel.ContactId)}={item.Id}");
        }

    }
}
