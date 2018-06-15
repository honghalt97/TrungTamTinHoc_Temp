using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class SocialAccount
    {
        public string Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public DateTime Birthday { set; get; }
        public bool Gender { set; get; }
        public string PhoneNumber { set; get; }
    }
}