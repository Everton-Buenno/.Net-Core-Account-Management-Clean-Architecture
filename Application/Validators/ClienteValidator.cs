using Application.DTOs;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ClienteValidator:AbstractValidator<ClienteInput>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(cliente => cliente.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("O CPF deve estar no formato XXX.XXX.XXX-XX.");

            RuleFor(cliente => cliente.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .Length(5, 200).WithMessage("O endereço deve ter entre 5 e 200 caracteres.");

            RuleFor(cliente => cliente.Profissao)
                .NotEmpty().WithMessage("A profissão é obrigatória.")
                .Length(2, 100).WithMessage("A profissão deve ter entre 2 e 100 caracteres.");
        }

    }
}
