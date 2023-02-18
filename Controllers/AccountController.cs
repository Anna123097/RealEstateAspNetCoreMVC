using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Недвижимость.Models.viewModels;
using Недвижимость.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace Недвижимость.Controllers
{
    public class AccountController:Controller
    {
        database db = new database();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = db.getUser(model.Email,model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
               
               
                    // добавляем пользователя в бд
                   if( db.AddNewUser(model.Name, model.Surname, model.Numder_phone, model.Email, model.Password)==true)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                   else
                { ModelState.AddModelError("", "Некорректно введенны данный, либо пользователь уже существует"); }
                 
                }
               
           
            return View(model);
        }

        private async Task Authenticate(string email)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
     
        public bool CheclUser(string Email, string Password)
        {
            string path = "server=localhost;user=root;database=nedvijemost;password=toor;";
            try
            {

                MySqlConnection connection = new MySqlConnection(path);
                connection.Open();
                string sql_zapros = "SELECT id FROM peoples WHERE email ='"+Email+ "' AND password='"+Password+"';";
                MySqlCommand command = new MySqlCommand(sql_zapros, connection);
                command.ExecuteNonQuery();//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                connection.Close();
                return true;
            }
            catch (Exception ex) {/* Console.WriteLine("Пользователь еще раз нажал /start");*/ }
            return false;
        }
    }
}