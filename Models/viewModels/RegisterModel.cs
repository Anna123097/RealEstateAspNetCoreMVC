using System.ComponentModel.DataAnnotations;

namespace Недвижимость.Models.viewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указана Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]       
        public string Numder_phone { get; set; }

        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }
    }
}
