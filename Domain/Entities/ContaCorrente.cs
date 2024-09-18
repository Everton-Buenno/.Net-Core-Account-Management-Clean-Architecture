using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class ContaCorrente : ContaBancaria
    {
        private static readonly Random random = new Random();
        public ContaCorrente() : base( 0, null, TipoConta.Corrente)
        {
        }
        public ContaCorrente( decimal saldo, Cliente cliente):base(saldo, cliente, TipoConta.Corrente)
        {
        }
        public decimal Limite { get; private set; }
        public override bool Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor do saque deve ser positivo");

            if (Saldo + Limite >= valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }


        public void GerarLimite()
        {
            Limite = random.Next(1000, 25000);
        }
        public void AplicarJuros(decimal taxaJuros)
        {
            if(Saldo < 0)
            {
                Saldo -= Math.Abs(Saldo) * taxaJuros;

            }
        }
    }
}
