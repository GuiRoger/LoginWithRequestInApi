using LoginWithRequestInApi.Client;
using LoginWithRequestInApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LoginWithRequestInApi.Models;

namespace LoginWithRequestInApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private CustomHttpClient _client;

        public LoginController(ILogger<LoginController> logger, CustomHttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }       


        [HttpPost("Logar")]
        [Route("Home/Logar")]
        public async Task<StatusViewModel> Logar(UserLogin data)
        {
            var statusForView = new StatusViewModel();
            if (!String.IsNullOrWhiteSpace(data.EmailUser) || !String.IsNullOrWhiteSpace(data.Password))
            {
                var status = _client.Request(data).Result;

                if (status.UserName == "Desconhecido")
                {
                    statusForView.Message = "Usuário não encontrado.";
                    statusForView.Status = false;
                    return statusForView;
                }
                statusForView.Message = "Usuário logado com sucesso!";
                statusForView.Status = true;
                return statusForView;
            }
           
            statusForView.Message = "Credenciais incorretas ou Campos vazios";
            statusForView.Status = false;
            return statusForView;
           
           
            
        }

    }
}