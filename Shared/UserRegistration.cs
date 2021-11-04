using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Shared
{
    public class UserRegistration
    {
        [EmailAddress, Required]
        public string Email { get; set; }
        [StringLength(10, ErrorMessage = "Username is too long"), Required]
        public string Username { get; set; }
        [Required, StringLength(10, MinimumLength = 4)]
        public string Password { get; set; }
        [Required, Compare("Password", ErrorMessage = "Passwords are not the same.")]
        public string PasswordConfirm { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Range(typeof(bool), "true", "true", ErrorMessage = "Confirm")]
        public bool Confirmation { get; set; }
    }
}

