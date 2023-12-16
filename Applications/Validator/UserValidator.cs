using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Data;
using System.Data;

namespace OnePiece.Applications.Validator
{
    public class UserValidator : AbstractValidator<UsuarioModel>
    {

        private readonly BancoContext _context;

        public UserValidator()
        {
            RuleFor(c => c.email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail não está em um formato válido.")
            .Must(BeUniqueEmail).WithMessage("Este e-mail já está em uso.");


        }
        private bool BeUniqueEmail(string email)
        {
            return !_context.Set<UsuarioModel>().Any(u => u.email == email);
        }

    }
}
