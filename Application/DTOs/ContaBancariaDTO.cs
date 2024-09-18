using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ContaBancariaDTO
    {
        public Guid Id { get; set; }
        public string NumeroConta { get; set; }
        public string Agencia { get; set; }
        public string TipoConta { get; set; }
        public decimal Limite { get; set; }
        public decimal Saldo { get; set; }

       
    }
}
