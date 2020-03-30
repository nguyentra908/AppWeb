using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Entities
{
   public class Users
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
