using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class Account
    {
        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string Username { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string Password { set; get; }
    }
}