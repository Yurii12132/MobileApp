using FeninetsApp.Models;
using FeninetsApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FeninetsApp.ViewModels
{
    [QueryProperty(nameof(contactId), nameof(contactId))]
    public class AddContactViewModel : BaseViewModel
    {
        private int contactId;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        public AddContactViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_firstName)
                && !String.IsNullOrWhiteSpace(_lastName)
                && !String.IsNullOrWhiteSpace(_phone)
                && !String.IsNullOrWhiteSpace(_email);
        }

        public int Id { get; set; }
        public int ContactId
        {
            get
            {
                return contactId;
            }
            set
            {
                contactId = value;
                LoadContactId(value);
            }
        }

        public async void LoadContactId(int contactId)
        {
            try
            {
                var contact = await DataStore.GetAsync(contactId);
                Id = contact.Id;
                FirstName = contact.FirstName;
                LastName = contact.LastName;
                Phone = _phone;
                Email = contact.Email;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Contact contact = new Contact()
            {
                Id = 0,
                FullName = _firstName + " " + _lastName,
                FirstName = _firstName,
                LastName = _lastName,
                Phone = _phone,
                Email = _email,
                Image = " "
            };
            await App.Database.SaveItemAsync(contact);
           
            await Shell.Current.GoToAsync("..");
        }
    }
}
