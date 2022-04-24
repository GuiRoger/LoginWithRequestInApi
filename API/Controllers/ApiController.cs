using API.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace API.Controllers
{
    [ApiController]
    [Route("Login")]
    public class ApiController : Controller
    {
      [HttpPost("Singin")]
      public UserData GetLogin(UserLogin dataUser)
      {
            string StringCon = "Server=localhost;Database=usuariosdb;Uid=root;Pwd=Guizinho@2408;";
            var con = new MySqlConnection(StringCon);           

            con.Open();
            var user = con.Query<UserData>("SELECT * FROM usuariosdb.users where UserEmail = @Email and UserPassword = @Password;", new
            {
                @Email = dataUser.EmailUser,
                @Password = dataUser.Password
            }).FirstOrDefault();

            if (user == null)
            {
                var user1 = new UserData();
                user1.UserName = "Desconhecido";
                return user1;

            }
            con.Close();
            con.Dispose();
            return user;
      }


    }
}
