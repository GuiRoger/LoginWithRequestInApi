using System.ComponentModel.DataAnnotations;

namespace LoginWithRequestInApi.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O campo Email está vazio ou é invalido.", AllowEmptyStrings = false)]
        //[RegularExpression(@"b[A-Z0-9._%-]+@[A-Z0-9.-]+.[A-Z]{2,4}b", ErrorMessage = "E-mail em formato inválido.")]
        public string EmailUser { get; set; }
        [Required(ErrorMessage = "O campo Senha está vazio.", AllowEmptyStrings = false)]        
        public string Password { get; set; }
    }
}
    