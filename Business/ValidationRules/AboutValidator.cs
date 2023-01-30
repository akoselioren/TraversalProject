using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=> x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.!");
            RuleFor(x=> x.Description).MinimumLength(15).WithMessage("Açıklama kısmı en az 15 karakter olabilir.!");
           
        }
    }
}
