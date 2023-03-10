using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MvcGlAtelier2023.Models
{
    public class Gerant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPers { get; set; }

        [Display(Name = "Matricule"), Required(ErrorMessage = "Champ obligatoire"),MaxLength(20,ErrorMessage ="Taillle max 20")]
        public String Matricule { get; set; }
    }
}