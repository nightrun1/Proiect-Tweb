using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NextGenPC.Models.Users
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nume utilizator")]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parolă nouă")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Parolele nu corespund")]
        [Display(Name = "Confirmă parola nouă")]
        public string ConfirmPassword { get; set; }
    }
}