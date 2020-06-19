using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.viewModels
{
    public class TablaViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}