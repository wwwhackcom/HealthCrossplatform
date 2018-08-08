using System;
namespace HealthCrossplatform.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Emailaddress { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int Admin { get; set; }
        public int Registered { get; set; }

        public string Password { get; set; }
        public string lastlogin { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
