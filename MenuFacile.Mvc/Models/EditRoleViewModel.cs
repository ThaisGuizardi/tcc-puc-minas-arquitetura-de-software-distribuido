using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuFacile.Mvc.Models
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Nome da permissão é obrigatório.")]
        public string RoleName { get; set; }

    }
}
