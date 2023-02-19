using DTO.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x =>x.NameSurname).NotEmpty().WithMessage("Ad alanı boş geçilemez.!");
            RuleFor(x =>x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.!");
            RuleFor(x =>x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.!");
            RuleFor(x =>x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.!");
            RuleFor(x =>x.ComfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez.!");
            RuleFor(x =>x.UserName).MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter içermelidir.!");
            RuleFor(x =>x.UserName).MaximumLength(25).WithMessage("Kullanıcı adı en fazla 25 karakter içermelidir.!");
            RuleFor(x =>x.Password).Equal(y=>y.ComfirmPassword).WithMessage("Şifreler birbiri ile uyuşmuyor.!");
        }
    }
}
