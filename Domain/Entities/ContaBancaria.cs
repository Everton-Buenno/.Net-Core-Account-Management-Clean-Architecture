using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.ContaPoupanca;

namespace Domain.Entities
{
    public abstract class ContaBancaria
    {
        protected ContaBancaria(decimal saldo, Cliente cliente, TipoConta tipoConta)
        {
            Saldo = saldo;
            Cliente = cliente;
            TipoConta = tipoConta;
        }
        public Guid ContaID { get; private set; }
        public string NumeroConta { get; protected set; }
        public string Agencia { get; protected set; }
        public decimal Saldo { get; protected set; }
        public Guid ClienteID { get; protected set; }
        public TipoConta TipoConta { get; protected set; }
        public Cliente Cliente { get; private set; }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor depositado deve ser positivo");

            Saldo += valor;
        }

        public void GerarNumeroAgencia()
        {
            Random random = new Random();
            NumeroConta = random.Next(1000, 9999).ToString();
        }

        public void GerarNumeroConta()
        {
            Random random = new Random();
            Agencia =  random.Next(100000, 999999).ToString();
        }

        
        public abstract bool Sacar(decimal valor);
    }
}
