using System.ComponentModel.DataAnnotations;

namespace Chapter.Viewmodels
{
    public class Loginviewmodel
    {
        [ Required(ErrorMessage = "Informe o email do Usuário")]
        public string? email {get;set;}

        [Required(ErrorMessage = "Informe a senha do Usuário")]
        public string? senha { get;set;}
    }
}
