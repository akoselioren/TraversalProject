using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber Adı Soyadı kısmını boş geçemezsiniz.!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber açıklama kısmını boş geçemezsiniz.!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Rehber görsel kısmını boş geçemezsiniz.!");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("Rehber Adı Soyadı en az 4 karakter olabilir.!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Rehber Adı Soyadı en fazla 50 karakter olabilir.!");
        }
    }
}
