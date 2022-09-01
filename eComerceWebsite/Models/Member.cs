﻿using System.ComponentModel.DataAnnotations;

namespace eComerceWebsite.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

    }


}