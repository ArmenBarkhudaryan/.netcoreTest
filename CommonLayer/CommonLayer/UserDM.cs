using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public User()
        {

        }

        public User(int ID, string FirstName, string LastName, string Password, string RoleId, DateTime BirthDate, string Email = null, string Address = null)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.Email = Email;
            this.Address = Address;
            this.BirthDate = BirthDate;
            this.RoleId = RoleId;
        }
    }
}
