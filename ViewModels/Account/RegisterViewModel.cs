using System.ComponentModel.DataAnnotations;

namespace ItransitionProjectMVC.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Имя пользователя обязательно")]
    [Display(Name = "Имя пользователя")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат Email")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Пароль обязателен")]
    [DataType(DataType.Password)]
    // [MinLength(6, ErrorMessage = "Пароль должен быть не менее 6 символов")]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Подтверждение пароля обязательно")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердите пароль")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; } = string.Empty;
}