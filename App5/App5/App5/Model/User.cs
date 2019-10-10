using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Model
{
   public class User
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Room { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
