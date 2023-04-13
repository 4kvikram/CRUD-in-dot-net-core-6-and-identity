using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CURD_in_dot_net_6_and_identity.Models
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
