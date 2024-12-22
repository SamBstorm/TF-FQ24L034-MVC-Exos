using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC.Models
{
    public class RegisterForm
    {
        [DisplayName("Prénom :")]
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le prénom doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le prénom doit contenir au maximum 64 caractères.")]
        public string FirstName { get; set; }
        [DisplayName("Nom de famille :")]
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le nom de famille doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le nom de famille doit contenir au maximum 64 caractères.")]
        public string LastName { get; set; }
        [DisplayName("Date de naissance :")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        public DateOnly BirthDate { get; set; }
        [DisplayName("Adresse e-mail :")]
        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [EmailAddress]
        /*Soit l'un soit l'autre
         * [DataType(DataType.EmailAddress)]*/
        public string Email { get; set; }
        [DisplayName("Mot de passe :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir au minimum 8 caractères.")]
        [MaxLength(64, ErrorMessage = "Le mot de passe doit contenir au maximum 64 caractères.")]
        public string Password { get; set; }
        [DisplayName("Veuillez confirmer le mot de passe :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire.")]
        [Compare(nameof(Password),ErrorMessage = "Le mot de passe ne correspond pas à cette valeur.")]
        public string ConfirmPassword { get; set; }
    }
}
