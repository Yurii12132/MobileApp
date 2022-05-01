using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FeninetsApp.ViewModels
{
    [QueryProperty(nameof(contactId), nameof(contactId))]
    public class DetailContackViewModel : BaseViewModel
    {
        private int contactId;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        public int Id { get; set; }

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
    }
}
