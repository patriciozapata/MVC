using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
//para validar
//darle formao telefono fecha etc

namespace MVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage ="El {0} debe tener al menos {1} caracteres",MinimumLength =1)]
        [Display(Name="Correo Electronico ")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Comfirma Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string ComfirmPassword { get; set; }
    }

    public class EditUserViewModel
    {
        public int id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electronico ")]
        public string Correo { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Comfirma Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ComfirmPassword { get; set; }
    }
}