using FluentValidation;
using FluentValidation.AspNetCore;
using OnePiece.Domain.Models;
using System.Data;

namespace OnePiece.Applications.Validator
{
    public class MangaValidator : AbstractValidator<MangasModel>
    {
        public MangaValidator()
        {

            RuleFor(c => c.titulo)
            .NotEmpty()
            .Length(2, 100).WithMessage("O nome deve ter pelo menos 3 caracteres e máximo 100");

            RuleFor(c => c.datapublicacao)
                .NotEmpty()
                .Length(10).WithMessage("A data deve ter este formato XX/XX/XXXX");
            RuleFor(c => c.capitulo)
                .NotEmpty();
            
               
        }

    }
}
