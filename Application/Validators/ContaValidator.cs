using Application.DTOs;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ContaValidator : AbstractValidator<CriarContaRequest>
    {
        public ContaValidator()
        {
            RuleFor(x => x.ClienteId)
          .NotEmpty().WithMessage("O ClienteId é obrigatório.");

            RuleFor(x => x.TipoConta)
                .IsInEnum().WithMessage("O tipo de conta informado é inválido.");

           
        }
    }
}
