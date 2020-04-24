using FluentValidation;

using TanulmanyiRendszer.BLL.DataTransferObjects;

namespace TanulmanyiRendszer.API.Validators
{
    public class SzemeszterValidator : AbstractValidator<SzemeszterDto>
    {
        public SzemeszterValidator()
        {
            RuleFor(x => x.Megnevezes)
                .NotEmpty()
                .WithMessage("A szemeszter megnevezése kötelező");
        }
    }
}