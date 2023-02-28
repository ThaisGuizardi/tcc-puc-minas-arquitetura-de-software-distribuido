using System.ComponentModel.DataAnnotations;

namespace MenuFacile.Mvc.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
