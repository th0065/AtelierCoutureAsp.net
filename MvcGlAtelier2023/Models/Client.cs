using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcGlAtelier2023.Models
{
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPers { get; set; }

        [Display(Name = "Sexe"), Required(ErrorMessage = "Champ obligatoire")]
        public String Sexe { get; set; }

        [Display(Name = "Statut Inscription")]
        public Boolean StatutInscription { get; set; }

        [Display(Name = "Statut")]
        public Boolean Statut { get; set; }
    }
    public class ClientViewModel
    {
        [Key]
        public int IdPers { get; set; }


        [Display(Name = "Nom"), MaxLength(80, ErrorMessage = "Taille Max 80"), Required(ErrorMessage = "Champ obligatoire")]
        public String NomPers { get; set; }


        [Display(Name = "Prénom"), MaxLength(80, ErrorMessage = "Taille Max 80"), Required(ErrorMessage = "Champ obligatoire")]
        public String PrenomPers { get; set; }


        [Display(Name = "Adresse"), MaxLength(150, ErrorMessage = "Taille Max 150"), Required(ErrorMessage = "Champ obligatoire")]
        public String AdressePers { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), MaxLength(80, ErrorMessage = "Taille Max 80"), Required(ErrorMessage = "Champ obligatoire")]
        public String EmailPers { get; set; }

        [Display(Name = "Téléphone"), MaxLength(20, ErrorMessage = "Taille Max 20"), Required(ErrorMessage = "Champ obligatoire")]
        public String TelPers { get; set; }

        [Display(Name = "Sexe"), Required(ErrorMessage = "Champ obligatoire")]
        public String Sexe { get; set; }
    }
}