using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeninetsApp.Models
{
    [Table("Contact")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

        public Contact() { }

    }
}
